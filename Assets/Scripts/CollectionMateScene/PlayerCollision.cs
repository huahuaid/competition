using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerCollision : MonoBehaviour
{
    public ScoreManager scoreManager;
    public GameManager gameManager;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }    

    void OnTriggerEnter2D(Collider2D other)
    {
        //if (other.CompareTag("Wood"))
        //{
        //    scoreManager.AddScore(10);
        //    Destroy(other.gameObject);
        //}
        //else if (other.CompareTag("Stone"))
        //{
        //    gameManager.GameOver();
        //}

        // �������п��ռ�/�ϰ���
        if (other.CompareTag("Wood") || other.CompareTag("Stone"))
        {
            Destroy(other.gameObject);  // ��ײ��������������

            // ������������ִ�в�ͬ�߼�
            if (other.CompareTag("Wood"))
            {
                scoreManager.AddScore(10);
            }
            else if (other.CompareTag("Stone"))
            {
                gameManager.GameOver();
            }
        }
    }
}
