using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Testproject.Map;

namespace Testproject.Map.Levels
{
    public interface ILevel
    {
        public TileMap.Tiles?[,] GameMap { get; set; }
        public Vector2 SpawnLocation { get; set; }
        public Texture2D Background { get; set; }
    }
}
