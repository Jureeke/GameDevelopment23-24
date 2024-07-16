using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using Testproject;
using Testproject.Utility.StateMachine;

public class Level1State : State
{
    public Level1State(Game1 game, GameManager gameManager) : base(game, gameManager) { }

    public override void Enter() { }

    public override void Exit() { }

    public override void Update(GameTime gameTime)
    {
        KeyboardState keyboardState = Keyboard.GetState();
        if (keyboardState.IsKeyDown(Keys.Space)) // the condition to win and go to level 2
        {
            gameManager.ChangeState(new DeathState(game, gameManager));
        }
        else if (keyboardState.IsKeyDown(Keys.Enter))
        {
            gameManager.ChangeState(new Level2State(game, gameManager));
        }
    }

    public override void Draw(GameTime gameTime)
    {
        game.GraphicsDevice.Clear(Color.Green);

        game.SpriteBatch.Begin();
        game.SpriteBatch.DrawString(game.Font, "Level 1", new Vector2(100, 100), Color.White);
        game.SpriteBatch.End();
    }
}
