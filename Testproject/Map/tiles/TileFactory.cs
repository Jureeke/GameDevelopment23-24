using Microsoft.Xna.Framework.Graphics;
using System;
using System.Linq;

namespace Testproject.Map.Tiles
{
    public class TileFactory
    {
        private GameManager _game;
        private Texture2D _tileMapTexture;
        private TileMap _tileMap;

        public TileMap.Tiles[] TransparentTiles = new[]
        {
            TileMap.Tiles.GRASS
        };
        public TileFactory(GameManager game)
        {
            _game = game;
            _tileMapTexture = _game.RootGame.Content.Load<Texture2D>("Tiles_4x");
            _tileMap = new TileMap(_tileMapTexture);
        }

        public Tile CreateTile(TileMap.Tiles type, int x, int y)
        {
            return new Tile(x, y, _game.MapManager.TileWidth, _game.MapManager.TileHeight, _tileMapTexture, _tileMap.GetSubRectangleForTile(type), TransparentTiles.Contains(type));
        }
    }
}
