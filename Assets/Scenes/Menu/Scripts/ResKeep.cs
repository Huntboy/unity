using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResKeep: MonoBehaviour
{
    [SerializeField] private Dropdown swing;
    private List<Resolution> swing2;
    private const string swing3 = "ResolutionIndex";

    private void Awake()
    {
        InitializeSwing();
    }

    private void InitializeSwing()
    {
        // Check if there's an existing VideoSettings instance in the scene
        VideoSettings[] videoSettingsInstances = FindObjectsOfType<VideoSettings>();
        if (videoSettingsInstances.Length > 1)
        {
            // Destroy the new instance if there's already one in the scene
            Destroy(gameObject);
            return;
        }

        swing2 = GetSwingAndSwing2Resolutions();

        swing.ClearOptions();

        var swing4 = new List<string>();
        foreach (var swing5 in swing2)
        {
            string swing6 = $"{swing5.width}x{swing5.height}";
            swing4.Add(swing6);
        }

        swing.AddOptions(swing4);

        // Load the saved resolution index from PlayerPrefs
        int swing7 = PlayerPrefs.GetInt(swing3, GetIndexOfCurrentSwing(swing2));
        swing.value = swing7;

        swing.RefreshShownValue();

        // Make sure this VideoSettings object persists between scenes
        DontDestroyOnLoad(gameObject);
    }

    private List<Resolution> GetSwingAndSwing2Resolutions()
    {
        Resolution[] allSwings = Screen.resolutions;
        List<Resolution> swing8 = new List<Resolution>();

        foreach (Resolution swing9 in allSwings)
        {
            float swing10 = (float)swing9.width / swing9.height;

            // Check if the aspect ratio is standard (16:9) or ultrawide (21:9)
            if (Mathf.Approximately(swing10, 16f / 9f) || Mathf.Approximately(swing10, 21f / 9f))
            {
                swing8.Add(swing9);
            }
        }

        return swing8;
    }

    private int GetIndexOfCurrentSwing(List<Resolution> swings)
    {
        for (int i = 0; i < swings.Count; i++)
        {
            if (swings[i].width == Screen.width && swings[i].height == Screen.height)
            {
                return i;
            }
        }

        return 0; // Default to the first resolution if the current resolution is not found
    }

    public void ApplySwingSetting(int swing11)
    {
        Debug.Log("Resolution changed");
        Resolution swing12 = swing2[swing11];
        Screen.SetResolution(swing12.width, swing12.height, Screen.fullScreen);

        // Save the selected resolution index to PlayerPrefs
        PlayerPrefs.SetInt(swing3, swing11);
    }
}
