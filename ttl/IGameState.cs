using System;

using Microsoft.Xna.Framework;

namespace Octo
{
    /// <summary>
    /// Represents state of the game
    /// 
    /// Handles controls, runs game logic, draws screen
    /// </summary>
    public interface IGameState
    {
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
    }
}
