using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;

namespace Testproject.UI.Elements
{
    public class Button
    {
        private Text _buttonText;
        private Texture2D _buttonTexture;

        private Vector2 _stringDimensions;
        private Rectangle _buttonRectangle;

        private ButtonPressed _callback;

        public delegate void ButtonPressed();
        public Button(String text, Vector2 position, SpriteFont font, Texture2D buttonTexture, ButtonPressed callback, float scale = 1)
        {
            _buttonText = new Text(text, position, font, scale);
            _buttonTexture = buttonTexture;

            // Calculate the rectangle width and height by measuring our text
            _stringDimensions = font.MeasureString(text);

            int buttonWidth = (int)(_stringDimensions.X * scale) + 40;
            int buttonHeight = (int)(_stringDimensions.Y * scale) + 40;

            _buttonRectangle = new Rectangle((int)(position.X - buttonWidth / 2), (int)(position.Y - buttonHeight / 2), buttonWidth,
                buttonHeight);

            _callback = callback;
        }

        public void Update(GameTime time)
        {
            if (Mouse.GetState().LeftButton == ButtonState.Pressed)
            {
                if (_buttonRectangle.Contains(Mouse.GetState().Position))
                {
                    _callback();
                }
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(_buttonTexture, _buttonRectangle, Color.Gray);
            _buttonText.Draw(spriteBatch);
        }
    }
}
