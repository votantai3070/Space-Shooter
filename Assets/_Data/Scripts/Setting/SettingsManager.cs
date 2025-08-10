using System.IO;
using UnityEngine;

public class SettingsManager : MonoBehaviour
{
    private string settingsFilePath;

    public GameSettings settingData = new GameSettings();
    public static SettingsManager instance;

    void Awake()
    {
        instance = this;
        settingsFilePath = Path.Combine(Application.persistentDataPath, "gamesettings.json");
        LoadSettings();
    }

    public void SaveSettings()
    {
        string json = JsonUtility.ToJson(settingData, true);
        File.WriteAllText(settingsFilePath, json);
    }

    public void LoadSettings()
    {
        if (File.Exists(settingsFilePath))
        {
            string json = File.ReadAllText(settingsFilePath);
            settingData = JsonUtility.FromJson<GameSettings>(json);
        }
        else
        {
            Debug.LogWarning("Settings file not found, using default settings.");
        }
    }
}
