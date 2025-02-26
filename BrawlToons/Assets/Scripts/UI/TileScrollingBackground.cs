using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class TileScrollingBackground : MonoBehaviour
{
    private float tweenDuration = 10f;
    private void Awake()
    {
        Image image = GetComponent<Image>();
        RectTransform rectTransform = GetComponent<RectTransform>();

        var posTween = DOTween.To(
            () => rectTransform.anchoredPosition, x => rectTransform.anchoredPosition = x,
            new Vector2(
                image.sprite.texture.width * 0.5f,
                image.sprite.texture.height * 0.5f),
                tweenDuration);

        posTween.SetEase(Ease.Linear);
        posTween.SetLoops(-1, LoopType.Restart);

        var sizeTween = DOTween.To(
            () => rectTransform.sizeDelta, x => rectTransform.sizeDelta = x,
            new Vector2(
                image.sprite.texture.width * 0.5f,
                image.sprite.texture.height * 0.5f),
                tweenDuration);

        sizeTween.SetEase(Ease.Linear);
        sizeTween.SetLoops(-1, LoopType.Restart);

    }
}
