using UnityEngine;

public class MenuManager : MonoBehaviour
{
    public static bool gameIsPaused;
    public void ExitGame()
    {
        Application.Quit();
    }
}
