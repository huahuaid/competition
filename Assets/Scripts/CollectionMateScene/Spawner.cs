using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [Header("生成设置")]
    public GameObject[] prefabs; // 0:木头 1:石头
    public float spawnInterval = 2f;
    public float moveSpeed = 5f;

    [Header("轨道设置")]
    public float topLaneY = 3.5f;
    public float middleLaneY = 0f;
    public float bottomLaneY = -3.5f;
    public float spawnX = 12f; // 屏幕右侧外

    private float[] lanes;

    // 工件预制体索引
    private List<int> availableWorkpieces = new List<int> { 2, 3, 4, 5, 6 };

    void Start()
    {
        lanes = new float[] { topLaneY, middleLaneY, bottomLaneY };
        InvokeRepeating("SpawnObject", 1f, spawnInterval);
    }

    void SpawnObject()
    {
        if (!ValidateSpawn()) return;

        // 随机选择轨道和物体类型
        int laneIndex = Random.Range(0, lanes.Length);
        int prefabIndex = GetNextPrefabIndex();
        //int prefabIndex = Random.Range(0, prefabs.Length);

        Vector2 spawnPos = new Vector2(spawnX, lanes[laneIndex]);
        GameObject newObj = Instantiate(prefabs[prefabIndex], spawnPos, Quaternion.identity);

        // 设置移动速度
        var mover = newObj.GetComponent<MovingObject>();
        if (mover) mover.moveSpeed = moveSpeed;
    }

    int GetNextPrefabIndex()
    {
        //// 优先生成未生成的工件
        //if (availableWorkpieces.Count > 0)
        //{
        //    int index = Random.Range(0, availableWorkpieces.Count);
        //    int workpieceIndex = availableWorkpieces[index];
        //    availableWorkpieces.RemoveAt(index);
        //    return workpieceIndex;
        //}

        //// 生成普通物品（50%木头，50%石头）
        //return Random.Range(0, 2);

        //// 创建包含所有可用选项的临时列表
        List<int> candidates = new List<int>();

        // 始终可以生成木头(0)和石头(1)
        candidates.Add(0);
        candidates.Add(1);

        // 添加未生成的工件
        candidates.AddRange(availableWorkpieces);

        // 随机选择类型
        int index = Random.Range(0, candidates.Count);
        int selectedIndex = candidates[index];

        // 如果是工件则移出可用列表
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
            Debug.LogError("需要配置6个预制体：0-木头 1-石头 2-5-工件");
            return false;
        }
        return true;
    }

    // 新增停止生成的方法
    public void StopSpawning()
    {
        CancelInvoke("SpawnObject");
    }
}
