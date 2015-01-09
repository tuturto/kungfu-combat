using System;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using Octo;

namespace KungfuCombat {

    public class StateFactory : IStateFactory {

        public StateFactory(GraphicsDeviceManager graphics,
                            SpriteBatch spriteBatch) {
            _graphics = graphics;
            _spriteBatch = spriteBatch;
        }

        private readonly GraphicsDeviceManager _graphics;
        private readonly SpriteBatch _spriteBatch;

        public IGameState CreateState(Type type) {
            switch (type.Name) {
            case "IntroScreen":
                return new IntroScreen (_graphics, _spriteBatch);
            default:
                throw new Exception (string.Format ("State {0} not found",
                                                  type));
            }
        }
    }
}
