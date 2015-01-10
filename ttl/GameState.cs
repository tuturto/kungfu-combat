using System;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Octo
{
    public abstract class GameState : IGameState
    {
        public GameState(GraphicsDeviceManager graphics,
                         SpriteBatch spriteBatch,
                         ContentManager content) {
            Graphics = graphics;
            Sprites = spriteBatch;
            Content = content;
        }

        public GraphicsDeviceManager Graphics { get; private set; }
        public SpriteBatch Sprites { get; private set; }
        public ContentManager Content { get; private set; }

        object objectLock = new object();

        private event StateChangeEventHandler RaiseStateChange;

        public event StateChangeEventHandler StateChangeEvent {
            add {
                lock (objectLock) {
                    RaiseStateChange += value;
                }
            }
            remove {
                lock (objectLock) {
                    RaiseStateChange -= value;
                }
            }
        }

        public virtual void OnStateChange(object sender, StateChangeEventArgs e) {
            RaiseStateChange (sender, e);
        }

        /// <summary>
        /// Perform initialization for this state
        /// 
        /// This is called every time the state is entered
        /// </summary>
        public abstract void Initialize ();

        /// <summary>
        /// run game logic for this state
        /// </summary>
        /// <param name="gameTime">Game time.</param>
        public abstract void Update (GameTime gameTime);

        /// <summary>
        /// Draw the state on screen
        /// </summary>
        /// <param name="gameTime">Game time.</param>
        public abstract void Draw (GameTime gameTime);

        /// <summary>
        /// Load content relevant to this state
        /// </summary>
        public virtual void LoadContent () {
            ContentLoaded = true;
        }

        /// <summary>
        /// Gets a value indicating whether content for this state has been loaded
        /// </summary>
        /// <value><c>true</c> if content loaded; otherwise, <c>false</c>.</value>
        public bool ContentLoaded { get; protected set; }
    }
}
