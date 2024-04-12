using UnityEngine;

public class ToggleGameObject : MonoBehaviour
{
    public GameObject objectToToggle;

    private bool isObjectActive = false;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            isObjectActive = !isObjectActive;

            if (isObjectActive)
            {
                objectToToggle.SetActive(true);
            }
            else
            {
                objectToToggle.SetActive(false);
            }
        }
    }
}

