using System;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Octo
{
    public class OctoGame : Game {

        public OctoGame() {
            _graphics = new GraphicsDeviceManager(this);
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            Content.RootDirectory = "Content";                
        }

        protected GraphicsDeviceManager _graphics;
        protected SpriteBatch _spriteBatch;
        protected IStateCache _stateCache;
        protected IGameState _state;

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize() {
            _state.StateChangeEvent += new StateChangeEventHandler (StateChangeRequested);

            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent() {
            //TODO: use this.Content to load your game content here 
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime) {
            _state.Update (gameTime);
            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime) {
            _state.Draw (gameTime);
            base.Draw(gameTime);
        }

        /// <summary>
        /// Handle changing states
        /// </summary>
        /// <param name="sender">state requesting the change</param>
        /// <param name="e">new state to change into</param>
        protected virtual void StateChangeRequested(object sender, StateChangeEventArgs e) {
            _state.StateChangeEvent -= StateChangeRequested;
            _state = _stateCache.GetState (e.State);
            _state.StateChangeEvent += new StateChangeEventHandler (StateChangeRequested);
        }
    }
}
