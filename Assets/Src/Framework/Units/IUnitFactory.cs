namespace Framework.Units
{
    public interface IUnitFactory
    {
        public void Load();
        public IUnit Create();
    }
}
