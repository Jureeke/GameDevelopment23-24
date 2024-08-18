using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Testproject.Utility
{
    public class AnimationManager
    {
        private Animation currentAnimation;
        private Dictionary<string, Animation> animations;

        public AnimationManager()
        {
            animations = new Dictionary<string, Animation>();
        }

        // Voeg een animatie toe aan de manager
        public void AddAnimation(string name, Animation animation)
        {
            if (!animations.ContainsKey(name))
            {
                animations[name] = animation;
            }
        }

        // Zet de huidige animatie
        public void SetAnimation(string animationName)
        {
            if (animations.ContainsKey(animationName))
            {
                currentAnimation = animations[animationName];
            }
        }

        // Werk de huidige animatie bij
        public void Update(GameTime gameTime)
        {
            if (currentAnimation != null)
            {
                currentAnimation.Update(gameTime);
            }
        }

        // Teken de huidige animatie
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
