using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class GravController : MonoBehaviour
{
    [SerializeField]
    float gravStartTime = 1;
    [SerializeField]
    float effectDuration = 5;

    [SerializeField]
    SpriteRenderer centerModel;

    [SerializeField]
    SpriteRenderer effectModel;

    CircleCollider2D col;
    Rigidbody2D rb2d;

    private bool canFire = true;
    public bool CanFire => canFire;

    void Awake()
    {
        col = GetComponent<CircleCollider2D>();
        rb2d = GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        centerModel.enabled = false;
        effectModel.enabled = false;
    }

    private void FixedUpdate()
    {
        col.enabled = centerModel.enabled;
        if (canFire) { transform.localPosition = Vector3.zero; }
    }
    //0.2~1
    public void OnFire(float shotSpeed)
    {
        canFire = false;
        float endPos = shotSpeed * gravStartTime;
        centerModel.enabled = true;
        col.radius = 0.2f;

        rb2d.DOMoveY(endPos, gravStartTime).SetEase(Ease.InOutExpo)
            .OnComplete(() =>
            {
                StartCoroutine(effect());
            });
    }

    IEnumerator effect()
    {
        col.radius = 1.0f;
        effectModel.enabled = true;
        yield return new WaitForSeconds(effectDuration);
        effectModel.enabled = false;
        centerModel.enabled = false;
        canFire = true;
    }
}