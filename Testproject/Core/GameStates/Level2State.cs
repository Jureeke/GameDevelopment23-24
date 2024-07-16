using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using Testproject;
using Testproject.Utility.StateMachine;

public class Level2State : State
{
    public Level2State(Game1 game, GameManager gameManager) : base(game, gameManager) { }

    public override void Enter() { }

    public override void Exit() { }

    public override void Update(GameTime gameTime)
    {
        KeyboardState keyboardState = Keyboard.GetState();

        if (keyboardState.IsKeyDown(Keys.Space))
        {
            gameManager.ChangeState(new DeathState(game, gameManager));
        }
        else if (keyboardState.IsKeyDown(Keys.M))
        {
            gameManager.ChangeState(new WinState(game, gameManager));
        }
    }

    public override void Draw(GameTime gameTime)
    {
        game.GraphicsDevice.Clear(Color.Blue);

        game.SpriteBatch.Begin();
        game.SpriteBatch.DrawString(game.Font, "Level 2", new Vector2(100, 100), Color.White);
        game.SpriteBatch.End();
    }
}
