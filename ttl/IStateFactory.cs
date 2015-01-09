using System;

namespace Octo
{
    public interface IStateFactory
    {
        IGameState CreateState(Type type);
    }
}
