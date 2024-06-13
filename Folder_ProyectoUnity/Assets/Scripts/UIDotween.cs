using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class UIDotween : MonoBehaviour
{
    public CanvasGroup canvas_group;
    public RectTransform rect_transform;
    public RectTransform scale_transform;

    public float fade_duration = 1.0f;
    public float move_duration = 0.5f;
    public float scale_duration = 0.5f;
    

    private void Start()
    {
        canvas_group.DOFade(1, fade_duration).SetEase(Ease.Linear);

        rect_transform.DOAnchorPos(Vector3.zero, move_duration).SetEase(Ease.OutBounce);

        scale_transform.DOScale(new Vector3(1.2f, 1.2f, 1.2f), scale_duration)
            .SetEase(Ease.InOutQuad)
            .SetLoops(-1, LoopType.Yoyo);

    }
}
