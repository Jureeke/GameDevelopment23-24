using System.Collections.Generic;
using System.Linq;
using Testproject.Map;
using Testproject.Map.Tiles;
using Microsoft.Xna.Framework;
using Testproject.Core.GameStates;
using GameDevProject.Core;
using Testproject.Core.Enemy;
using System.Diagnostics;

namespace Testproject.Core
{
    public class HeroCollisionManager
    {
        private Hero _character;
        private MapManager _mapManager;

        public HeroCollisionManager(Hero character)
        {
            _character = character;
        }

        public void Update(GameTime time)
        {
            // Check collisions with terrain
            List<TileBase> collidedTiles = _mapManager.FindAllCollissionsWithMap(_character.HitBox);
            HandleTerrainCollisions(collidedTiles, time);

            // Check collisions with enemies
            List<IEnemy> collidedEnemies = _mapManager.FindAllCollissionsWithEnemy(_character.HitBox);
            HandleEnemyCollisions(collidedEnemies);

            // Check collisions with coins
            List<Coin> collidedCoins = _mapManager.FindAllCollissionsWithCoins(_character.HitBox);
            HandleCoinCollisions(collidedCoins);

            // Check collisions with spikes
            List<TileBase> collidedSpikes = _mapManager.FindAllCollissionsWithSpikes(_character.HitBox);
            HandleSpikeCollisions(collidedSpikes);
        }

        private void HandleTerrainCollisions(List<TileBase> collidedTiles, GameTime time)
        {
            foreach (var tile in collidedTiles)
            {
                if (_character.HitBox.Intersects(tile.HitBox))
                {
                    // Check if the hero is falling and hits the top of a block
                    if (_character.Speed.Y > 0 && _character.Position.Y < tile.HitBox.Top)
                    {
                        _character.Position = new Vector2(_character.Position.X, tile.HitBox.Top - _character.HitBox.Height);
                        _character.Speed = new Vector2(_character.Speed.X, 0);
                        _character.isJumping = false;  // Stop the jump
                    }
                }
            }
        }

        private void HandleEnemyCollisions(List<IEnemy> collidedEnemies)
        {
            foreach (var enemy in collidedEnemies)
            {
                if (_character.HitBox.Intersects(enemy.HitBox))
                {
                    Debug.WriteLine("hit enemy");
                }
            }
        }

        private void HandleCoinCollisions(List<Coin> collidedCoins)
        {
            foreach (var coin in collidedCoins)
            {
                coin.PickUp();
            }
        }

        private void HandleSpikeCollisions(List<TileBase> collidedSpikes)
        {
            Debug.WriteLine("hit spike");
        }

        public void lateSetup()
        {
            _mapManager = _character._game.MapManager;
        }
    }
}
