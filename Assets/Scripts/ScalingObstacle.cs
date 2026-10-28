using DG.Tweening;
using UnityEngine;

public class ScalingObstacle : MonoBehaviour
{
    [SerializeField] private Vector3 targetScale = new Vector3(1.8f, 1.8f, 1.8f);
    [SerializeField] private float duration = 2f;
    [SerializeField] private float delay = 0f;

    void Start()
    {
        transform.DOScale(targetScale, duration)
            .SetEase(Ease.InOutSine)
            .SetLoops(-1, LoopType.Yoyo)
            .SetDelay(delay);
    }
}
