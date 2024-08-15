using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Testproject.Map.Tiles
{
    public class Tile
    {
        private int _x;
        private int _y;
        private int _w;
        private int _h;
        private Texture2D _texture;
        private Rectangle _offsetRectangle;

        public bool IsTransparent = false;


        public Tile(int x, int y, int width, int height, Texture2D texture, Rectangle offsetRectangle, bool transparent = false)
        {
            _x = x;
            _y = y;
            _w = width;
            _h = height;
            _texture = texture;
            _offsetRectangle = offsetRectangle;
            IsTransparent = transparent;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(_texture, new Rectangle(_x, _y, _w, _h), _offsetRectangle, Color.White);
        }
    }
}
