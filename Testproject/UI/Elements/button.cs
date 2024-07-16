using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Testproject.UI.Elements
{
    public class Button : IGameObject
    {
        private Text _buttonText;
        private Texture2D _buttonTexture;

        private Vector2 _stringDimensions;
        private Rectangle _buttonRectangle;

        private Color _defaultColor;
        private Color _hoverColor;
        private Color _clickColor;
        private Color _currentColor;

        public event EventHandler Click;

        public Button(string text, Vector2 position, SpriteFont font, Texture2D buttonTexture, EventHandler callback, float scale = 1, Color? defaultColor = null, Color? hoverColor = null, Color? clickColor = null)
        {
            _buttonText = new Text(text, position, font, scale);
            _buttonTexture = buttonTexture;

            // Calculate the rectangle width and height by measuring the text
            _stringDimensions = font.MeasureString(text);

            int buttonWidth = (int)(_stringDimensions.X * scale) + 40;
            int buttonHeight = (int)(_stringDimensions.Y * scale) + 40;

            _buttonRectangle = new Rectangle((int)(position.X - buttonWidth / 2), (int)(position.Y - buttonHeight / 2), buttonWidth, buttonHeight);

            _defaultColor = defaultColor ?? Color.Gray;
            _hoverColor = hoverColor ?? Color.LightGray;
            _clickColor = clickColor ?? Color.DarkGray;
            _currentColor = _defaultColor;

            Click += callback;
        }

        public void Update(GameTime time)
        {
            MouseState mouseState = Mouse.GetState();
            Point mousePosition = mouseState.Position;

            if (_buttonRectangle.Contains(mousePosition))
            {
                if (mouseState.LeftButton == ButtonState.Pressed)
                {
                    _currentColor = _clickColor;
                    Click?.Invoke(this, EventArgs.Empty);
                }
                else
                {
                    _currentColor = _hoverColor;
                }
            }
            else
            {
                _currentColor = _defaultColor;
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(_buttonTexture, _buttonRectangle, _currentColor);
            _buttonText.Draw(spriteBatch);
        }
    }

}
