using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class BarrierImageController : MonoBehaviour
{
    SpriteRenderer spriteRenderer;
    CircleCollider2D col;

    Color OpenColor = new Color(1, 1, 1, 0.9f);
    Color closeColor = new Color(1, 1, 1, 0);

    [SerializeField, Range(0f, 0.5f)]
    float colorFadeTime = 0.2f;
    [SerializeField, Range(0f, 0.3f)]
    float scaleFadeTime = 0.1f;

    Ease ease = Ease.OutCubic;

    void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        col = GetComponent<CircleCollider2D>();
        spriteRenderer.enabled = false;
    }

    private void FixedUpdate()
    {
        col.enabled = spriteRenderer.enabled;
    }

    public void Open()
    {
        spriteRenderer.enabled = true;

        transform.localScale = Vector3.zero;
        spriteRenderer.color = closeColor;

        transform.DOScale(Vector3.one, scaleFadeTime).SetEase(ease);
        spriteRenderer.DOColor(OpenColor, colorFadeTime).SetEase(ease);
    }

    public void Close()
    {
        transform.localScale = Vector3.one;
        spriteRenderer.color = OpenColor;

        transform.DOScale(Vector3.zero, scaleFadeTime).SetEase(ease);
        spriteRenderer.DOColor(closeColor, colorFadeTime).SetEase(ease)
                      .OnComplete(() =>
                      {
                          spriteRenderer.enabled = false;
                      });
    }
}