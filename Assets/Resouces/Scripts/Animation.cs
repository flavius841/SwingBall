using UnityEngine;
using PrimeTween;

public class Animation : MonoBehaviour
{
    public bool pressed;
    public bool selected;
    void Start()
    {

        // Tween.Scale(transform, 1.3f, 0.5f);
        // Tween.Scale(transform, 0.9f, 0.5f);
        // Tween.Scale(transform, 1.1f, 0.5f);
        // Tween.Scale(transform, 1f, 0.5f);
    }

    void Update()
    {
        if (pressed)
        {
            Tween.PunchScale(transform, Vector3.one * 0.3f, duration: 0.5f, frequency: 3);
            pressed = false;
        }

        if (selected)
        {
            // Tween.Scale(transform, 1.3f, 0.5f);
            // Tween.Scale(transform, 0.9f, 0.5f);
            // Tween.Scale(transform, 1.1f, 0.5f);
            // Tween.Scale(transform, 1f, 0.5f);
            // selected = false;
        }


    }
}
