using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Testproject.Map
{
    public class TileMap
    {
        private readonly int _tileWidth = 64;
        private readonly int _tileHeight = 64;

        private readonly int _cols = 10;

        public Texture2D TileTexture;

        public enum Tiles
        {
            TOP_GCL = 0,
            TOP_GCM = 1,
            TOP_GCR = 2,
            TOP_SINGLE = 3,
            TOP_SR_1 = 4,
            TOP_SR_2 = 5,
            TOP_SL_1 = 6,
            TOP_SL_2 = 7,
            TOP_SR_3 = 8,
            TOP_SL_3 = 9,
            MIDDLE_L_1 = 10,
            MIDDLE = 11,
            MIDDLE_R_1 = 12,
            MIDDLE_SINGLE = 13,
            BOTTOM_SR_1 = 14,
            BOTTOM_SR_2 = 15,
            BOTTOM_SL_1 = 16,
            BOTTOM_SL_2 = 17,
            BOTTOM_SR_3 = 18,
            BOTTOM_SL3 = 19,
            BOTTOM_LEFT = 20,
            BOTTOM_MIDDLE = 21,
            BOTTOM_RIGHT = 22,
            BOTTOM_SINGLE = 23,
            TOP_SR_4 = 24,
            TOP_SR_5 = 25,
            TOP_SL_4 = 26,
            TOP_SL_5 = 27,
            TOP_SR_6 = 28,
            TOP_SL6 = 29,
            PLAT_L = 30,
            PLAT_M = 31,
            PLAT_R = 32,
            PLAT_SINGLE = 33,
            BOTTOM_SR_4 = 34,
            BOTTOM_SR_5 = 35,
            BOTTOM_SL_4 = 36,
            BOTTOM_SL_5 = 37,
            BOTTOM_SR_6 = 38,
            BOTTOM_SL_6 = 39,
            CORNER_R = 40,
            CORNER_L = 41,
            TOP_GCL_2 = 42,
            TOP_GCM_2 = 43,
            TOP_GCR_2 = 44,
            CORNER_R_2 = 45,
            CORNER_L_2 = 46,
            GRASS = 47,
            COIN_BASE = 48,
            COIN_TURN_1 = 49,
            CORNER_R_3 = 50,
            CORNER_L_3 = 51,
            BLOCK_LEFT = 52,
            BLOCK_MIDDLE = 53,
            BLOCK_RIGHT = 54,
            SPIKE_3 = 55,
            SPIKE_1 = 56,
            COIN_TURN_2 = 57,
            COIN_SIDE = 58,
            COIN_TURN3 = 59,
        }

        public TileMap(Texture2D texture)
        {
            TileTexture = texture;

        }

        public Rectangle GetSubRectangleForTile(int index)
        {
            return GetSubRectangleForTile((Tiles)index);
        }

        public Rectangle GetSubRectangleForTile(Tiles tile)
        {
            int x = (int)tile % _cols;
            int y = (int)tile / _cols;

            return new Rectangle(x * _tileWidth, y * _tileHeight, _tileWidth, _tileHeight);
        }
    }
}
