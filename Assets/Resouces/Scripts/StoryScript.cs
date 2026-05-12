using UnityEngine;
using PrimeTween;
using TMPro;
using System.Collections.Generic;
using System.Collections;

public class StoryScript : MonoBehaviour
{
    [SerializeField] SpriteRenderer Villain;
    [SerializeField] Vector3 targetPosition;
    [SerializeField] Vector3 targetScale;
    [SerializeField] Transform VillainTextBox;
    [SerializeField] TextMeshPro textDisplayVillain;
    [SerializeField] TextMeshPro textDisplayHero;
    [SerializeField] float typingSpeed = 0.05f;
    private bool isTyping = false;

    private string Part1 = "Finally my plan is complete! The world will be mine!";
    private string Part2 = "I don't think so!";
    private string Part3 = "Aaarrghhh! Not you again!";
    private string Part4 = "You won't stop me this time!";
    private string Part5 = "My plan is unstoppable!";
    private string Part6 = "The only way to stop me is to destroy my secret weapon!";

    void Start()
    {
        PlayStory();
    }

    void PlayStory()
    {
        Sequence.Create()
            .Chain(Tween.Alpha(Villain, startValue: 0f, endValue: 1f, duration: 2f))

            .Chain(Tween.Position(VillainTextBox, targetPosition, duration: 0.5f, ease: Ease.InOutQuad))
            .Group(Tween.Scale(VillainTextBox, targetScale, duration: 0.5f, ease: Ease.InOutQuad))
            .ChainCallback(() => StartCoroutine(TypeText(Part1, textDisplayVillain)));



        // .Chain(for (int i = 0; i < ; i++)
        // {
        //     textDisplayVillain.text += Part1[i];
        //     yield return new WaitForSeconds(typingSpeed);
        // })
    }

    IEnumerator TypeText(string fullText, TextMeshPro textDisplay)
    {
        textDisplay.text = "";

        foreach (char letter in fullText.ToCharArray())
        {
            textDisplay.text += letter;
            yield return new WaitForSeconds(typingSpeed);
            isTyping = true;
        }

        isTyping = false;
    }
}