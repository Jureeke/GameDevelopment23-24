using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Testproject.UI;

namespace Testproject.Core.GameStates
{
    public class WinningState : GameState
    {
        private WinScreen _screen;
        private GameManager _game;

        public WinningState(GameManager game)
        {
            _game = game;
            _screen = new WinScreen(_game);
        }

        protected override void OnActivate()
        {
            _game.SoundManager.PlayBackgroundMusic("Victory");
        }

        protected override void OnDeactivate()
        {
            _game.SoundManager.StopBackgroundMusic();
        }

        public override void OnUpdate(GameTime time)
        {
            _screen.Update(time);
        }

        public override void OnDraw(SpriteBatch batch)
        {
            _screen.Draw(batch);
        }
    }
}
