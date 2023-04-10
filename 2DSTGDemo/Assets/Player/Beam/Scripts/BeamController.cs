using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeamController : MonoBehaviour
{
    SpriteRenderer spriteRenderer;
    BoxCollider2D col;

    void Awake()
    {
        spriteRenderer= GetComponent<SpriteRenderer>();
        col= GetComponent<BoxCollider2D>();
    }

    private void FixedUpdate()
    {
        col.enabled = spriteRenderer.enabled;
    }

    public void ShotStart()
    {
        spriteRenderer.enabled = true;
    }

    public void ShotEnd()
    {
        spriteRenderer.enabled = false;
    }
}