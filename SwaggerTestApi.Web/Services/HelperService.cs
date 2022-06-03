namespace WebApplication1.Services
{
    public class HelperService : IHelperService
    {
        public StreamReader GetFileAsStreamReader(string keyName)
        {
            var path = Path.Combine(Directory.GetCurrentDirectory(), "data", keyName);
            return new StreamReader(path);
        }
    }
}
