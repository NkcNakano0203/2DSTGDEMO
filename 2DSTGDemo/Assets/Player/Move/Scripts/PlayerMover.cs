using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMover : MonoBehaviour
{
    Rigidbody2D rb2D;
    [SerializeField]
    float moveSpeed = 1;

    private void Awake()
    {
        rb2D = GetComponent<Rigidbody2D>();
    }

    Vector2 inputAxis = Vector2.zero;
    void Update()
    {
        float xInput = Input.GetAxisRaw("Horizontal");
        float yInput = Input.GetAxisRaw("Vertical");
        inputAxis = new Vector2(xInput, yInput);
    }

    private void FixedUpdate()
    {
        if (inputAxis.magnitude <= 0) return;

        Vector2 currentPos = transform.position;
        Vector2 movePos = currentPos + inputAxis * moveSpeed;
        rb2D.MovePosition(movePos);
    }
}
