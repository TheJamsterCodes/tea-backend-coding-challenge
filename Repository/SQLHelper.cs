using System.Reflection;

namespace TEABackEndCodingChallenge;

public static class SQLHelper
{
    private static readonly string _location;

    static SQLHelper()
    {
        _location = Assembly.GetExecutingAssembly().Location;
    }
        
    public static string GetSQLFromFile(this string fileName)
    {
        string currDir = Path.GetDirectoryName(_location);
        string filePath = Path.Combine(currDir, "Repository", fileName);
        return File.ReadAllText(filePath);
    }
}
