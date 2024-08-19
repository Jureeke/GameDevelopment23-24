using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
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
        private static Texture2D _hitboxTexture;
        public TileMap.Tiles type;

        public TileBase(TileMap.Tiles type, int x, int y, int width, int height, Texture2D texture, Rectangle offsetRectangle, bool transparent = false)
        {
            _x = x;
            _y = y;
            _w = width;
            _h = height;
            _texture = texture;
            _offsetRectangle = offsetRectangle;
            IsTransparent = transparent;

            this.type = type; // Set the tile type

            if (type == TileMap.Tiles.SPIKE_3)
            {
                HitBox = new Rectangle(_x, _y + _h / 2, _w, _h / 2);
            }
            else if (!transparent)
            {
                HitBox = new Rectangle(_x, _y, _w, _h);
            }
        }


        public void Draw(SpriteBatch spriteBatch)
        {
            // Draw the tile
            spriteBatch.Draw(_texture, new Rectangle(_x, _y, _w, _h), _offsetRectangle, Color.White);

        }
    }
}
