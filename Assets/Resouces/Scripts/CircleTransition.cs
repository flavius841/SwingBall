using UnityEngine;
using System.Collections;

public class CircleTransition : MonoBehaviour
{
    public Material transitionMaterial;
    public float transitionSpeed = 1.0f;
    public WinScript winScript;
    [SerializeField] bool isTransitioning = false;

    void Start()
    {
        transitionMaterial.SetFloat("_Radius", 0f);
        OpenScreen();
    }

    void Update()
    {
        if (winScript.Attract && !isTransitioning)
        {
            isTransitioning = true;
            Invoke("CloseScreen", 3f);
        }
    }

    public void CloseScreen()
    {
        StartCoroutine(AnimateTransition(1.5f, 0f));
    }

    public void OpenScreen()
    {
        StartCoroutine(AnimateTransition(0f, 1.5f));
    }

    private IEnumerator AnimateTransition(float startRadius, float endRadius)
    {
        float timeElapsed = 0f;

        while (timeElapsed < transitionSpeed)
        {
            timeElapsed += Time.deltaTime;
            float currentRadius = Mathf.Lerp(startRadius, endRadius, timeElapsed / transitionSpeed);
            
            transitionMaterial.SetFloat("_Radius", currentRadius);
            yield return null;
        }

        transitionMaterial.SetFloat("_Radius", endRadius);
    }
}