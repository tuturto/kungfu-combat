using System;
using System.Collections.Generic;

namespace Octo
{
    public class StateCache : IStateCache
    {
        public StateCache (IStateFactory factory)
        {
            _factory = factory;
            _states = new Dictionary<Type, IGameState> ();
        }

        private readonly IStateFactory _factory;
        private Dictionary<Type, IGameState> _states;

        public IGameState GetState(Type state) {

            if (!_states.ContainsKey (state)) {
                _states [state] = _factory.CreateState (state);
            }

            var newState = _states [state];

            if (!newState.ContentLoaded) {
                newState.LoadContent ();
            }

            return newState;
        }
    }
}
