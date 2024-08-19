using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SharpDX.Direct3D9;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Testproject.Utility;

namespace Testproject.Core.Enemy
{
    public class BrainMole : IEnemy
    {
        private GameManager game;
        private AnimationManager animationManager;

        private List<Vector2> waypoints;
        private int currentWaypointIndex;

        private float speed = 100f;

        private int width = 64;  // Width of the hitbox
        private int height = 64; // Height of the hitbox

        // Property to get/set the hitbox of the BrainMole
        public Rectangle HitBox
        {
            get
            {
                return new Rectangle(
                    (int)position.X,
                    (int)position.Y,
                    width,
                    height
                );
            }
            set
            {
            }
        }

        public Vector2 position { get; set; }
        public Vector2 direction { get; set; }
        public Texture2D texture { get; set; }

        private Texture2D hitboxTexture;  // Texture for drawing the hitbox

        public BrainMole(GameManager game, Vector2 position, List<Vector2> waypoints)
        {
            this.game = game;
            this.position = position;
            this.waypoints = waypoints;

            ((IEnemy)this).texture = game.RootGame.Content.Load<Texture2D>("BrainMoleMonarchSpriteSheet");
            animationManager = new AnimationManager();

            var moveAnimation = new Animation();
            moveAnimation.GetFramesFromTextureProperties(((IEnemy)this).texture.Width, ((IEnemy)this).texture.Height, 7, 4, 4, 2);
            animationManager.AddAnimation("Move", moveAnimation);

            animationManager.SetAnimation("Move");

            HitBox = new Rectangle((int)position.X, (int)position.Y, width, height);

            // Create a 1x1 white texture to use for the hitbox
            hitboxTexture = new Texture2D(game.RootGame.GraphicsDevice, 1, 1);
            hitboxTexture.SetData(new[] { Color.White });
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            // Draw the BrainMole's animation
            animationManager.Draw(spriteBatch, ((IEnemy)this).texture, position, direction);

            spriteBatch.Draw(hitboxTexture, HitBox, Color.Red * 0.5f); // Draw the hitbox with a semi-transparent red color
        }

        public void Update(GameTime gameTime)
        {
            if (waypoints.Count > 0)
            {
                // Get the target waypoint
                Vector2 targetPosition = waypoints[currentWaypointIndex];

                // Calculate direction and move towards the target
                Vector2 direction = targetPosition - position;
                if (direction.Length() > 0)
                {
                    direction.Normalize();
                    position += direction * speed * (float)gameTime.ElapsedGameTime.TotalSeconds;
                }

                // Check if we have reached the target waypoint
                if (Vector2.Distance(position, targetPosition) < 10f)
                {
                    // Move to the next waypoint
                    currentWaypointIndex = (currentWaypointIndex + 1) % waypoints.Count;
                }
            }
            HitBox = new Rectangle((int)position.X, (int)position.Y, width, height);

            animationManager.Update(gameTime);
        }
    }
}
