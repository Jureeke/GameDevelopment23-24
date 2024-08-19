using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Testproject.Core.GameStates
{
    public class PlayingState : GameState
    {
        private GameManager _manager;
        private Texture2D _heartTexture;

        public PlayingState(GameManager manager)
        {
            _manager = manager;
        }

        protected override void OnActivate()
        {
            _manager.SoundManager.PlayBackgroundMusic("LevelMusic", true, 0.02f);
            _heartTexture = _manager.RootGame.Content.Load<Texture2D>("heartIcon");
        }

        protected override void OnDeactivate()
        {
            _manager.SoundManager.StopBackgroundMusic();
        }

        public override void OnUpdate(GameTime time)
        {
            _manager.MapManager.Update(time);
            _manager.hero.Update(time);
        }

        public override void OnDraw(SpriteBatch batch)
        {
            _manager.MapManager.RenderMap(batch);
            _manager.hero.Draw(batch);
            DrawLives(batch);
        }

        private void DrawLives(SpriteBatch spriteBatch)
        {
            const int heartSize = 80; // Grootte van het hart icoon
            int spacing = 5; // Ruimte tussen de hart iconen
            Vector2 position = new Vector2(30, 10); // Startpositie voor de levens

            for (int i = 0; i < _manager.hero.Lives; i++)
            {
                spriteBatch.Draw(_heartTexture, position + new Vector2(i * (heartSize + spacing), 0), Color.White);
            }
        }
    }
}
