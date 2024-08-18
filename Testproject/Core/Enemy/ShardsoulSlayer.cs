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
    public class ShardsoulSlayer : Enemy
    {

        private GameManager game;
        private AnimationManager animationManager;
        public override Texture2D texture { get; set; }

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
        public override void Draw(SpriteBatch spriteBatch)
        {
            animationManager.Draw(spriteBatch, texture, position, direction);
        }

        public override void Update(GameTime gameTime)
        {
            animationManager.Update(gameTime);
        }
    }
}
