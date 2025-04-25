using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollectMateController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float yBoundary = 4.5f;
    private Rigidbody2D rb;

    // ��ɫ�ɷ��ƶ��ľ�̬���Ʊ���
    public static bool canMove = true;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (!canMove)
        {
            rb.velocity = Vector2.zero; // ����ֹͣ�ƶ�
            return;
        }

        float moveInput = Input.GetAxisRaw("Vertical");
        Vector2 movement = new Vector2(0, moveInput * moveSpeed);
        rb.velocity = movement;

        // ����Y���ƶ���Χ
        float clampedY = Mathf.Clamp(rb.position.y, -yBoundary, yBoundary);
        rb.position = new Vector2(rb.position.x, clampedY);
    }

    public static void EnablePlayerMovement(bool enable)
    {
        canMove = enable;
    }

    // �� PlayerCollectMateController.cs ��������÷���
    void OnDestroy()
    {
        canMove = true;
    }
}
