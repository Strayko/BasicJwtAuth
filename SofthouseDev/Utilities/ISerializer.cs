namespace SofthouseDev.Utilities
{
    public interface ISerializer
    {
        void SaveToFile<T>(T model, SerializationFormat format, string filePath);
    }
}
