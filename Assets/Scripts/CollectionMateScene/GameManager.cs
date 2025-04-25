using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    // �������
    public Spawner spawner;
    public ScoreManager scoreManager;

    // ��������ӳ�ʱ��
    public float restartDelay = 2f;

    // Start is called before the first frame update
    void Start()
    {
        // ���¼�����
        scoreManager.OnThresholdReached += HandleGameOver;
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    // ��Ϸ��������
    private void HandleGameOver()
    {
        // ֹͣ����������
        spawner.StopSpawning();

        // ���������ƶ�����
        MovingObject.canMove = false;

        // ֹͣ��ҿ���
        PlayerCollectMateController.EnablePlayerMovement(false);

        if (scoreManager.IsBagFull && !scoreManager.IsEnoughWood)
        {
            // ʧ�������߼�
            Debug.Log("����������ľͷ���㣬��Ϸʧ��");
            StartCoroutine(RestartGame());
        }
        else
        {
            // �ɹ������߼�
            Debug.Log("�ɹ��ռ��㹻ľͷ��");
            //scoreManager.success.SetActive(true);
        }

        // ����������������Ϸ�����߼���������ʾ������棩
        Debug.Log("��Ϸ������");
    }

    // �����¼�����
    void OnDestroy()
    {
        scoreManager.OnThresholdReached -= HandleGameOver;
    }

    // ����Э�̿�������
    IEnumerator RestartGame()
    {
        yield return new WaitForSeconds(restartDelay);

        // ���þ�̬����
        MovingObject.canMove = true;
        PlayerCollectMateController.EnablePlayerMovement(true);

        // ���¼��س���
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

}
