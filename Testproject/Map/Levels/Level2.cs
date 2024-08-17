using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using Testproject.Core.Enemy;

namespace Testproject.Map.Levels
{
    public class Level2 : ILevel
    {
        private GameManager _game;
        #region
        private const TileMap.Tiles Coin = TileMap.Tiles.COIN_BASE;
        private const TileMap.Tiles Grass = TileMap.Tiles.GRASS;
        private const TileMap.Tiles Spikes = TileMap.Tiles.SPIKE_3;


        private const TileMap.Tiles BL = TileMap.Tiles.BOTTOM_LEFT;
        private const TileMap.Tiles BM = TileMap.Tiles.BOTTOM_MIDDLE;
        private const TileMap.Tiles BR = TileMap.Tiles.BOTTOM_RIGHT;

        private const TileMap.Tiles ML = TileMap.Tiles.MIDDLE_L_1;
        private const TileMap.Tiles M = TileMap.Tiles.MIDDLE;
        private const TileMap.Tiles MR = TileMap.Tiles.MIDDLE_R_1;

        private const TileMap.Tiles TL = TileMap.Tiles.TOP_GCL;
        private const TileMap.Tiles TM = TileMap.Tiles.TOP_GCM;
        private const TileMap.Tiles TR = TileMap.Tiles.TOP_GCR;

        private const TileMap.Tiles PL = TileMap.Tiles.TOP_GCL_2;
        private const TileMap.Tiles PM = TileMap.Tiles.TOP_GCM_2;
        private const TileMap.Tiles PR = TileMap.Tiles.TOP_GCR_2;

        private const TileMap.Tiles SR = TileMap.Tiles.TOP_SR_3;
        private const TileMap.Tiles SL = TileMap.Tiles.TOP_SL_3;
        private const TileMap.Tiles BSR = TileMap.Tiles.BOTTOM_SR_6;
        private const TileMap.Tiles BSL = TileMap.Tiles.BOTTOM_SL_6;

        private const TileMap.Tiles Single = TileMap.Tiles.PLAT_SINGLE;

        #endregion
        public TileMap.Tiles?[,] GameMap { get; set; } =
        {
            {null,null,null,null,null,null,null,null,null,null,null,null,null,null,null,null,null,null,null,null },
            {null,null,null,null,null,null,null,null,null,Coin,null,null,null,null,null,null,null,null,null,null },
            {null,null,null,null,null,null,null,Grass,null,Single,null,Grass,null,null,null,null,null,null,null,null },
            {null,null,null,null,null,null,null,Single,null,null,null,Single,null,null,null,null,null,null,null,null },
            {null,null,Grass,Coin,null,null,null,null,null,null,null,null,null,null,null,Coin,null,null,null,null },
            {null,null,PL,PM,PR,null,null,null,null,null,null,null,null,null,PL,PM,PR,null,null,null },
            {null,null,null,null,null,null,null,null,Grass,Spikes,Grass,null,null,null,null,null,null,null,null,null },
            {Grass,null,null,null,null,null,null,SL,TM,TM,TM,SR,null,null,null,null,null,null,null,Grass },
            {TL,SR,null,null,null,null,SL,BSL,M,M,M,BSR,SR,null,null,null,null,null,SL,TR },
            {ML,BSR,SR,Spikes,Spikes,SL,BSL,M,M,M,M,M,BSR,SR,Spikes,Spikes,Spikes,SL,BSL,MR },
            {ML,M,BSR,TM,TM,BSL,M,M,M,M,M,M,M,BSR,TM,TM,TM,BSL,M,MR },
            {BL,BM,BM,BM,BM,BM,BM,BM,BM,BM,BM,BM,BM,BM,BM,BM,BM,BM,BM,BR },
        };

        public Vector2 SpawnLocation { get; set; }
        public Texture2D Background { get; set; }
        public List<Enemy> Enemies { get; set; }

        public Level2(GameManager game)
        {
            _game = game;
            Background = _game.RootGame.Content.Load<Texture2D>("background2");
            Enemies = new List<Enemy>
            {
                new ShardsoulSlayer(game, new Vector2(350, 250)),
            };

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
