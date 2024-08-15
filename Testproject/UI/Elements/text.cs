using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace Testproject.UI.Elements
{
    public class Text : IGameObject
    {
        private string _text;
        private Vector2 _location;
        private SpriteFont _font;
        private float _scale;
        private Color _color;
        private float _layerDepth;

        public string Value
        {
            get => _text;
            set => _text = value;
        }

        public Vector2 Location
        {
            get => _location;
            set => _location = value;
        }

        public SpriteFont Font
        {
            get => _font;
            set => _font = value;
        }

        public float Scale
        {
            get => _scale;
            set => _scale = Math.Max(0, value); // Ensure scale is non-negative
        }

        public Color Color
        {
            get => _color;
            set => _color = value;
        }

        public float LayerDepth
        {
            get => _layerDepth;
            set => _layerDepth = value;
        }

        public Text(string text, Vector2 position, SpriteFont font, float scale = 1, Color? color = null, float layerDepth = 0.5f)
        {
            _text = text;
            _location = position;
            _font = font;
            _scale = Math.Max(0, scale); // Ensure scale is non-negative
            _color = color ?? Color.White;
            _layerDepth = layerDepth;
        }

        public void Update(GameTime time)
        {
            // Not used
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            Vector2 textMiddlePoint = _font.MeasureString(_text) / 2;
            spriteBatch.DrawString(_font, _text, _location, _color, 0, textMiddlePoint, _scale, SpriteEffects.None, _layerDepth);
        }
    }

}
