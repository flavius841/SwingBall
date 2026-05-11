using UnityEngine;
using System.Threading.Tasks;
using PrimeTween;
public class StoryScript : MonoBehaviour
{
    [SerializeField] SpriteRenderer Villain;
    [SerializeField] Vector3 targetPosition;
    [SerializeField] Transform VillainTextBox;

    async void Start()
    {
        await PlaySequence();
    }

    async Task PlaySequence()
    {
        await Tween.Alpha(Villain, startValue: 0f, endValue: 1f, duration: 2f);
        await Tween.Position(VillainTextBox, targetPosition, duration: 0.5f, ease: Ease.InOutQuad);
    }
}