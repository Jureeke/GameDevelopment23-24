using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Testproject.UI.Elements;

namespace Testproject.UI
{
    public class WinScreen : IGameObject
    {
        private GameManager _game;
        private SpriteFont _font;

        private Texture2D _backgroundTexture;
        private Texture2D _winImage;
        private Texture2D _plainTexture;
        private Button _exitButton;

        public WinScreen(GameManager game)
        {
            _game = game;

            // Load textures
            _backgroundTexture = _game.RootGame.Content.Load<Texture2D>("background1");
            _winImage = _game.RootGame.Content.Load<Texture2D>("WinTrophy");
            _font = _game.RootGame.Content.Load<SpriteFont>("font");

            _plainTexture = new Texture2D(_game.RootGame.GraphicsDevice, 1, 1);
            _plainTexture.SetData(new[] { Color.White });

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
            spriteBatch.Draw(_backgroundTexture, new Rectangle(0, 0, _game.RootGame.GraphicsDeviceManager.PreferredBackBufferWidth, _game.RootGame.GraphicsDeviceManager.PreferredBackBufferHeight), Color.White);

            // Draw win image
            Vector2 winImagePosition = new Vector2(_game.RootGame.GraphicsDeviceManager.PreferredBackBufferWidth / 2,
                _game.RootGame.GraphicsDeviceManager.PreferredBackBufferHeight / 4);
            Vector2 winImageOrigin = new Vector2(_winImage.Width / 2, _winImage.Height / 2);
            spriteBatch.Draw(_winImage, winImagePosition, null, Color.White, 0f, winImageOrigin, 1f, SpriteEffects.None, 0f);

            // Draw exit button
            _exitButton.Draw(spriteBatch);
        }
    }
}
