using UnityEngine;
using UnityEngine.SceneManagement;

public class InputMenu : MonoBehaviour
{
    [SerializeField] int index;
    [SerializeField] AudioSource PressedSound;
    [SerializeField] AudioSource SelectedSound;
    [SerializeField] GameObject Text;
    void Start()
    {

    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W))
        {
            index--;
            Bump();
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.S))
        {
            index++;
            Bump();
        }

        else if (Input.GetKeyDown(KeyCode.Return))
        {
            SelectedSound.Play();
            transform.GetChild(index).GetComponent<AnimButton>().selected = true;

            if (index == 0)
            {
                Invoke("LoadScene", 0.5f);
            }
            else if (index == 1)
            {
                ShowText();
                Invoke("RestartGame", 2f);
            }

            else if (index == 2)
            {
                Invoke("Application.Quit", 1f);
            }
        }
    }

    void Bump()
    {
        PressedSound.Play();

        if (index >= transform.childCount)
        {
            index = 0;
        }

        else if (index < 0)
        {
            index = transform.childCount - 1;
        }

        foreach (Transform child in transform)
        {
            child.GetComponent<AnimButton>().pressed = false;
        }
        transform.GetChild(index).GetComponent<AnimButton>().StopAnimation = false;
        transform.GetChild(index).GetComponent<AnimButton>().pressed = true;
    }

    void LoadScene()
    {
        SceneManager.LoadScene("Story");
    }

    void ShowText()
    {
        Text.SetActive(true);
    }

    void RestartGame()
    {
        SceneManager.LoadScene(0);
    }
}
