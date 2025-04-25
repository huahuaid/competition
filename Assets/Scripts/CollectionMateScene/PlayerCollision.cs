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
        // ȷ����ײ������Ч
        if (other == null) return;

        // ������ռ�/�ϰ���
        if (other.CompareTag("Wood") || other.CompareTag("Stone"))
        {
            // ������������ʵ����������Ԥ������Դ��
            if (other.gameObject.scene.IsValid())
            {
                Destroy(other.gameObject);
            }

            // ִ�ж�Ӧ�߼�
            if (other.CompareTag("Wood"))
            {
                scoreManager?.AddWoodWeight(woodWeight);
                scoreManager?.AddBagWholeWeight(woodWeight);
            }
            else if (other.CompareTag("Stone"))
            {
                scoreManager?.AddBagWholeWeight(stoneWeight);
            }
        }
    }
}
