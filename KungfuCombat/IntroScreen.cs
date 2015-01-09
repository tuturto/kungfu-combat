using System;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

using Octo;

namespace KungfuCombat {

    public class IntroScreen : IGameState {

        public IntroScreen(GraphicsDeviceManager graphics,
                           SpriteBatch spriteBatch) {
            _graphics = graphics;
            _spriteBatch = spriteBatch;
        }

        private readonly GraphicsDeviceManager _graphics;
        private readonly SpriteBatch _spriteBatch;

        object objectLock = new object();

        private event StateChangeEventHandler OnStateChange;

        public event StateChangeEventHandler StateChangeEvent {
            add {
                lock (objectLock) {
                    OnStateChange += value;
                }
            }
            remove {
                lock (objectLock) {
                    OnStateChange -= value;
                }
            }
        }

        /// <summary>
        /// run game logic for this state
        /// </summary>
        /// <param name="gameTime">Game time.</param>
        public void Update(GameTime gameTime) {
            //TODO: implement

            if (OnStateChange != null) {
                OnStateChange (this, new StateChangeEventArgs (typeof (IntroScreen)));
            }
        }

        /// <summary>
        /// Draw the state on screen
        /// </summary>
        /// <param name="gameTime">Game time.</param>
        public void Draw(GameTime gameTime) {
            _graphics.GraphicsDevice.Clear(Color.CornflowerBlue);

            //TODO: implement
        }

        /// <summary>
        /// Load content relevant to this state
        /// </summary>
        public void LoadContent() {
            //TODO: implement
            ContentLoaded = true;
        }

        private bool _contentLoaded = false;
        /// <summary>
        /// Gets a value indicating whether content for this state has been loaded
        /// </summary>
        /// <value><c>true</c> if content loaded; otherwise, <c>false</c>.</value>
        public bool ContentLoaded { 
            get {
                return _contentLoaded;
            }
            private set {
                _contentLoaded = value;
            }
        }
    }
}
