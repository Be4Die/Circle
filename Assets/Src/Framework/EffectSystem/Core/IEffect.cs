namespace Framework.EffectSystem.Core
{
    public interface IEffect
    {
        public void Pause();
        public void Pause(float duration);
        public void Unpause();
        public void Restore();
    }
}
