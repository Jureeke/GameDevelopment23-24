using GameDevProject.Core.Input;
using GameDevProject.Core.Movement;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Testproject;

namespace GameDevProject.Core
{
    internal class Hero : IGameObject, IMovable
    {
        private Texture2D texture;
        private Animation animation;

        private MovementManager movementManager;

        public Vector2 Position { get; set; }
        public Vector2 Speed { get; set; }
        public Vector2 Direction { get; set; }
        IInputReader IMovable.inputReader { get; set; }

        public Hero(Texture2D texture, IInputReader inputReader, Vector2 postiiton, Vector2 speed)
        {
            this.texture = texture;
            animation = new Animation();
            movementManager = new MovementManager();

            animation.GetFramesFromTextureProperties(texture.Width, texture.Height, 8, 5, 8, 1);

            ((IMovable)this).Position = postiiton;
            ((IMovable)this).Speed = speed;
            ((IMovable)this).inputReader = inputReader;
        }


        public void Draw(SpriteBatch spriteBatch)
        {
            SpriteEffects spriteeffect = ((IMovable)this).Direction.X >= 0 ? SpriteEffects.None : SpriteEffects.FlipHorizontally;
            spriteBatch.Draw(texture, ((IMovable)this).Position, animation.CurrentFrame.SourceRectangle, Color.White, 0, Vector2.Zero, 1.5f, spriteeffect, 0f);
        }

        public void Update(GameTime gameTime)
        {
            animation.Update(gameTime);
            Move();

        }

        private void Move()
        {
            movementManager.Move(this);
        }
    }
}
