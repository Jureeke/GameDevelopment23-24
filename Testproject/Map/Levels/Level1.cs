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
            {null,null,null,null,null,null,null,null,null,SL,TM,TM,TM,TR,null,null,null,null,null,null },
            {null,null,null,null,null,null,null,null,SL,BS,null,null,null,null,null,null,null,null,null,null },
            {null,null,Grass,Coin,null,null,null,null,null,null,null,null,null,null,null,null,null,null,null,null },
            {null,TL,TM,TM,TR,null,null,null,null,null,null,null,null,null,Grass,null,null,null,null,null },
            {null,null,null,null,null,null,null,null,TL,TM,SR,null,null,null,TL,TM,SR,null,null,null },
            {null,null,null,null,null,null,null,null,null,null,null,null,null,null,null,null,null,null,null,null },
            {null,Grass,null,null,null,null,null,Coin,null,null,null,null,Coin,null,null,null,null,null,Grass,null },
            {TL,TM,TM,TR,null,TL,TM,TM,TR,null,TL,TM,TM,TR,null,null,TL,TM,TM,TR },
            {ML,M,M,MR,Spikes,ML,M,M,MR,Spikes,ML,M,M,MR,Spikes,Spikes,ML,M,M,MR },
            {BL,BM,BM,BM,BM,BM,BM,BM,BM,BM,BM,BM,BM,BM,BM,BM,BM,BM,BM,BR },
        };

        public Texture2D Background { get; set; }
        public List<Enemy> Enemies { get; set; }

        public Level1(GameManager game)
        {
            _game = game;

            _game.hero.ResetPosition(); // Reset the hero's position to the spawn point

            Background = _game.RootGame.Content.Load<Texture2D>("background1");
            Enemies = new List<Enemy>
            {
                new ShardsoulSlayer(game, new Vector2(20, 155)),
                new Ghoul(game, new Vector2(900, 35),new Vector2(1200, 35), true)
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
