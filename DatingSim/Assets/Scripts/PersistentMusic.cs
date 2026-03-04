using UnityEngine;

public class PersistentMusic : MonoBehaviour
{
    // Create a static variable to hold the instance of this object
    private static PersistentMusic instance = null;

    void Awake()
    {
        // Check if an instance already exists
        if (instance == null)
        {
            // If not, set this as the instance and make it persist
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            // If an instance already exists, destroy this duplicate object
            Destroy(gameObject);
        }
    }
}