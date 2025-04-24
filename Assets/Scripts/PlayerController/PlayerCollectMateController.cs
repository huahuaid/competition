using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollectMateController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float yBoundary = 4.5f;
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        float moveInput = Input.GetAxisRaw("Vertical");
        Vector2 movement = new Vector2(0, moveInput * moveSpeed);
        rb.velocity = movement;

        // œﬁ÷∆Y÷·“∆∂Ø∑∂Œß
        float clampedY = Mathf.Clamp(rb.position.y, -yBoundary, yBoundary);
        rb.position = new Vector2(rb.position.x, clampedY);
    }
}
