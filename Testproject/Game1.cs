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
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
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