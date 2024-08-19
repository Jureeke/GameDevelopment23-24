using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using Testproject.Utility.Collision;

namespace Testproject.Map.Tiles
{
    public class TileBase : ICollidable
    {
        private int _x;
        private int _y;
        private int _w;
        private int _h;
        private Texture2D _texture;
        private Rectangle _offsetRectangle;

        public bool IsTransparent { get; private set; }
        public Rectangle HitBox { get; set; }
        public SlopeOrientation Orientation { get; private set; }
        public Vector2[] SlopePoints { get; private set; }

        private static Texture2D _hitboxTexture;

        public enum SlopeOrientation
        {
            TopLeftToBottomRight,
            BottomLeftToTopRight,
            None
        }

        public TileBase(int x, int y, int width, int height, Texture2D texture, Rectangle offsetRectangle, SlopeOrientation orientation, bool transparent = false)
        {
            _x = x;
            _y = y;
            _w = width;
            _h = height;
            _texture = texture;
            _offsetRectangle = offsetRectangle;
            IsTransparent = transparent;
            Orientation = orientation;

            if (_hitboxTexture == null)
            {
                _hitboxTexture = new Texture2D(texture.GraphicsDevice, 1, 1);
                _hitboxTexture.SetData(new[] { Color.Red });
            }

            HitBox = new Rectangle(_x, _y, _w, _h);
            SetSlopePoints(orientation);
        }

        public void SetSlopePoints(SlopeOrientation orientation)
        {
            Orientation = orientation;
            switch (orientation)
            {
                case SlopeOrientation.TopLeftToBottomRight:
                    SlopePoints = new[]
                    {
                        new Vector2(_x, _y),
                        new Vector2(_x + _w, _y + _h)
                    };
                    break;

                case SlopeOrientation.BottomLeftToTopRight:
                    SlopePoints = new[]
                    {
                        new Vector2(_x, _y + _h),
                        new Vector2(_x + _w, _y)
                    };
                    break;

                case SlopeOrientation.None:
                    SlopePoints = null;
                    break;
            }
        }

        public void Draw(SpriteBatch spriteBatch, bool debugMode = true)
        {
            // Draw the tile
            spriteBatch.Draw(_texture, new Rectangle(_x, _y, _w, _h), _offsetRectangle, Color.White);

            if (debugMode)
            {
                DrawRectangleOutline(spriteBatch, HitBox, Color.Red);
            }
        }

        private void DrawLine(SpriteBatch spriteBatch, Vector2 point1, Vector2 point2, Color color)
        {
            float distance = Vector2.Distance(point1, point2);
            float angle = (float)Math.Atan2(point2.Y - point1.Y, point2.X - point1.X);

            spriteBatch.Draw(_hitboxTexture,
                             point1,
                             null,
                             color,
                             angle,
                             Vector2.Zero,
                             new Vector2(distance, 1),
                             SpriteEffects.None,
                             0);
        }

        private void DrawRectangleOutline(SpriteBatch spriteBatch, Rectangle rectangle, Color color)
        {
            DrawLine(spriteBatch, new Vector2(rectangle.Left, rectangle.Top), new Vector2(rectangle.Right, rectangle.Top), color);
            DrawLine(spriteBatch, new Vector2(rectangle.Right, rectangle.Top), new Vector2(rectangle.Right, rectangle.Bottom), color);
            DrawLine(spriteBatch, new Vector2(rectangle.Right, rectangle.Bottom), new Vector2(rectangle.Left, rectangle.Bottom), color);
            DrawLine(spriteBatch, new Vector2(rectangle.Left, rectangle.Bottom), new Vector2(rectangle.Left, rectangle.Top), color);
        }
    }
}
