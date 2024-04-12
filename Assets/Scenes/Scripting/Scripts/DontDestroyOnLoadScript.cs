using UnityEngine;

public class DontDestroyOnLoadScript : MonoBehaviour
{
    private static DontDestroyOnLoadScript instance;

    private void Awake()
    {
        // Check if an instance already exists
        if (instance == null)
        {
            // If not, set the instance to this object
            instance = this;
            // Don't destroy this object when loading new scenes
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            // If an instance already exists, destroy this object
            Destroy(gameObject);
        }
    }
}