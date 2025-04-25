using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [Header("��������")]
    public GameObject[] prefabs; // 0:ľͷ 1:ʯͷ
    public float spawnInterval = 2f;
    public float moveSpeed = 5f;

    [Header("�������")]
    public float topLaneY = 3.5f;
    public float middleLaneY = 0f;
    public float bottomLaneY = -3.5f;
    public float spawnX = 12f; // ��Ļ�Ҳ���

    private float[] lanes;

    void Start()
    {
        lanes = new float[] { topLaneY, middleLaneY, bottomLaneY };
        InvokeRepeating("SpawnObject", 1f, spawnInterval);
    }

    void SpawnObject()
    {
        if (!ValidateSpawn()) return;

        // ���ѡ��������������
        int laneIndex = Random.Range(0, lanes.Length);
        int prefabIndex = Random.Range(0, prefabs.Length);

        Vector2 spawnPos = new Vector2(spawnX, lanes[laneIndex]);
        GameObject newObj = Instantiate(prefabs[prefabIndex], spawnPos, Quaternion.identity);

        // �����ƶ��ٶ�
        var mover = newObj.GetComponent<MovingObject>();
        if (mover) mover.moveSpeed = moveSpeed;
    }

    bool ValidateSpawn()
    {
        if (prefabs == null || prefabs.Length == 0)
        {
            Debug.LogError("δ��������Ԥ���壡");
            return false;
        }
        return true;
    }

    // ����ֹͣ���ɵķ���
    public void StopSpawning()
    {
        CancelInvoke("SpawnObject");
    }

    // ������ͣ�ƶ��ķ���
    public void StopMoving()
    {

    }
}
