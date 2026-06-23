using UnityEngine;
using UnityEngine.SceneManagement;

public class ContinuousMusic : MonoBehaviour
{
    private static ContinuousMusic instance;

    void Awake()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;

        if ((instance != null && instance != this) || currentSceneIndex == 0)
        {
            Destroy(this.gameObject);
            return;
        }

        instance = this;
        DontDestroyOnLoad(this.gameObject);
    }

    void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.buildIndex == 0)
        {
            instance = null; 
            Destroy(this.gameObject);
        }
    }
}