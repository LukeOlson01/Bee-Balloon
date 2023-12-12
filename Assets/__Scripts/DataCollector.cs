using System;
using System.IO;
using UnityEngine;

public class DataCollector : MonoBehaviour
{
    private static string filePath;

    static DataCollector()
    {
        InitializeFilePath();
    }

    private static void InitializeFilePath()
    {
        if (filePath == null)
        {
            // Get the path to the Downloads folder
            string downloadsPath = GetDownloadsPath();

            // Combine the Downloads folder path with the file name
            filePath = Path.Combine(downloadsPath, "PlayerData.txt");
        }
    }

    private static string GetDownloadsPath()
    {
        // Get the path to the Downloads folder based on the platform
        switch (Application.platform)
        {
            case RuntimePlatform.WindowsEditor:
            case RuntimePlatform.WindowsPlayer:
                return Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + "\\Downloads";
            case RuntimePlatform.OSXEditor:
            case RuntimePlatform.OSXPlayer:
                return Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + "/Downloads";
            case RuntimePlatform.LinuxEditor:
            case RuntimePlatform.LinuxPlayer:
                return Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + "/Downloads";
            default:
                return Application.persistentDataPath;
        }
    }

    public static void SavePlayerData(string playerID, DateTime playTime, int score, int lives, float timeRemaining, string feedback)
    {
        InitializeFilePath();

        try
        {
            // Create or append to the text file
            using (StreamWriter writer = File.AppendText(filePath))
            {
                // Write the player data to the file
                writer.WriteLine($"Player ID: {playerID}");
                writer.WriteLine($"Time of day played: {playTime.ToShortTimeString()}");
                writer.WriteLine($"Score: {score}");
                writer.WriteLine($"Lives: {lives}");
                writer.WriteLine($"Time Remaining: {timeRemaining} seconds");
                writer.WriteLine($"Feedback: {feedback}");
                writer.WriteLine("----------------------------------");

                // Flush the stream to ensure all data is written to the file
                writer.Flush();
            }
        }
        catch (Exception e)
        {
            Debug.LogError($"Error saving player data: {e.Message}");
        }
    }
}


