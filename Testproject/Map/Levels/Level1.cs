using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using Testproject.Core.Enemy;

namespace Testproject.Map.Levels
{
    public class Level1 : ILevel
    {
        private GameManager _game;

        public Animation _coinAnimation;
        public Texture2D _coinTexture;

        #region Tile Definitions
        private const TileMap.Tiles Coin = TileMap.Tiles.COIN_BASE;
        private const TileMap.Tiles Grass = TileMap.Tiles.GRASS;
        private const TileMap.Tiles Spikes = TileMap.Tiles.SPIKE_3;

        private const TileMap.Tiles BL = TileMap.Tiles.BOTTOM_LEFT;
        private const TileMap.Tiles BM = TileMap.Tiles.BOTTOM_MIDDLE;
        private const TileMap.Tiles BR = TileMap.Tiles.BOTTOM_RIGHT;

        private const TileMap.Tiles TL = TileMap.Tiles.TOP_GCL;
        private const TileMap.Tiles TM = TileMap.Tiles.TOP_GCM;
        private const TileMap.Tiles TR = TileMap.Tiles.TOP_GCR;

        private const TileMap.Tiles PLS = TileMap.Tiles.PLAT_SINGLE;
        private const TileMap.Tiles PLL = TileMap.Tiles.PLAT_L;
        private const TileMap.Tiles PLM = TileMap.Tiles.PLAT_M;
        private const TileMap.Tiles PLR = TileMap.Tiles.PLAT_R;


        #endregion

        public TileMap.Tiles?[,] GameMap { get; set; } =
        {
            {null,null,null,null,null,null,null,null,null,null,null,null,null,null,null,null,null,null,null,null },
            {null,null,null,null,null,null,null,null,null,null,null,null,null,null,null,null,null,null,null,null },
            {null,null,null,null,null,null,null,null,null,null,null,null,Coin,Grass,null,null,null,null,null,null },
            {null,null,null,null,null,null,null,null,PLL,PLM,PLM,PLM,PLM,PLM,PLR,null,null,null,null,null },
            {null,null,Grass,Coin,null,null,null,null,null,null,null,null,null,null,null,null,null,null,null,null },
            {null,PLL,PLM,PLM,PLR,null,null,null,null,null,null,null,null,null,null,null,null,null,null,null },
            {null,null,null,null,null,null,null,null,PLL,PLM,PLR,null,null,PLL,PLM,PLR,null,null,null,null },
            {null,null,null,null,null,null,null,null,null,null,null,null,null,null,null,null,null,PLS,null,null },
            {null,null,null,null,null,null,null,null,null,null,null,null,null,null,null,null,null,null,null,null },
            {null,Grass,null,null,null,null,null,Coin,null,null,null,null,Coin,null,null,null,null,Grass,null,null},
            {TL,TM,TM,TR,Spikes,Spikes,TL,TM,TR,Spikes,Spikes,TL,TM,TR,Spikes,Spikes,TL,TM,TM,TR },
            {BL,BM,BM,BM,BM,BM,BM,BM,BM,BM,BM,BM,BM,BM,BM,BM,BM,BM,BM,BR },
        };

        public Texture2D Background { get; set; }
        public List<IEnemy> Enemies { get; set; }
        public Vector2 spawnpoint { get; set; }

        public Level1(GameManager game)
        {
            spawnpoint = new Vector2(0, 770);
            _game = game;

            _game.hero.ResetPosition(spawnpoint); 

            Background = _game.RootGame.Content.Load<Texture2D>("background1");
            
            Enemies = new List<IEnemy>
            {
                new ShardsoulSlayer(game, new Vector2(20, 157)),
                new Ghoul(game, new Vector2(900, 120),new Vector2(1200, 120), true),
            };

            foreach (var enemy in Enemies)
            {
                _game.MapManager._enemies.Add(enemy);
            }
        }

        public void Update(GameTime gameTime)
        {
            foreach (var item in Enemies)
            {
                item.Update(gameTime);
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
                foreach (var item in Enemies)
                {
                    item.Draw(spriteBatch);
                }
                Background = _game.RootGame.Content.Load<Texture2D>("origbig");
                _coinTexture = _game.RootGame.Content.Load<Texture2D>("coin1_64");

                _coinAnimation = new Animation();
                _coinAnimation.GetFramesFromTextureProperties(
                    _coinTexture.Width,
                    _coinTexture.Height,
                    16,
                    1,
                    8,
                    0);
        }
    }
}
