using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Testproject.Utility.StateMachine;

namespace Testproject.Core.GameStates
{
    public abstract class GameState : State
    {
        public virtual void OnDraw(SpriteBatch batch) { }
    }
}
