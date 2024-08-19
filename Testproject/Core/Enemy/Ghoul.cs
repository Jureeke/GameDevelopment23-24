using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SharpDX.Direct3D;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Testproject.Utility;

namespace Testproject.Core.Enemy
{
    public class Ghoul : IEnemy
    {
        private GameManager game;
        private AnimationManager animationManager;

        private Vector2 startPosistion;
        private Vector2 endPosistion;

        private float speed = 100f;
        private bool movingToEnd = true;

        private bool enableWalking = false;
        public Texture2D texture { get; set; }
        public Vector2 position { get; set; }
        public Vector2 direction { get; set; }

        private Texture2D hitboxTexture;  // Texture for drawing the hitbox

        public Ghoul(GameManager game, Vector2 position, Vector2 endPosition, bool enableWalking)
        {
            this.game = game;
            this.position = position;
            this.startPosistion = position;
            this.endPosistion = endPosition;
            this.enableWalking = enableWalking;

            texture = game.RootGame.Content.Load<Texture2D>("GhoulSpriteSheet");
            animationManager = new AnimationManager();

            var walkAnimation = new Animation();
            walkAnimation.GetFramesFromTextureProperties(texture.Width, texture.Height, 8, 5, 8, 1);
            animationManager.AddAnimation("Walk", walkAnimation);

            animationManager.SetAnimation("Walk");

            direction = this.endPosistion - startPosistion;
            if (direction.Length() > 0)
            {
                direction.Normalize();
            }

            // Create a 1x1 white texture to use for the hitbox
            hitboxTexture = new Texture2D(game.RootGame.GraphicsDevice, 1, 1);
            hitboxTexture.SetData(new[] { Color.White });
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            // Draw the Ghoul's animation
            animationManager.Draw(spriteBatch, texture, position, direction);

            spriteBatch.Draw(hitboxTexture, HitBox, Color.Red * 0.5f); // Draw the hitbox with a semi-transparent red color
        }

        public void Update(GameTime gameTime)
        {
            if (enableWalking)
            {
                float deltaTime = (float)gameTime.ElapsedGameTime.TotalSeconds;

                // Calculate the direction in which the Ghoul should move
                Vector2 targetPosition = movingToEnd ? endPosistion : startPosistion;
                Vector2 directionToTarget = targetPosition - position;

                // Normalize the direction to keep speed consistent
                if (directionToTarget.Length() > 0)
                {
                    direction = Vector2.Normalize(directionToTarget);
                }

                // Move the Ghoul towards the target
                position += direction * speed * deltaTime;

                // Check if the Ghoul is close enough to switch direction
                float threshold = 0.5f; // Reduce threshold for more precise stopping
                if (Vector2.Distance(position, targetPosition) < threshold)
                {
                    movingToEnd = !movingToEnd; // Switch direction
                    position = targetPosition; // Ensure the Ghoul stops exactly at the target
                }
            }

            // Update the animation based on the current direction
            animationManager.Update(gameTime);
        }

        // Property to get/set the hitbox of the Ghoul
        public Rectangle HitBox
        {
            get
            {
                return new Rectangle(
                    (int)position.X,
                    (int)position.Y + 32,
                    144,
                    112
                );
            }
            set
            {
            }
        }

    }
}
