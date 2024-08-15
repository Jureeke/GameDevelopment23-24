using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Reflection.Metadata;
using Testproject.Core.GameStates;
using Testproject.Map.Tiles;

namespace Testproject
{
    public class Game1 : Game
    {
        public GraphicsDeviceManager GraphicsDeviceManager;
        private SpriteBatch _spriteBatch;

        private GameManager _gameManager;

        public Game1()
        {
            GraphicsDeviceManager = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;

            GraphicsDeviceManager.PreferredBackBufferWidth = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Width;
            GraphicsDeviceManager.PreferredBackBufferHeight = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Height;
            GraphicsDeviceManager.IsFullScreen = true;
            GraphicsDeviceManager.HardwareModeSwitch = false;
        }

        protected override void Initialize()
        {
            _gameManager = new GameManager(this);
            _gameManager.Activate();
            base.Initialize();
            hero = new Hero(_texture, new KeyboardReader(), new Vector2(0, 500), new Vector2(2, 2));
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here

            _texture = Content.Load<Texture2D>("Gladiator-SpriteSheet");
            //background = Content.Load<Texture2D>("Space Background");
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here
            _gameManager.Update(gameTime);
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // Draw sprites
            _spriteBatch.Begin();
            _gameManager.Draw(_spriteBatch);
            _spriteBatch.End();
            // End draw sprites

            base.Draw(gameTime);
        }
    }
}
