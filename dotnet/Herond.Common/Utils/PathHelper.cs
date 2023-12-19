namespace Herond.Common.Utils;

public static class PathHelper
{
    public static void EnsureDirectory(string path) {
        if (!Directory.Exists(path))
            Directory.CreateDirectory(path);
    }
    
    public static string BaseDirectory => AppDomain.CurrentDomain.BaseDirectory;
    
    public static string Resolve(params string[] fileName)
        => Path.Combine(BaseDirectory, Path.Combine(fileName));
}