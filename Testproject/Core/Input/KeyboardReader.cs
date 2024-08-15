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
            if (state.IsKeyDown(Keys.Up) || state.IsKeyDown(Keys.Z))
            {
                direction.Y -= 1;
            }
            if (state.IsKeyDown(Keys.Down) || state.IsKeyDown(Keys.S))
            {
                direction.Y += 1;
            }
            return direction;
        }
    }
}
