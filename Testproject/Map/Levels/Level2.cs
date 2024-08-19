using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using Testproject.Core.Enemy;

namespace Testproject.Map.Levels
{
    public class Level2 : ILevel
    {
        private GameManager _game;
        #region Tile Definitions
        private const TileMap.Tiles Coin = TileMap.Tiles.COIN_BASE;
        private const TileMap.Tiles Grass = TileMap.Tiles.GRASS;
        private const TileMap.Tiles Spikes = TileMap.Tiles.SPIKE_3;

        private const TileMap.Tiles BL = TileMap.Tiles.BOTTOM_LEFT;
        private const TileMap.Tiles BM = TileMap.Tiles.BOTTOM_MIDDLE;
        private const TileMap.Tiles BR = TileMap.Tiles.BOTTOM_RIGHT;


        private const TileMap.Tiles ML = TileMap.Tiles.MIDDLE_L_1;
        private const TileMap.Tiles MM = TileMap.Tiles.MIDDLE;
        private const TileMap.Tiles MR = TileMap.Tiles.MIDDLE_R_1;

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
            {null,null,null,null,null,null,null,null,null,Coin,null,null,null,null,null,null,null,null,null,null },
            {null,null,null,null,null,null,null,Grass,null,PLS,null,Grass,null,null,null,null,null,null,null,null },
            {null,null,null,null,null,null,null,PLS,null,null,null,PLS,null,null,null,null,null,null,null,null },
            {null,null,Grass,Coin,null,null,null,null,null,null,null,null,null,null,null,Coin,null,null,null,null },
            {null,null,PLL,PLM,PLR,null,null,null,null,null,null,null,null,null,PLL,PLM,PLR,null,null,null },
            {null,null,null,null,null,null,null,null,null,null,null,null,null,null,null,null,null,PLS,null,null },
            {null,null,null,null,null,null,null,null,null,null,null,null,null,null,null,null,null,null,null,null },
            {null,Grass,null,null,null,null,Grass,null,null,null,null,null,Coin,null,null,null,null,null,Grass,null },
            {TL,TM,TM,TM,TM,TM,TM,TR,null,null,null,TL,TM,TM,TM,TM,TM,TM,TM,TR  },
            {ML,MM,MM,MM,MM,MM,MM,MR,Spikes,Spikes,Spikes,ML,MM,MM,MM,MM,MM,MM,MM,MR },
            {BL,BM,BM,BM,BM,BM,BM,BM,BM,BM,BM,BM,BM,BM,BM,BM,BM,BM,BM,BR },
        };

        public Texture2D Background { get; set; }
        public List<IEnemy> Enemies { get; set; }
        public Vector2 spawnpoint { get; set; }

        public List<Vector2> waypoints = new List<Vector2>
        {
            new Vector2(80, 80),
            new Vector2(750, 450),
            new Vector2(1500, 80),
            new Vector2(750, 20),
        };

        public Level2(GameManager game)
        {
            _game = game;
            _game.hero.ResetPosition(new Vector2(0, 750));
            Background = _game.RootGame.Content.Load<Texture2D>("background2");
            spawnpoint = new Vector2(0,770);
            _game.hero.ResetPosition(spawnpoint);

            Enemies = new List<IEnemy>
            {
                new BrainMole(game, new Vector2(80,80), waypoints),
                new Ghoul(game, new Vector2(1200, 320),new Vector2(1400, 320), true),
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
        }
    }
}
