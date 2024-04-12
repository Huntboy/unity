using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PersistentSliderSettings : MonoBehaviour
{
    // Define the sliders and PlayerPrefs keys for different settings
    public Slider fovSlider;
    public Slider audioSlider;
    private string fovPlayerPrefsKey = "FOV";
    private string audioVolumePlayerPrefsKey = "AudioVolume";

    void Start()
    {
        Debug.Log("PersistentSliderSettings: Start() called.");

        // Load FOV value from PlayerPrefs
        float savedFOV = PlayerPrefs.GetFloat(fovPlayerPrefsKey, 60f); // Default value 60 if not found
        Debug.Log("PersistentSliderSettings: Loaded FOV from PlayerPrefs: " + savedFOV);
        ApplyFOV(savedFOV);

        // Load audio volume value from PlayerPrefs
        float savedAudioVolume = PlayerPrefs.GetFloat(audioVolumePlayerPrefsKey, 0.5f); // Default value 0.5 if not found
        Debug.Log("PersistentSliderSettings: Loaded Audio Volume from PlayerPrefs: " + savedAudioVolume);
        ApplyAudioVolume(savedAudioVolume);

        // Subscribe to scene loaded event to ensure settings persistence across scenes
        SceneManager.sceneLoaded += OnSceneLoaded;

        // Subscribe to sliders' OnValueChanged events
        fovSlider.onValueChanged.AddListener(UpdateFOV);
        audioSlider.onValueChanged.AddListener(UpdateAudioVolume);
    }

    void OnDestroy()
    {
        Debug.Log("PersistentSliderSettings: OnDestroy() called.");

        // Unsubscribe from the scene loaded event
        SceneManager.sceneLoaded -= OnSceneLoaded;

        // Unsubscribe from sliders' OnValueChanged events
        fovSlider.onValueChanged.RemoveListener(UpdateFOV);
        audioSlider.onValueChanged.RemoveListener(UpdateAudioVolume);
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        Debug.Log("PersistentSliderSettings: OnSceneLoaded() called for scene: " + scene.name + ", mode: " + mode);

        // After a scene is loaded, apply settings to ensure consistency
        float savedFOV = PlayerPrefs.GetFloat(fovPlayerPrefsKey, 60f); // Default value 60 if not found
        Debug.Log("PersistentSliderSettings: Loaded FOV from PlayerPrefs: " + savedFOV);
        ApplyFOV(savedFOV);

        float savedAudioVolume = PlayerPrefs.GetFloat(audioVolumePlayerPrefsKey, 0.5f); // Default value 0.5 if not found
        Debug.Log("PersistentSliderSettings: Loaded Audio Volume from PlayerPrefs: " + savedAudioVolume);
        ApplyAudioVolume(savedAudioVolume);
    }

    // Method to apply FOV to the main camera in the scene
    void ApplyFOV(float fov)
    {
        Debug.Log("PersistentSliderSettings: Applying FOV: " + fov);

        Camera mainCamera = Camera.main;
        if (mainCamera != null)
        {
            mainCamera.fieldOfView = fov;
            Debug.Log("PersistentSliderSettings: Applied FOV to main camera.");
        }
        else
        {
            Debug.LogWarning("PersistentSliderSettings: No main camera found in the scene.");
        }
    }

    // Method to apply audio volume setting
    void ApplyAudioVolume(float volume)
    {
        Debug.Log("PersistentSliderSettings: Applying Audio Volume: " + volume);

        // Implement your audio volume setting logic here
    }

    // Method called to update FOV and save it to PlayerPrefs
    public void UpdateFOV(float newFOV)
    {
        Debug.Log("PersistentSliderSettings: UpdateFOV() called with new FOV: " + newFOV);

        ApplyFOV(newFOV);
        PlayerPrefs.SetFloat(fovPlayerPrefsKey, newFOV);
        PlayerPrefs.Save();
        Debug.Log("PersistentSliderSettings: Saved new FOV to PlayerPrefs: " + newFOV);
    }

    // Method called to update audio volume and save it to PlayerPrefs
    public void UpdateAudioVolume(float newVolume)
    {
        Debug.Log("PersistentSliderSettings: UpdateAudioVolume() called with new volume: " + newVolume);

        ApplyAudioVolume(newVolume);
        PlayerPrefs.SetFloat(audioVolumePlayerPrefsKey, newVolume);
        PlayerPrefs.Save();
        Debug.Log("PersistentSliderSettings: Saved new Audio Volume to PlayerPrefs: " + newVolume);
    }
}
