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
    public class Ghoul : Enemy
    {
        private GameManager game;
        private AnimationManager animationManager;

        private Vector2 startPosistion;
        private Vector2 endPosistion;

        private float speed = 100f;
        private bool movingToEnd = true;

        private bool enableWalking = false;
        public override Texture2D texture { get; set; }

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

            // Stel standaard animatie in
            animationManager.SetAnimation("Walk");

            direction = this.endPosistion - startPosistion;
            if (direction.Length() > 0)
            {
                direction.Normalize();
            }
        }
        public override void Draw(SpriteBatch spriteBatch)
        {
            animationManager.Draw(spriteBatch, texture, position, direction);
        }

        public override void Update(GameTime gameTime)
        {
            if (enableWalking)
            {
                float deltaTime = (float)gameTime.ElapsedGameTime.TotalSeconds;

                // Bereken de richting waarin de Ghoul moet bewegen
                Vector2 targetPosition = movingToEnd ? endPosistion : startPosistion;
                Vector2 directionToTarget = targetPosition - position;

                // Normaleer de richting om de snelheid constant te houden
                if (directionToTarget.Length() > 0)
                {
                    direction = Vector2.Normalize(directionToTarget);
                }

                // Verplaats de Ghoul in de richting van het doel
                position += direction * speed * deltaTime;

                // Controleer of de Ghoul dichtbij genoeg is om van richting te veranderen
                float threshold = 0.5f; // Verklein de drempel om preciezer te stoppen
                if (Vector2.Distance(position, targetPosition) < threshold)
                {
                    movingToEnd = !movingToEnd; // Wissel van richting
                    position = targetPosition; // Zorg ervoor dat de Ghoul exact op het doel stopt
                }
            }

            // Update de animatie op basis van de huidige richting
            animationManager.Update(gameTime);
        }
    }
}
