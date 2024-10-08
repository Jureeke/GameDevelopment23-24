﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using Testproject.Core.Enemy;
using Testproject.Map.Levels;
using Testproject.Map.Tiles;

namespace Testproject.Map
{
    public class MapManager
    {
        private readonly GameManager _game;
        private readonly int _horizontalTiles = 20;
        private readonly int _verticalTiles = 12;
        public readonly int TileWidth = 64;
        public readonly int TileHeight = 64;

        private readonly List<Coin> _coins = new();
        private readonly List<TileBase> _tiles = new();

        public List<IEnemy> _enemies = new();

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
            _coins.Clear();

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
                        if (tile.Value == TileMap.Tiles.COIN_BASE)
                        {
                            // Instantiate and add the coin to the list
                            Coin coin = new Coin(xOffset, yOffset, _game);
                            _coins.Add(coin);
                        }
                        else
                        {
                            _tiles.Add(_tileFactory.CreateTile(tile.Value, xOffset, yOffset));
                        }
                    }
                }
            }
        }

        public void LoadMapParameters()
        {
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

            foreach (var coin in _coins)
            {
                coin.Draw(batch);
            }
        }

        public void Update(GameTime time)
        {
            // Update level-specific objects
            foreach (var enemy in ActiveLevel.Enemies)
            {
                enemy.Update(time); // Werk alle vijanden van het actieve niveau bij

            }
            foreach (var coin in _coins)
            {
                coin.Update(time);
            }
        }

#nullable enable
        public TileBase? CollidesWithTerrain(Rectangle hitbox)
        {
            return _tiles.Find(tile => !tile.IsTransparent && tile.HitBox.Intersects(hitbox));
        }
        public List<TileBase> FindAllCollissionsWithMap(Rectangle hitbox)
        {
            // Find all tiles that intersect with the given hitbox
            List<TileBase> collidedTiles = _tiles.FindAll(tile => tile.HitBox.Intersects(hitbox));

            return collidedTiles;
        }

        public List<IEnemy> FindAllCollissionsWithEnemy(Rectangle hitbox, List<IEnemy> enemies)
        {
            return enemies.FindAll(enemy => enemy.HitBox.Intersects(hitbox));
        }
        public List<Coin> FindAllCollissionsWithCoins(Rectangle hitbox)
        {
            return _coins.FindAll(coin => coin.HitBox.Intersects(hitbox));
        }

        public void GoToNextLevel()
        {
            ILevel nextLevel = _levels[1];
            ActiveLevel = nextLevel;

            CreateLevelMap(); // Render map tiles again
            LoadMapParameters();
        }

        public void RestartLevel()
        {
            // Clear existing tiles, coins, and enemies
            _tiles.Clear();
            _coins.Clear();

            // Reinitialize the current active level
            if (ActiveLevel != null)
            {
                // Recreate the map for the active level
                CreateLevelMap();

                // Optionally, reset the level parameters if needed
                LoadMapParameters();
                _game.hero.ResetPosition(ActiveLevel.spawnpoint);

            }
        }
    }
}

    