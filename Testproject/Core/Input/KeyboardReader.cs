using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace GameDevProject.Core.Input
{
    internal class KeyboardReader : IInputReader
    {
        public Vector2 Readinput()
        {
            KeyboardState state = Keyboard.GetState();
            Vector2 direction = Vector2.Zero;
            if (state.IsKeyDown(Keys.Left) || state.IsKeyDown(Keys.Q))
            {
                direction.X -= 1;
            }
            if (state.IsKeyDown(Keys.Right) || state.IsKeyDown(Keys.D))
            {
                direction.X += 1;
            }
            if (state.IsKeyDown(Keys.Space))
            {
                direction.Y -= 1;
            }

            return direction;
        }

        public bool IsSpecialActionTriggered()
        {
            return Keyboard.GetState().IsKeyDown(Keys.V);
        }
    }
}
