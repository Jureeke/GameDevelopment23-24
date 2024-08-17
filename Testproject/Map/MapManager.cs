using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using Testproject.Map.Levels;
using Testproject.Map.Tiles;

namespace Testproject.Map
{
    public class MapManager
    {
        private readonly GameManager _game;
        private readonly int _horizontalTiles = 20;
        private readonly int _verticalTiles = 12;
        public readonly int TileWidth;
        public readonly int TileHeight;
        private readonly List<Tile> _tiles = new();
        private readonly TileFactory _tileFactory;
        public readonly List<ILevel> _levels = new();
        public ILevel ActiveLevel;

        public MapManager(GameManager game)
        {
            _game = game;
            _tileFactory = new TileFactory(_game);

            TileWidth = _game.RootGame.GraphicsDeviceManager.PreferredBackBufferWidth / _horizontalTiles;
            TileHeight = _game.RootGame.GraphicsDeviceManager.PreferredBackBufferHeight / _verticalTiles;
        }

        public void Setup()
        {
            // Registering levels
            _levels.Add(new Level1(_game));
            _levels.Add(new Level2(_game));

            // Setting the initial active level
            ActiveLevel = _levels[0];
        }

        public void CreateLevelMap()
        {
            // Clear existing tiles and objects
            _tiles.Clear();

            // Generate tile map
            for (int y = 0; y < _verticalTiles; y++)
            {
                for (int x = 0; x < _horizontalTiles; x++)
                {
                    int xOffset = x * TileWidth;
                    int yOffset = y * TileHeight;

                    TileMap.Tiles? tile = ActiveLevel.GameMap[y, x];
                    if (tile.HasValue)
                    {
                        _tiles.Add(_tileFactory.CreateTile(tile.Value, xOffset, yOffset));
                    }
                }
            }
        }

        public void LoadMapParameters()
        {
            // Additional setup for the level
        }

        public void RenderMap(SpriteBatch batch)
        {
            // Background
            batch.Draw(ActiveLevel.Background, new Rectangle(0, 0, _game.RootGame.GraphicsDeviceManager.PreferredBackBufferWidth, _game.RootGame.GraphicsDeviceManager.PreferredBackBufferHeight), Color.White);

            // Tiles
            foreach (var tile in _tiles)
            {
                tile.Draw(batch);
            }

            // Draw enemies or other level-specific objects
            foreach (var enemy in ActiveLevel.Enemies)
            {
                enemy.Draw(batch); // Teken alle vijanden van het actieve niveau
            }
        }

        public void Update(GameTime time)
        {
            // Update level-specific objects
            foreach (var enemy in ActiveLevel.Enemies)
            {
                enemy.Update(time); // Werk alle vijanden van het actieve niveau bij
            }
        }

        public void GoToNextLevel()
        {
            Debug.Write(_levels.Count);
            ILevel nextLevel = _levels[1];
            ActiveLevel = nextLevel;

            CreateLevelMap(); // Render map tiles again
            LoadMapParameters(); // Other misc stuff
        }
    }
}
