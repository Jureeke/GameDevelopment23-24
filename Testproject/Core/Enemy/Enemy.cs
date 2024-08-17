using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Testproject.Core.Enemy
{
    public abstract class Enemy
    {
        public abstract void Draw(SpriteBatch spriteBatch);
        public abstract void Update(GameTime gameTime);
        public abstract Texture2D texture { get; set; }
        public Vector2 position { get; set; }
        public Vector2 direction { get; set; }
    }
}
