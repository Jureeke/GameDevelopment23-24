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

        private double animationTimer;
        private double animationInterval = 3.0;
        private string currentAnimation;

        public ShardsoulSlayer(GameManager game, Vector2 position)
        {
            this.game = game;
            this.position = position;
            texture = game.RootGame.Content.Load<Texture2D>("ShardsoulSlayerSpriteSheet");
            animationManager = new AnimationManager();

            // Initialize animations
            var idleAnimation = new Animation();
            idleAnimation.GetFramesFromTextureProperties(texture.Width, texture.Height, 8, 5, 8, 0);
            animationManager.AddAnimation("Idle", idleAnimation);

            var attackAnimation = new Animation();
            attackAnimation.GetFramesFromTextureProperties(texture.Width, texture.Height, 8, 5, 5, 2);
            animationManager.AddAnimation("Attack", attackAnimation);

            // Set initial animation to Idle
            currentAnimation = "Idle";
            animationManager.SetAnimation(currentAnimation);

            // Create a 1x1 white texture to use for the hitbox
            hitboxTexture = new Texture2D(game.RootGame.GraphicsDevice, 1, 1);
            hitboxTexture.SetData(new[] { Color.White });

            // Initialize the animation timer
            animationTimer = 0.0;
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

            // Update the timer
            animationTimer += gameTime.ElapsedGameTime.TotalSeconds;

            // Check if 3 seconds have passed
            if (animationTimer >= animationInterval)
            {
                // Switch between Idle and Attack animation
                SwitchAnimation();

                // Reset the timer
                animationTimer = 0.0;
            }
        }

        private void SwitchAnimation()
        {
            // Switch between Idle and Attack animations
            if (currentAnimation == "Idle")
            {
                currentAnimation = "Attack";
            }
            else
            {
                currentAnimation = "Idle";
            }

            // Set the new animation
            animationManager.SetAnimation(currentAnimation);
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
