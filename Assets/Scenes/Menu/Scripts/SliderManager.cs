using UnityEngine;
using UnityEngine.UI;

public class SliderManager : MonoBehaviour
{
    public Slider[] sliders;
    private string[] sliderKeys;

    void Start()
    {

        sliderKeys = new string[sliders.Length];
        for (int i = 0; i < sliders.Length; i++)
        {
            sliderKeys[i] = "SliderValue_" + i;
        }

        LoadSliderValues();
    }

    void LoadSliderValues()
    {
        for (int i = 0; i < sliders.Length; i++)
        {
            if (PlayerPrefs.HasKey(sliderKeys[i]))
            {
                float savedValue = PlayerPrefs.GetFloat(sliderKeys[i]);
                sliders[i].value = savedValue;
            }
        }
    }

    public void SaveSliderValues()
    {
        for (int i = 0; i < sliders.Length; i++)
        {
            PlayerPrefs.SetFloat(sliderKeys[i], sliders[i].value);
        }
        PlayerPrefs.Save();
    }
}
