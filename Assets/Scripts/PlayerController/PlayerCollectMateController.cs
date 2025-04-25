using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollectMateController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float yBoundary = 4.5f;
    private Rigidbody2D rb;

    // 角色可否移动的静态控制变量
    public static bool canMove = true;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (!canMove)
        {
            rb.velocity = Vector2.zero; // 立即停止移动
            return;
        }

        float moveInput = Input.GetAxisRaw("Vertical");
        Vector2 movement = new Vector2(0, moveInput * moveSpeed);
        rb.velocity = movement;

        // 限制Y轴移动范围
        float clampedY = Mathf.Clamp(rb.position.y, -yBoundary, yBoundary);
        rb.position = new Vector2(rb.position.x, clampedY);
    }

    public static void EnablePlayerMovement(bool enable)
    {
        canMove = enable;
    }

    // 在 PlayerCollectMateController.cs 中添加重置方法
    void OnDestroy()
    {
        canMove = true;
    }
}
