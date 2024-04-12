using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class SliderValueDisplay : MonoBehaviour
{
    public Slider slider;
    public TextMeshProUGUI text;

    void Start()
    {
        UpdateText();
    }

    public void UpdateText()
    {
        text.text = slider.value.ToString("F2");
    }
}
