using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingObject : MonoBehaviour
{
    [HideInInspector] public float moveSpeed = 5f;
    private float destroyX = -15f; // ��Ļ�����

    void Update()
    {
        // ˮƽ�����ƶ�
        transform.Translate(Vector2.left * moveSpeed * Time.deltaTime);

        // ��Ļ������
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
