using Microsoft.Xna.Framework.Graphics;
using Testproject.Utility.StateMachine;

namespace Testproject.Core.GameStates
{
    public abstract class GameState : State
    {
        public virtual void OnDraw(SpriteBatch batch) { }
    }
}
