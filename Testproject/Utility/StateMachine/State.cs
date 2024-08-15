using Microsoft.Xna.Framework;

namespace Testproject.Utility.StateMachine
{
    public abstract class State
    {
        public StateMachine StateMachine;
        public bool isActive { get; private set; }

        public State()
        {

        }

        public State(StateMachine stateMachine)
        {
            StateMachine = stateMachine;
        }

        public void Activate()
        {
            if (isActive) return;
            isActive = true;
            OnPreActivate();
            OnActivate();
        }

        public void Deactivate()
        {
            if (!isActive) return;
            OnPreDeactivate();
            OnDeactivate();
            OnLateDeactivate();
            isActive = false;
        }

        public virtual void OnPreActivate() { }
        protected abstract void OnActivate();
        public virtual void OnUpdate(GameTime time) { }
        public virtual void OnPreDeactivate() { }
        protected abstract void OnDeactivate();
        public virtual void OnLateDeactivate() { }
    }
}
