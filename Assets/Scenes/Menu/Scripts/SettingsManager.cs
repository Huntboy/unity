using UnityEngine;

public class SettingsManager : MonoBehaviour
{
    // Static instance to allow access from other scripts
    public static SettingsManager instance;

    // Player settings variables
    public float fov;
    public float musicVolume;
    public float ambianceVolume;

    void Awake()
    {
        // Singleton pattern to ensure only one instance exists
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject); // Keep this GameObject alive between scenes
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Save the player settings
    public void SaveSettings()
    {
        PlayerPrefs.SetFloat("FOV", fov);
        PlayerPrefs.SetFloat("MusicVolume", musicVolume);
        PlayerPrefs.SetFloat("AmbianceVolume", ambianceVolume);
        PlayerPrefs.Save();
    }

    // Load the player settings
    public void LoadSettings()
    {
        if (PlayerPrefs.HasKey("FOV"))
        {
            fov = PlayerPrefs.GetFloat("FOV");
        }
        else
        {
            fov = 60f; // Default FOV value
            Debug.LogWarning("FOV key not found in PlayerPrefs. Using default FOV value.");
        }

        if (PlayerPrefs.HasKey("MusicVolume"))
        {
            musicVolume = PlayerPrefs.GetFloat("MusicVolume");
        }
        else
        {
            musicVolume = 0.5f; // Default music volume value
            Debug.LogWarning("MusicVolume key not found in PlayerPrefs. Using default music volume value.");
        }

        if (PlayerPrefs.HasKey("AmbianceVolume"))
        {
            ambianceVolume = PlayerPrefs.GetFloat("AmbianceVolume");
        }
        else
        {
            ambianceVolume = 0.5f; // Default ambiance volume value
            Debug.LogWarning("AmbianceVolume key not found in PlayerPrefs. Using default ambiance volume value.");
        }

        // Debug log loaded settings
        Debug.Log("Loaded settings - FOV: " + fov + ", MusicVolume: " + musicVolume + ", AmbianceVolume: " + ambianceVolume);
    }

    // Method to update FOV from slider
    public void UpdateFOV(float newFOV)
    {
        fov = newFOV;
    }

    // Method to update music volume from slider
    public void UpdateMusicVolume(float newVolume)
    {
        musicVolume = newVolume;
    }

    // Method to update ambiance volume from slider
    public void UpdateAmbianceVolume(float newVolume)
    {
        ambianceVolume = newVolume;
    }
}
