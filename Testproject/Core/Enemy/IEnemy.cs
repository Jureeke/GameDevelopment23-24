using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using Testproject.Utility.Collision;

namespace Testproject.Core.Enemy
{
    public interface IEnemy : ICollidable
    {
        public  void Draw(SpriteBatch spriteBatch);
        public void Update(GameTime gameTime);
        public Texture2D texture { get; set; }
        public Vector2 position { get; set; }
        public Vector2 direction { get; set; }
        public new Rectangle HitBox { get; set; }
    }
}
