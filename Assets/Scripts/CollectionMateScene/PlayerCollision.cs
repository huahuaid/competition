using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerCollision : MonoBehaviour
{
    public ScoreManager scoreManager;
    public GameManager gameManager;

    //public int bagWholeWeight = 15;
    //private int bagCurWeight = 0;
    public int woodWeight = 1;
    public int stoneWeight = 5;
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
        // 确保碰撞物体有效
        if (other == null) return;

        // 处理可收集/障碍物
        if (other.CompareTag("Wood") || other.CompareTag("Stone") || other.CompareTag("Workpiece_0") ||
            other.CompareTag("Workpiece_1") || other.CompareTag("Workpiece_2") ||
            other.CompareTag("Workpiece_3") || other.CompareTag("Workpiece_4"))
        {
            // 立即销毁物体实例（不销毁预制体资源）
            if (other.gameObject.scene.IsValid())
            {
                Destroy(other.gameObject);
            }

            // 执行对应逻辑
            if (other.CompareTag("Wood"))
            {
                scoreManager?.AddWoodWeight(woodWeight);
                scoreManager?.AddBagWholeWeight(woodWeight);
            }
            else if (other.CompareTag("Stone"))
            {
                scoreManager?.AddBagWholeWeight(stoneWeight);
            }
            else if (other.CompareTag("Workpiece_1"))
            {
                Debug.Log("Workpiece_1");
                scoreManager?.AddWoodWeight(woodWeight);
                scoreManager?.AddBagWholeWeight(woodWeight);
                scoreManager?.CollectWorkPieces(1);
            }
            else if (other.CompareTag("Workpiece_2"))
            {
                Debug.Log("Workpiece_2");
                scoreManager?.AddWoodWeight(woodWeight);
                scoreManager?.AddBagWholeWeight(woodWeight);
                scoreManager?.CollectWorkPieces(2);
            }
            else if (other.CompareTag("Workpiece_3"))
            {
                Debug.Log("Workpiece_3");
                scoreManager?.AddWoodWeight(woodWeight);
                scoreManager?.AddBagWholeWeight(woodWeight);
                scoreManager?.CollectWorkPieces(3);
            }
            else if (other.CompareTag("Workpiece_4"))
            {
                Debug.Log("Workpiece_4");
                scoreManager?.AddWoodWeight(woodWeight);
                scoreManager?.AddBagWholeWeight(woodWeight);
                scoreManager?.CollectWorkPieces(4);
            }
            else if (other.CompareTag("Workpiece_0"))
            {
                Debug.Log("Workpiece_0");
                scoreManager?.AddWoodWeight(woodWeight);
                scoreManager?.AddBagWholeWeight(woodWeight);
                scoreManager?.CollectWorkPieces(0);
            }
        }
    }
}
