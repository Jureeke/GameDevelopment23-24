using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Testproject.Utility;

namespace Testproject.Core.Enemy
{
    public class BrainMole : Enemy
    {
        private GameManager game;
        private AnimationManager animationManager;

        private List<Vector2> waypoints;
        private int currentWaypointIndex;

        private float speed = 100f;
        public override Texture2D texture { get; set; }

        public BrainMole(GameManager game, Vector2 position, List<Vector2> waypoints)
        {
            this.game = game;
            this.position = position;
            this.waypoints = waypoints;


            texture = game.RootGame.Content.Load<Texture2D>("BrainMoleMonarchSpriteSheet");
            animationManager = new AnimationManager();

            var moveAnimation = new Animation();
            moveAnimation.GetFramesFromTextureProperties(texture.Width, texture.Height, 7, 4, 4, 2);
            animationManager.AddAnimation("Move", moveAnimation);

            animationManager.SetAnimation("Move");
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            animationManager.Draw(spriteBatch, texture, position, direction);
        }

        public override void Update(GameTime gameTime)
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

            animationManager.Update(gameTime);
        }
    }
}
