using GameDevProject.Core.Input;
using GameDevProject.Core.Movement;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using Testproject;
using Testproject.Core;
using Testproject.Utility;
using Testproject.Utility.Collision;

namespace GameDevProject.Core
{
    public class Hero : IGameObject, IMovable, ICollidable
    {
        public Texture2D texture;
        private AnimationManager animationManager;

        public Vector2 spawnPosition = new Vector2(0, 0);
        public GameManager _game;
        private MovementManager movementManager;
        private HeroCollisionManager _collisionManager;

        private readonly int hitBoxWidth = 70;
        private readonly int hitBoxHeight = 112;

        public Vector2 Position { get; set; }
        public Vector2 Speed { get; set; }
        public Vector2 Direction { get; set; }
        IInputReader IMovable.inputReader { get; set; }

        public Rectangle HitBox
        {
            get
            {
                return new Rectangle(
                    (int)Position.X + hitBoxWidth / 2,
                    (int)Position.Y + 28,
                    hitBoxWidth,
                    hitBoxHeight
                );
            }
            set
            {
                // Set the hitbox property if needed
            }
        }

        private float gravity;
        public bool isJumping;
        private float jumpStrength;
        private float groundLevel;

        public Hero(GameManager manager)
        {
            _game = manager;
            texture = _game.RootGame.Content.Load<Texture2D>("Gladiator-SpriteSheet");
            movementManager = new MovementManager();
            animationManager = new AnimationManager();
            #region animations
            // Voeg animaties toe
            var idleAnimation = new Animation();
            idleAnimation.GetFramesFromTextureProperties(texture.Width, texture.Height, 8, 5, 2, 0);
            animationManager.AddAnimation("Idle", idleAnimation);

            var walkAnimation = new Animation();
            walkAnimation.GetFramesFromTextureProperties(texture.Width, texture.Height, 8, 5, 8, 1);
            animationManager.AddAnimation("Walk", walkAnimation);

            var attackAnimation = new Animation();
            attackAnimation.GetFramesFromTextureProperties(texture.Width, texture.Height, 8, 5, 8, 2);
            animationManager.AddAnimation("Attack", attackAnimation);

            // Stel standaard animatie in
            animationManager.SetAnimation("Idle");
            #endregion

            // Calculate the spawn position to be in the bottom-left corner
            spawnPosition = new Vector2(0, _game.RootGame.GraphicsDeviceManager.PreferredBackBufferHeight - (64 * 4));

            // Set the hero's initial position to the calculated spawn position
            Position = spawnPosition;

            // Set other properties
            Speed = new Vector2(4, 2); // doubled the speed
            ((IMovable)this).inputReader = new KeyboardReader();

            gravity = 1000f;
            isJumping = false;
            jumpStrength = 700f;
            groundLevel = Position.Y;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            animationManager.Draw(spriteBatch, texture, Position, Direction);
        }

        public void Update(GameTime gameTime)
        {
            var direction = ((IMovable)this).inputReader.Readinput();
            UpdateAnimation(gameTime, direction);
            Move();
            UpdateJump(gameTime);
            _collisionManager.Update(gameTime);
        }

        // Method to reset the hero's position when starting a level
        public void ResetPosition(Vector2 spawn)
        {
            Position = spawn;
        }

        private void UpdateAnimation(GameTime gameTime, Vector2 direction)
        {
            bool isMoving = direction.X != 0;
            bool isSpecialAction = ((KeyboardReader)((IMovable)this).inputReader).IsSpecialActionTriggered();

            if (isSpecialAction)
            {
                animationManager.SetAnimation("Attack");
            }
            else if (isMoving)
            {
                animationManager.SetAnimation("Walk");
            }
            else
            {
                animationManager.SetAnimation("Idle");
            }

            animationManager.Update(gameTime);
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

            Speed = new Vector2(Speed.X, Speed.Y + gravity * deltaTime);

            Position += Speed * deltaTime;

            if (Position.Y >= groundLevel)
            {
                Position = new Vector2(Position.X, groundLevel);
                Speed = new Vector2(Speed.X, 0);
                isJumping = false;
            }
        }
        
        public void LateSetup()
        {
            _collisionManager = _game.heroCollisionManager;
        }
    }
}
