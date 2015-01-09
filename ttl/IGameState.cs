using System;

using Microsoft.Xna.Framework;

namespace Octo {

    /// <summary>
    /// Represents state of the game
    /// 
    /// Handles controls, runs game logic, draws screen
    /// </summary>
    public interface IGameState {
        /// <summary>
        /// run game logic for this state
        /// </summary>
        /// <param name="gameTime">Game time.</param>
        void Update(GameTime gameTime);

        /// <summary>
        /// Draw the state on screen
        /// </summary>
        /// <param name="gameTime">Game time.</param>
        void Draw(GameTime gameTime);

        /// <summary>
        /// Load content relevant to this state
        /// </summary>
        void LoadContent();

        /// <summary>
        /// Gets a value indicating whether content for this state has been loaded
        /// </summary>
        /// <value><c>true</c> if content loaded; otherwise, <c>false</c>.</value>
        bool ContentLoaded { get; }

        event StateChangeEventHandler StateChangeEvent;
    }

    public class StateChangeEventArgs : EventArgs {

        public StateChangeEventArgs(Type state) {
            _state = state;
        }

        protected readonly Type _state;

        public Type State {
            get { return _state; }
        }
    }

    public delegate void StateChangeEventHandler(object sender, StateChangeEventArgs e);
}
