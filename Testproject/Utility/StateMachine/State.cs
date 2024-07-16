using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Testproject.Utility.StateMachine
{
    public abstract class State : IState
    {
        protected Game1 game;
        protected GameManager gameManager;

        public State(Game1 game, GameManager gameManager)
        {
            this.game = game;
            this.gameManager = gameManager;
        }

        public abstract void Enter();
        public abstract void Exit();
        public abstract void Update(GameTime gameTime);
        public abstract void Draw(GameTime gameTime);
    }

}
