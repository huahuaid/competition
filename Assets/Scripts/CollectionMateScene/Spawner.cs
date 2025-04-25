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
        int prefabIndex = Random.Range(0, prefabs.Length);

        Vector2 spawnPos = new Vector2(spawnX, lanes[laneIndex]);
        GameObject newObj = Instantiate(prefabs[prefabIndex], spawnPos, Quaternion.identity);

        // 设置移动速度
        var mover = newObj.GetComponent<MovingObject>();
        if (mover) mover.moveSpeed = moveSpeed;
    }

    bool ValidateSpawn()
    {
        if (prefabs == null || prefabs.Length == 0)
        {
            Debug.LogError("未配置生成预制体！");
            return false;
        }
        return true;
    }

    // 新增停止生成的方法
    public void StopSpawning()
    {
        CancelInvoke("SpawnObject");
    }

    // 新增暂停移动的方法
    public void StopMoving()
    {

    }
}
