using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Testproject.Map.Levels
{
    public class Level1 : ILevel
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

        private const TileMap.Tiles SR = TileMap.Tiles.TOP_SR_3;
        private const TileMap.Tiles SL = TileMap.Tiles.TOP_SL_3;
        private const TileMap.Tiles BS = TileMap.Tiles.BOTTOM_SL3;
        #endregion

        public TileMap.Tiles?[,] GameMap { get; set; } =
        {
            {null,null,null,null,null,null,null,null,null,null,null,null,null,null,null,null,null,null,null,null },
            {null,null,null,null,null,null,null,null,null,null,null,Coin,Grass,null,null,null,null,null,null,null },
            {null,null,null,null,null,null,null,null,null,SL,TM,TM,TR,null,null,null,null,null,null,null },
            {null,null,null,null,null,null,null,null,SL,BS,null,null,null,null,null,null,null,null,null,null },
            {null,null,Grass,Coin,null,null,null,null,null,null,null,null,null,null,null,null,null,null,null,null },
            {null,null,TL,TM,TR,null,null,null,null,null,null,null,null,null,Grass,null,null,null,null,null },
            {null,null,null,null,null,null,null,null,TL,TM,SR,null,null,null,TL,TM,SR,null,null,null },
            {null,null,null,null,null,null,null,null,null,null,null,null,null,null,null,null,null,null,null,null },
            {null,Grass,null,null,null,null,null,Coin,null,null,null,null,Coin,null,null,null,null,null,Grass,null },
            {TL,TM,TM,TR,null,null,TL,TM,TR,null,null,TL,TM,TR,null,null,TL,TM,TM,TR },
            {ML,M,M,MR,Spikes,Spikes,ML,M,MR,Spikes,Spikes,ML,M,MR,Spikes,Spikes,ML,M,M,MR },
            {BL,BM,BM,BM,BM,BM,BM,BM,BM,BM,BM,BM,BM,BM,BM,BM,BM,BM,BM,BR },
        };

        public Texture2D Background { get; set; }

        public Level1(GameManager game)
        {
            _game = game;
            _game.hero.ResetPosition(); // Reset the hero's position to the spawn point

            Background = _game.RootGame.Content.Load<Texture2D>("origbig");
        }
    }
}
