using UnityEngine;
using Unity.Cinemachine;
using UnityEngine.SceneManagement;


public class WinScript : MonoBehaviour
{

    [SerializeField] Transform vCam;
    [SerializeField] Transform winPosition;
    public bool Attract;

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("AtractionField"))
        {
            vCam.GetComponent<CinemachineLockX>().enabled = true;
            Attract = true;
        }
    }

    void Update()
    {
        if (Attract)
        {
            transform.position = Vector3.MoveTowards 
             (transform.position, winPosition.position + Vector3.right * 2, 5 * Time.deltaTime);

            if (SceneManager.GetActiveScene().buildIndex == 3)
            {
                Invoke("LoadNextScene", 4f);
            }
            else
            {
                Invoke("LoadNextScene", 7f);
            }
        }
    }

    void LoadNextScene()
    {
        if (SceneManager.GetActiveScene().buildIndex == 3)
        {
            SceneManager.LoadScene(0);
        }

        else
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}
