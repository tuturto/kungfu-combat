#region Using Statements
using System;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Storage;

using Octo;

#endregion

namespace KungfuCombat
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Main : Game
    {
        public Main()
        {
            _graphics = new GraphicsDeviceManager(this);
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            Content.RootDirectory = "Content";                
            _graphics.IsFullScreen = false;
        }

        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        private IStateCache _stateCache;
        private IGameState _state;

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            _stateCache = new StateCache (new StateFactory (_graphics, 
                                                            _spriteBatch));
            _state = _stateCache.GetState (typeof (IntroScreen));
            _state.StateChangeEvent += new EventHandler (StateChangeRequested);

            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            //TODO: use this.Content to load your game content here 
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            _state.Update (gameTime);
            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            _state.Draw (gameTime);
            base.Draw(gameTime);
        }

        protected void StateChangeRequested(object sender, EventArgs e) {
            _state.StateChangeEvent -= StateChangeRequested;
            //TODO: implement
            _state = _stateCache.GetState (typeof (IntroScreen));
            _state.StateChangeEvent += new EventHandler (StateChangeRequested);
        }
    }
}
