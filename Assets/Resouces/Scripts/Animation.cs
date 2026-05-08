using UnityEngine;
using PrimeTween;
using TMPro;

public class Animation : MonoBehaviour
{
    public bool pressed;
    public bool selected;
    public bool StopAnimation;

    void Start()
    {

    }

    void Update()
    {
        if (pressed)
        {
            transform.GetChild(0).gameObject.SetActive(true);
            SetAlpha(1);
            if (!StopAnimation)
            {
                Tween.PunchScale(transform, Vector3.one * 0.3f, duration: 0.5f, frequency: 3);
                StopAnimation = true;
            }
        }

        else
        {
            transform.GetChild(0).gameObject.SetActive(false);
            SetAlpha(0.7f);
        }

        if (selected)
        {
            Tween.Scale(transform, 1.4f, 0.5f);
        }
    }

    void SetAlpha(float alpha)
    {
        Color c = transform.GetChild(1).GetComponent<TextMeshProUGUI>().color;
        c.a = alpha;
        transform.GetChild(1).GetComponent<TextMeshProUGUI>().color = c;
    }
}
