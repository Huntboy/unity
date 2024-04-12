using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class VideoSettings : MonoBehaviour
{
    [SerializeField] private TMP_Dropdown resolutionDropdown;

    private List<Resolution> filteredResolutions;

    void Start()
    {
        InitializeResolutionDropdown();
    }

    void InitializeResolutionDropdown()
    {
        filteredResolutions = GetUniqueResolutions();

        resolutionDropdown.ClearOptions();

        var options = new List<string>();
        foreach (var resolution in filteredResolutions)
        {
            string resolutionOption = $"{resolution.width}x{resolution.height}";
            options.Add(resolutionOption);
        }

        resolutionDropdown.AddOptions(options);

        int currentResolutionIndex = GetIndexOfCurrentResolution(filteredResolutions);
        resolutionDropdown.value = currentResolutionIndex;

        resolutionDropdown.RefreshShownValue();
    }

    List<Resolution> GetUniqueResolutions()
    {
        Resolution[] allResolutions = Screen.resolutions;
        HashSet<string> resolutionSet = new HashSet<string>(); // Use HashSet to ensure uniqueness
        List<Resolution> uniqueResolutions = new List<Resolution>();

        foreach (Resolution resolution in allResolutions)
        {
            float aspectRatio = (float)resolution.width / resolution.height;
            if (Mathf.Approximately(aspectRatio, 16f / 9f) && resolutionSet.Add($"{resolution.width}x{resolution.height}"))
            {
                uniqueResolutions.Add(resolution);
            }
        }

        return uniqueResolutions;
    }

    int GetIndexOfCurrentResolution(List<Resolution> resolutions)
    {
        for (int i = 0; i < resolutions.Count; i++)
        {
            if (resolutions[i].width == Screen.width && resolutions[i].height == Screen.height)
            {
                return i;
            }
        }

        return 0; // Default to the first resolution if the current resolution is not found
    }

    public void SetResolution(int resolutionIndex)
    {
        Debug.Log("Resolution changed");
        Resolution resolution = filteredResolutions[resolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    }
}
