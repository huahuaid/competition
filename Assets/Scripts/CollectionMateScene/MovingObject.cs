using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingObject : MonoBehaviour
{
    [HideInInspector] public float moveSpeed = 5f;
    private float destroyX = -15f; // 屏幕左侧外

    // 全局控制变量（静态变量全局生效）
    public static bool canMove = true;

    void Update()
    {
        if (!canMove) return;
        // 水平向左移动
        transform.Translate(Vector2.left * moveSpeed * Time.deltaTime);

        // 屏幕外销毁
        if (transform.position.x < destroyX)
        {
            //Destroy(gameObject);
            if (gameObject.scene.IsValid())
            {
                Destroy(gameObject);
            }
        }

    }

    // 全局控制方法
    public void SetMovementFalse()
    {
        Debug.Log("SetMovementFalse");
        canMove = false;
    }

    void OnDestroy()
    {
        canMove = true;
    }
}
