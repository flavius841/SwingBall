using UnityEngine;
using PrimeTween;
using TMPro;
using System.Collections.Generic;
using System.Collections;

public class StoryScript : MonoBehaviour
{
    [SerializeField] SpriteRenderer Villain;
    [SerializeField] GameObject Hero;
    [SerializeField] Vector3 VTBtargetPosition;
    [SerializeField] Vector3 HTBtargetPosition;
    [SerializeField] Vector3 HeroTargetPosition;
    [SerializeField] Vector3 targetScale;
    [SerializeField] Transform VillainTextBox;
    [SerializeField] Transform HeroTextBox;
    [SerializeField] TextMeshPro textDisplayVillain;
    [SerializeField] TextMeshPro textDisplayHero;
    [SerializeField] float typingSpeed = 0.05f;
    private bool isTyping = false;
    [SerializeField] bool StartMonologue;
    [SerializeField] GameObject NextButton;
    [SerializeField] int currentIndex;
    [SerializeField] bool StoryDone;
    [SerializeField] bool MonologueActive;


    private string Part1 = "Finally my plan is complete! The world will be mine!";
    private string Part2 = "I don't think so!";
    private string Part3 = "Aaarrghhh! Not you again!";
    private string Part4 = "You won't stop me this time!";
    private string Part5 = "My plan is unstoppable!";
    private string Part6 = "The only way to stop me is to destroy my secret weapon!";

    private List<string> MonologueParts = new List<string>();

    void Awake()
    {
        MonologueParts.Add(Part3);
        MonologueParts.Add(Part4);
        MonologueParts.Add(Part5);
        MonologueParts.Add(Part6);
    }

    void Start()
    {
        PlayStory();
    }

    void Update()
    {
        if (isTyping)
        {
            NextButton.SetActive(false);
        }

        else if (MonologueActive)
        {
            NextButton.SetActive(true);
        }

        if (StartMonologue)
        {
            StartCoroutine(TypeText(Part3, textDisplayVillain));
            NextButton.SetActive(true);
            MonologueActive = true;
            StartMonologue = false;
        }
    }

    void PlayStory()
    {
        float textDuration1 = Part1.Length * 0.05f + 1f;
        float textDuration2 = Part2.Length * 0.05f + 1f;
        Vector3 originalPositionVTB = VillainTextBox.position;
        Vector3 originalPositionHTB = HeroTextBox.position;

        Sequence.Create()
            .Chain(Tween.Alpha(Villain, startValue: 0f, endValue: 1f, duration: 2f))

            .Chain(Tween.Position(VillainTextBox, VTBtargetPosition, duration: 0.5f, ease: Ease.InOutQuad))
            .Group(Tween.Scale(VillainTextBox, targetScale, duration: 0.5f, ease: Ease.InOutQuad))

            .ChainCallback(() => StartCoroutine(TypeText(Part1, textDisplayVillain)))
            .ChainDelay(textDuration1)

            .Chain(Tween.Position(Hero.transform, HeroTargetPosition, duration: 1f, ease: Ease.InOutQuad))

            .ChainCallback(() =>
             {
                 Tween.Position(
                     Hero.transform,
                     HeroTargetPosition - new Vector3(0.3f, 0.3f, 0),
                     duration: 1f,
                     ease: Ease.InOutQuad,
                     cycles: -1,
                     cycleMode: CycleMode.Yoyo
                 );
             })
            .Group(Tween.Position(VillainTextBox, originalPositionVTB, duration: 0.5f, ease: Ease.InOutQuad))
            .Group(Tween.Scale(VillainTextBox, 0, duration: 0.5f, ease: Ease.InOutQuad))

            .Chain(Tween.Position(HeroTextBox, HTBtargetPosition, duration: 0.5f, ease: Ease.InOutQuad))
            .Group(Tween.Scale(HeroTextBox, targetScale, duration: 0.5f, ease: Ease.InOutQuad))

            .ChainCallback(() => StartCoroutine(TypeText(Part2, textDisplayHero)))
            .ChainDelay(textDuration2)
            .ChainCallback(() => textDisplayVillain.text = "")

            .Chain(Tween.Position(VillainTextBox, VTBtargetPosition, duration: 0.5f, ease: Ease.InOutQuad))
            .Group(Tween.Scale(VillainTextBox, targetScale, duration: 0.5f, ease: Ease.InOutQuad))
            .Group(Tween.Position(HeroTextBox, originalPositionHTB, duration: 0.5f, ease: Ease.InOutQuad))
            .Group(Tween.Scale(HeroTextBox, 0, duration: 0.5f, ease: Ease.InOutQuad))

            .ChainCallback(() => StartMonologue = true);
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

    public void NextButtonFunc()
    {
        if (currentIndex < MonologueParts.Count - 1 && !isTyping)
        {
            currentIndex++;
            StartCoroutine(TypeText(MonologueParts[currentIndex], textDisplayVillain));
        }

        else if (currentIndex == MonologueParts.Count - 1 && !isTyping)
        {
            StoryDone = true;
        }
    }
}