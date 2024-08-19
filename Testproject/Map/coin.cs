using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Testproject.Utility.Collision;

namespace Testproject.Map.Tiles
{
    public class Coin : ICollidable
    {
        private GameManager _game;
        private int _x;
        private int _y;
        private int _width = 64;
        private int _height = 64;
        private Texture2D _texture;
        private Animation _animation;
        private bool _isPickedUp;

        // Hitbox for collision detection
        public Rectangle HitBox { get; set; }

        public Coin(int x, int y, GameManager game)
        {
            _x = x;
            _y = y;
            _game = game;

            // Load texture and setup animation
            _texture = game.RootGame.Content.Load<Texture2D>("coin1_64");
            _animation = new Animation();
            _animation.GetFramesFromTextureProperties(_texture.Width, _texture.Height, 15, 1, 15, 0);

            // Initialize hitbox
            HitBox = new Rectangle(_x, _y, _width, _height);

            _isPickedUp = false;
        }

        // Update the animation state of the coin
        public void Update(GameTime gameTime)
        {
            if (!_isPickedUp)
            {
                _animation.Update(gameTime);
                // Update hitbox in case the coin moves (not necessary if the coin is stationary)
                HitBox = new Rectangle(_x, _y, _width, _height);
            }
        }

        // Draw the coin using the current animation frame
        public void Draw(SpriteBatch spriteBatch)
        {
            if (!_isPickedUp)
            {
                var currentFrame = _animation.CurrentFrame;
                spriteBatch.Draw(_texture, HitBox, currentFrame.SourceRectangle, Color.White);
            }
        }

        // Handle coin pickup
        public void PickUp()
        {
            if (!_isPickedUp)
            {
                _isPickedUp = true;
                _game.score++;  // Update the game score
                OnPickedUp();   // Trigger any additional logic on pickup
            }
        }

        // Additional logic to be executed when the coin is picked up
        private void OnPickedUp()
        {
            // Optional: Add sound effects, particles, etc.
        }
    }
}
