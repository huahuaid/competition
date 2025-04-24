using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingObject : MonoBehaviour
{
    [HideInInspector] public float moveSpeed = 5f;
    private float destroyX = -15f; // 屏幕左侧外

    void Update()
    {
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
}
