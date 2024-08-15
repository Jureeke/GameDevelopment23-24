using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Testproject.UI;

namespace Testproject.Core.GameStates
{
    public class MainMenuState : GameState
    {
        private StartScreen _screen;
        private GameManager _game;

        public MainMenuState(GameManager game)
        {
            _game = game;
            _screen = new StartScreen(_game);
        }
        protected override void OnActivate()
        {

        }

        protected override void OnDeactivate()
        {

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
