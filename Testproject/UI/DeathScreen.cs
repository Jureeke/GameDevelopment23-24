using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Testproject.UI.Elements;

namespace Testproject.UI
{
    public class DeathScreen : IGameObject
    {
        private GameManager _game;
        private SpriteFont _font;

        private Texture2D _plainTexture;
        private Texture2D _deathImage;

        private Button _exitButton;

        public DeathScreen(GameManager game)
        {
            _game = game;
            _plainTexture = new Texture2D(_game.RootGame.GraphicsDevice, 1, 1);
            _plainTexture.SetData(new[] { Color.Black });
            _deathImage = _game.RootGame.Content.Load<Texture2D>("YouDied");

            _font = _game.RootGame.Content.Load<SpriteFont>("font");

            Vector2 buttonPosition = new Vector2(_game.RootGame.GraphicsDeviceManager.PreferredBackBufferWidth / 2,
                _game.RootGame.GraphicsDeviceManager.PreferredBackBufferHeight / 2);
            _exitButton = new Button("Exit", buttonPosition, _game.RootGame.Content.Load<SpriteFont>("font"), _plainTexture, () =>
            {
                System.Environment.Exit(0);
            }, 5);
        }

        public void Update(GameTime time)
        {
            _exitButton.Update(time);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            // Draw background
            spriteBatch.Draw(_plainTexture, new Rectangle(0, 0, _game.RootGame.GraphicsDeviceManager.PreferredBackBufferWidth, _game.RootGame.GraphicsDeviceManager.PreferredBackBufferHeight), Color.White);

            // Draw win image
            Vector2 deathImagePosition = new Vector2(_game.RootGame.GraphicsDeviceManager.PreferredBackBufferWidth / 2,
                _game.RootGame.GraphicsDeviceManager.PreferredBackBufferHeight / 4);
            Vector2 deathImageOrigin = new Vector2(_deathImage.Width / 2, _deathImage.Height / 2);
            spriteBatch.Draw(_deathImage, deathImagePosition, null, Color.White, 0f, deathImageOrigin, 1f, SpriteEffects.None, 0f);

            // Draw exit button
            _exitButton.Draw(spriteBatch);
        }
    }
}
