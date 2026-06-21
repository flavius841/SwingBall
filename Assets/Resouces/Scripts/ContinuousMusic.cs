using UnityEngine;

public class ContinuousMusic : MonoBehaviour
{
    // This creates a static reference to our music player
    private static ContinuousMusic instance;

    void Awake()
    {
        // 1. Check if an instance of this object already exists in the game
        if (instance != null && instance != this)
        {
            // If it does, destroy this new duplicate immediately!
            Destroy(this.gameObject);
            return;
        }

        // 2. If no instance exists, make THIS the official instance
        instance = this;

        // 3. Tell Unity not to destroy this object when loading a new scene
        DontDestroyOnLoad(this.gameObject);
    }
}