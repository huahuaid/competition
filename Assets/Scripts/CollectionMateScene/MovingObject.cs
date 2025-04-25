using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingObject : MonoBehaviour
{
    [HideInInspector] public float moveSpeed = 5f;
    private float destroyX = -15f; // ��Ļ�����

    // ȫ�ֿ��Ʊ�������̬����ȫ����Ч��
    public static bool canMove = true;

    void Update()
    {
        if (!canMove) return;
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

    // ȫ�ֿ��Ʒ���
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
