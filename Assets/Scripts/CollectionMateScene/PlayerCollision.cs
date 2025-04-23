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

        // 处理所有可收集/障碍物
        if (other.CompareTag("Wood") || other.CompareTag("Stone"))
        {
            Destroy(other.gameObject);  // 碰撞后立即销毁物体

            // 根据物体类型执行不同逻辑
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
