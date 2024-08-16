using GameDevProject.Core.Input;
using GameDevProject.Core.Movement;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Testproject;

namespace GameDevProject.Core
{
    public class Hero : IGameObject, IMovable
    {
        private Texture2D texture;
        private Animation animation;

        private GameManager Game;

        private MovementManager movementManager;

        public Vector2 Position { get; set; }
        public Vector2 Speed { get; set; }
        public Vector2 Direction { get; set; }
        IInputReader IMovable.inputReader { get; set; }

        private float gravity;
        private bool isJumping;
        private float jumpStrength;
        private float groundLevel;

        public Hero(GameManager manager)
        {
            this.Game = manager;
            this.texture = Game.RootGame.Content.Load<Texture2D>("Gladiator-SpriteSheet");
            animation = new Animation();
            movementManager = new MovementManager();

            animation.GetFramesFromTextureProperties(texture.Width, texture.Height, 8, 5, 8, 1);

            ((IMovable)this).Position = new Vector2(1,1);
            ((IMovable)this).Speed = new Vector2(2,2);
            ((IMovable)this).inputReader = new KeyboardReader();

            gravity = 1000f;
            isJumping = false;
            jumpStrength = 450f;
            groundLevel = Position.Y;
        }


        public void Draw(SpriteBatch spriteBatch)
        {
            SpriteEffects spriteeffect = ((IMovable)this).Direction.X >= 0 ? SpriteEffects.None : SpriteEffects.FlipHorizontally;
            spriteBatch.Draw(texture, ((IMovable)this).Position, animation.CurrentFrame.SourceRectangle, Color.White, 0, Vector2.Zero, 1f, spriteeffect, 0f);
        }

        public void Update(GameTime gameTime)
        {
            animation.Update(gameTime);
            Move();
            UpdateJump(gameTime);
        }

        private void Move()
        {
            movementManager.Move(this);
        }

        public void Jump()
        {
            if (!isJumping)
            {
                Speed = new Vector2(Speed.X, -jumpStrength);
                isJumping = true;
            }
        }

        private void UpdateJump(GameTime gameTime)
        {
            float deltaTime = (float)gameTime.ElapsedGameTime.TotalSeconds;

            if (isJumping)
            {
                Speed = new Vector2(Speed.X, Speed.Y + gravity * deltaTime);
            }

            Position += Speed * deltaTime;

            if (Position.Y >= groundLevel)
            {
                Position = new Vector2(Position.X, groundLevel);
                Speed = new Vector2(Speed.X, 0);
                isJumping = false;
            }
        }
    }
}
