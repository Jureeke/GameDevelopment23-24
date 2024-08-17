using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using Testproject.Core.Enemy;

namespace Testproject.Map.Levels
{
    public interface ILevel
    {
        public TileMap.Tiles?[,] GameMap { get; set; }
        public Texture2D Background { get; set; }
        public List<Enemy> Enemies { get; set; }
        public void Draw(SpriteBatch spriteBatch);
        public void Update(GameTime gameTime);
    }
}
