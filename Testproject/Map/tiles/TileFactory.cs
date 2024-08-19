using Microsoft.Xna.Framework.Graphics;
using System.Linq;
using Testproject.Map;
using Testproject.Map.Tiles;

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

    public TileBase CreateTile(TileMap.Tiles type, int x, int y)
    {
        if (type == TileMap.Tiles.TOP_SL_3) //left
        {
            return new TileBase(x, y, _game.MapManager.TileWidth, _game.MapManager.TileHeight, _tileMapTexture, _tileMap.GetSubRectangleForTile(type), TileBase.SlopeOrientation.BottomLeftToTopRight, TransparentTiles.Contains(type));
        }
        else if (type == TileMap.Tiles.TOP_SR_3) //right
        {
            return new TileBase(x, y, _game.MapManager.TileWidth, _game.MapManager.TileHeight, _tileMapTexture, _tileMap.GetSubRectangleForTile(type), TileBase.SlopeOrientation.TopLeftToBottomRight, TransparentTiles.Contains(type));
        }
        else
        {
            return new TileBase(x, y, _game.MapManager.TileWidth, _game.MapManager.TileHeight, _tileMapTexture, _tileMap.GetSubRectangleForTile(type), TileBase.SlopeOrientation.None, TransparentTiles.Contains(type));
        }
    }
}
