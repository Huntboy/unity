using UnityEngine;

public class MenuOpen : MonoBehaviour
{
    public GameObject SettingsMenu;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {

            Debug.Log("Escape Pressed");
            SettingsMenu.gameObject.SetActive(!SettingsMenu.gameObject.activeSelf);
        }

    }
}

