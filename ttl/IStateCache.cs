using System;

namespace Octo
{
    public interface IStateCache
    {
        IGameState GetState(Type state);
    }
}
