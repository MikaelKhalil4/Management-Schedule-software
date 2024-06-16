using MKproject;
using System;
using System.IO;

public static class AppPaths
{
    public static readonly string BaseDirectory = AppDomain.CurrentDomain.BaseDirectory;

    public static string DatabasePath => Path.Combine(BaseDirectory, GetAppConfig().GetConnectionString());
    public static string ProfileImagesPath => Path.Combine(BaseDirectory, GetAppConfig().GetImagesDirectory());

    private static AppConfig GetAppConfig()
    {
        return new AppConfig();
    }

    public static void EnsureDirectoriesExist()
    {
        // Ensure the Database directory exists
        string dbDirectory = Path.GetDirectoryName(DatabasePath);
        if (!Directory.Exists(dbDirectory))
        {
            Directory.CreateDirectory(dbDirectory);
        }

        // Ensure the Images directory exists
        if (!Directory.Exists(ProfileImagesPath))
        {
            Directory.CreateDirectory(ProfileImagesPath);
        }
    }
}