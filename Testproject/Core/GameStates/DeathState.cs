using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Testproject.UI;

namespace Testproject.Core.GameStates
{
    public class DeathState : GameState
    {
        private DeathScreen _screen;
        private GameManager _game;

        public DeathState(GameManager game)
        {
            _game = game;
            _screen = new DeathScreen(_game);
        }

        protected override void OnActivate()
        {
            _game.SoundManager.PlayBackgroundMusic("GameOver");
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
