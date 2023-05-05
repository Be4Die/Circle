using System.Threading.Tasks;

namespace Framework.Circle
{
    internal class ColorsDataProvider : LocalAssetLoader
    {
        public Task<ColorsData> Load()
        {
            return LoadInternal<ColorsData>("MainColors");
        }

        public void Unload() 
        {
            UnloadInternal();
        }
    }
}
