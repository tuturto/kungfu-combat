#region Using Statements
using System;

using Octo;

#endregion

namespace KungfuCombat
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Main : OctoGame {

        public Main() : base () {

        }

        protected override void Initialize() {
            _stateCache = new StateCache (new StateFactory (_graphics, 
                                                            _spriteBatch,
                                                            Content));
            _state = _stateCache.GetState (typeof (IntroScreen));

            Window.Title = "Kungfu Combat";
            _graphics.IsFullScreen = false;
            _graphics.PreferredBackBufferWidth = 1024;
            _graphics.PreferredBackBufferHeight = 768;
            _graphics.ApplyChanges ();

            base.Initialize ();
        }
    }
}
