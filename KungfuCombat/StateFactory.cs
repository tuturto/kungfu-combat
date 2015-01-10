using System;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

using Octo;

namespace KungfuCombat {

    public class StateFactory : IStateFactory {

        public StateFactory(GraphicsDeviceManager graphics,
                            SpriteBatch spriteBatch,
                            ContentManager content) {
            _graphics = graphics;
            _spriteBatch = spriteBatch;
            _content = content;
        }

        private readonly GraphicsDeviceManager _graphics;
        private readonly SpriteBatch _spriteBatch;
        private readonly ContentManager _content;

        public IGameState CreateState(Type type) {
            switch (type.Name) {
            case "IntroScreen":
                return new IntroScreen (_graphics, _spriteBatch, _content);
            case "MainMenu":
                return new MainMenu (_graphics, _spriteBatch, _content);
            default:
                throw new Exception (string.Format ("State {0} not found",
                                                  type));
            }
        }
    }
}
