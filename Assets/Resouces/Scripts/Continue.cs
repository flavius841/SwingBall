using UnityEngine;
using TMPro;
using System.Collections;

public class Continue : MonoBehaviour
{

    [SerializeField] float typingSpeed = 0.05f;
    [SerializeField] bool isTyping = false;
    [SerializeField] TextMeshProUGUI Text;
    [SerializeField] string fullText = "To be continued...";
    public WinScript winScript;

    void Update()
    {
        if (winScript.Attract)
        {
            StartCoroutine(TypeText(fullText, Text));
        }
    }

    IEnumerator TypeText(string fullText, TextMeshProUGUI textDisplay)
    {
        textDisplay.text = fullText;
        textDisplay.maxVisibleCharacters = 0;
        textDisplay.ForceMeshUpdate();
        int totalCharacters = textDisplay.textInfo.characterCount;


        for (int i = 0; i <= totalCharacters; i++)
        {
            isTyping = true;
            textDisplay.maxVisibleCharacters = i;
            yield return new WaitForSeconds(typingSpeed);
        }

        isTyping = false;

    }
}