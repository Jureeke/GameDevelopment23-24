using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Testproject.Utility.StateMachine
{
    public interface IState
    {
        void Enter();
        void Exit();
        void Update(GameTime gameTime);
        void Draw(GameTime gameTime);
    }
}

