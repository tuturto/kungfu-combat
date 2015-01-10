#region Using Statements
using System;

using Octo;

#endregion

namespace KungfuCombat
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Main : OctoGame {

        public Main() : base () {
            _graphics.IsFullScreen = false;
        }

        protected override void Initialize() {
            _stateCache = new StateCache (new StateFactory (_graphics, 
                                                            _spriteBatch));
            _state = _stateCache.GetState (typeof (IntroScreen));

            base.Initialize ();
        }
    }
}
