using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CreditosDotween : MonoBehaviour
{
    public CanvasGroup canvas_group;
    public RectTransform rect_transform;
    public RectTransform scale_transform;

    public float fade_duration = 1.0f;
    public float move_duration = 0.5f;
    public float scale_duration = 0.5f;


    public List<RectTransform> Juego;
    public List<float> moveDurations = new List<float>() { 2f, 5f, 10f, 15f };
    public float moveDistance = 400f;
    public float moveDuration = 1f;

    private void Start()
    {
        canvas_group.DOFade(1, fade_duration).SetEase(Ease.Linear);
        rect_transform.DOAnchorPos(Vector3.zero, move_duration).SetEase(Ease.OutBounce);

        BotonesMover();
    }

    private void BotonesMover()
    {
        for (int i = 0; i < Juego.Count; i++)
        {
            RectTransform buttonRectTransform = Juego[i];
            float moveDuration = moveDurations[i];

            Vector3 currentPosition = buttonRectTransform.anchoredPosition;
            Vector3 newPosition = currentPosition + new Vector3(0f,moveDistance, 0f);
            //buttonRectTransform.DOAnchorPos(newPosition, moveDuration).SetEase(Ease.OutExpo);

            buttonRectTransform.DOAnchorPos(newPosition, moveDuration)
                .SetEase(Ease.OutExpo);
               

        }
    }
}
