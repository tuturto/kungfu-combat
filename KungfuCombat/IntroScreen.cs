using System;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Content;

using Octo;

namespace KungfuCombat {

    public class IntroScreen : GameState {

        public IntroScreen(GraphicsDeviceManager graphics,
                           SpriteBatch spriteBatch,
                           ContentManager content) 
                : base(graphics, spriteBatch, content) {
        }

        private Texture2D _titleTexture;
        private Vector2 _titleLocation;

        /// <summary>
        /// Perform initialization for this state
        /// </summary>
        public override void Initialize() {
            _titleLocation = new Vector2(1024 / 2, 0);
        }

        /// <summary>
        /// run game logic for this state
        /// </summary>
        /// <param name="gameTime">Game time.</param>
        public override void Update(GameTime gameTime) {

            if (_titleLocation.Y < 768 / 2) {
                _titleLocation.Y = _titleLocation.Y + 5f;
            } else {
                OnStateChange (this, new StateChangeEventArgs (typeof (IntroScreen)));
            }
        }

        /// <summary>
        /// Draw the state on screen
        /// </summary>
        /// <param name="gameTime">Game time.</param>
        public override void Draw(GameTime gameTime) {
            Graphics.GraphicsDevice.Clear(Color.Black);

            Sprites.Begin ();

            var loc = new Vector2 (_titleLocation.X - _titleTexture.Width / 2,
                                  _titleLocation.Y - _titleTexture.Height / 2);

            Sprites.Draw (_titleTexture,
                               loc,
                               Color.White);

            Sprites.End ();
        }

        /// <summary>
        /// Load content relevant to this state
        /// </summary>
        public override void LoadContent() {

            _titleTexture = Content.Load<Texture2D> ("title.png");

            base.LoadContent ();
        }
    }
}
