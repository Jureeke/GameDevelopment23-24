using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SharpDX.Direct3D9;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Testproject.Core.GameStates;
using Testproject.Utility;

namespace Testproject.Core.Enemy
{
    public class ShardsoulSlayer : IEnemy
    {
        private GameManager game;
        private AnimationManager animationManager;

        public Texture2D texture { get; set; }
        public Vector2 position { get; set; }
        public Vector2 direction { get; set; }

        private Texture2D hitboxTexture;  // Texture for drawing the hitbox

        public ShardsoulSlayer(GameManager game, Vector2 position)
        {
            this.game = game;
            this.position = position;
            texture = game.RootGame.Content.Load<Texture2D>("ShardsoulSlayerSpriteSheet");
            animationManager = new AnimationManager();

            var idleAnimation = new Animation();
            idleAnimation.GetFramesFromTextureProperties(texture.Width, texture.Height, 8, 5, 8, 0);
            animationManager.AddAnimation("Idle", idleAnimation);

            animationManager.SetAnimation("Idle");
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            // Draw the ShardsoulSlayer's animation
            animationManager.Draw(spriteBatch, texture, position, direction);
        }

        public void Update(GameTime gameTime)
        {
            // Update the animation
            animationManager.Update(gameTime);
        }

        // Property to get/set the hitbox of the ShardsoulSlayer
        public Rectangle HitBox
        {
            get
            {
                return new Rectangle(
                    (int)position.X + 60,
                    (int)position.Y + 112,
                    160,
                    192
                );
            }
            set
            {
            }
        }
    }
}
