﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Testproject.Map.Levels
{
    public interface ILevel
    {
        public TileMap.Tiles?[,] GameMap { get; set; }
        public Texture2D Background { get; set; }
    }
}