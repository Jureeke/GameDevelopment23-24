using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
