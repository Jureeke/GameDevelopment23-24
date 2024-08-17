using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Testproject.Utility
{
    public class HeroAnimationManager
    {
        private Animation currentAnimation;
        private Dictionary<string, Animation> animations;

        public HeroAnimationManager(Texture2D texture)
        {
            animations = new Dictionary<string, Animation>();

            // Initialiseer animaties
            var idleAnimation = new Animation();
            idleAnimation.GetFramesFromTextureProperties(texture.Width, texture.Height, 8, 5, 2, 0);
            animations["Idle"] = idleAnimation;

            var walkAnimation = new Animation();
            walkAnimation.GetFramesFromTextureProperties(texture.Width, texture.Height, 8, 5, 8, 1);
            animations["Walk"] = walkAnimation;

            var attackAnimation = new Animation();
            attackAnimation.GetFramesFromTextureProperties(texture.Width, texture.Height, 8, 5, 8, 2);
            animations["Attack"] = attackAnimation;

            var deathAnimation = new Animation();
            deathAnimation.GetFramesFromTextureProperties(texture.Width, texture.Height, 8, 5, 8, 4);
            animations["Death"] = deathAnimation;

            // Standard Animation
            currentAnimation = animations["Idle"];
        }

        public void SetAnimation(string animationName)
        {
            if (animations.ContainsKey(animationName))
            {
                currentAnimation = animations[animationName];
            }
        }

        public void Update(GameTime gameTime, Vector2 speed)
        {
            if (currentAnimation != null)
            {
                currentAnimation.Update(gameTime);
            }
        }

        public void Draw(SpriteBatch spriteBatch, Texture2D texture, Vector2 position, Vector2 direction)
        {
            if (currentAnimation != null)
            {
                SpriteEffects spriteEffect = direction.X >= 0 ? SpriteEffects.None : SpriteEffects.FlipHorizontally;
                spriteBatch.Draw(texture, position, currentAnimation.CurrentFrame.SourceRectangle, Color.White, 0, Vector2.Zero, 1.5f, spriteEffect, 0f);
            }
        }
    }
}
