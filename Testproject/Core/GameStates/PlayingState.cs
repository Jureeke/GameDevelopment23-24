using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Testproject.Core.GameStates
{
    public class PlayingState : GameState
    {
        private GameManager _manager;

        public PlayingState(GameManager manager)
        {
            _manager = manager;
        }

        protected override void OnActivate()
        {
            _manager.SoundManager.PlayBackgroundMusic("LevelMusic", true, 0.02f);
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
        }
    }
}
