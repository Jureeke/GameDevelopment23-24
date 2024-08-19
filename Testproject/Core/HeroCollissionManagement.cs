using GameDevProject.Core;
using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Testproject.Core.Enemy;
using Testproject.Map;
using Testproject.Map.Tiles;

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
        List<IEnemy> collidedEnemies = _mapManager.FindAllCollissionsWithEnemy(_character.HitBox, _mapManager.ActiveLevel.Enemies);
        HandleEnemyCollisions(collidedEnemies);

        // Check collisions with coins
        List<Coin> collidedCoins = _mapManager.FindAllCollissionsWithCoins(_character.HitBox);
        HandleCoinCollisions(collidedCoins);


    }


    private void HandleTerrainCollisions(List<TileBase> collidedTiles, GameTime time)
    {
        bool spikeHit = false;  // Flag to track if a spike has already been hit

        foreach (var tile in collidedTiles)
        {
            if (tile.type == TileMap.Tiles.SPIKE_3 && !spikeHit)
            {
                _character.Lives--;
                _mapManager.RestartLevel();
                spikeHit = true;  // Set the flag after the first spike hit

                if (_mapManager.ActiveLevel == _mapManager._levels[0])
                {
                    _character._game.score = 0;
                }
                else if (_mapManager.ActiveLevel == _mapManager._levels[1])
                {
                    _character._game.score = 4;
                }
            }

            if (_character.HitBox.Intersects(tile.HitBox))
            {
                // Check if the hero is falling and hits the top of a block
                if (_character.Speed.Y > 0 && _character.Position.Y < tile.HitBox.Top)
                {
                    _character.Position = new Vector2(_character.Position.X, tile.HitBox.Top - _character.HitBox.Height - 27);
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
                _character.Lives--;
                _mapManager.RestartLevel();

                if (_mapManager.ActiveLevel == _mapManager._levels[0])
                {
                    _character._game.score = 0;

                }
                if (_mapManager.ActiveLevel == _mapManager._levels[1])
                {
                    _character._game.score = 4;

                }
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

    public void lateSetup()
    {
        _mapManager = _character._game.MapManager;
    }
}
