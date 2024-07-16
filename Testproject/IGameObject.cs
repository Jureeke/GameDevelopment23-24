using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SharpDX.Direct3D11;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Testproject
{
    internal interface IGameObject
    {
        void Update(GameTime gameTime);
        void Draw(SpriteBatch spriteBatch); 
    }
}
