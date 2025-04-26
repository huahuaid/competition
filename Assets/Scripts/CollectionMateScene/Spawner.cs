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

    // ����Ԥ��������
    private List<int> availableWorkpieces = new List<int> { 2, 3, 4, 5, 6 };

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
        int prefabIndex = GetNextPrefabIndex();
        //int prefabIndex = Random.Range(0, prefabs.Length);

        Vector2 spawnPos = new Vector2(spawnX, lanes[laneIndex]);
        GameObject newObj = Instantiate(prefabs[prefabIndex], spawnPos, Quaternion.identity);

        // �����ƶ��ٶ�
        var mover = newObj.GetComponent<MovingObject>();
        if (mover) mover.moveSpeed = moveSpeed;
    }

    int GetNextPrefabIndex()
    {
        //// ��������δ���ɵĹ���
        //if (availableWorkpieces.Count > 0)
        //{
        //    int index = Random.Range(0, availableWorkpieces.Count);
        //    int workpieceIndex = availableWorkpieces[index];
        //    availableWorkpieces.RemoveAt(index);
        //    return workpieceIndex;
        //}

        //// ������ͨ��Ʒ��50%ľͷ��50%ʯͷ��
        //return Random.Range(0, 2);

        //// �����������п���ѡ�����ʱ�б�
        List<int> candidates = new List<int>();

        // ʼ�տ�������ľͷ(0)��ʯͷ(1)
        candidates.Add(0);
        candidates.Add(1);

        // ���δ���ɵĹ���
        candidates.AddRange(availableWorkpieces);

        // ���ѡ������
        int index = Random.Range(0, candidates.Count);
        int selectedIndex = candidates[index];

        // ����ǹ������Ƴ������б�
        if (selectedIndex >= 2 && selectedIndex <= 6)
        {
            availableWorkpieces.Remove(selectedIndex);
        }

        return selectedIndex;
    }

    bool ValidateSpawn()
    {
        if (prefabs == null || prefabs.Length == 0)
        {
            Debug.LogError("��Ҫ����6��Ԥ���壺0-ľͷ 1-ʯͷ 2-5-����");
            return false;
        }
        return true;
    }

    // ����ֹͣ���ɵķ���
    public void StopSpawning()
    {
        CancelInvoke("SpawnObject");
    }
}
