using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    // 组件引用
    public Spawner spawner;
    public ScoreManager scoreManager;

    // 添加重启延迟时间
    public float restartDelay = 2f;

    // Start is called before the first frame update
    void Start()
    {
        // 绑定事件监听
        scoreManager.OnThresholdReached += HandleGameOver;
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    // 游戏结束处理
    private void HandleGameOver()
    {
        // 停止生成新物体
        spawner.StopSpawning();

        // 冻结所有移动物体
        MovingObject.canMove = false;

        // 停止玩家控制
        PlayerCollectMateController.EnablePlayerMovement(false);

        if (scoreManager.IsBagFull && !scoreManager.IsEnoughWood)
        {
            // 失败重启逻辑
            Debug.Log("背包已满但木头不足，游戏失败");
            StartCoroutine(RestartGame());
        }
        else
        {
            // 成功结束逻辑
            Debug.Log("成功收集足够木头！");
            //scoreManager.success.SetActive(true);
        }

        // 这里可以添加其他游戏结束逻辑（比如显示结算界面）
        Debug.Log("游戏结束！");
    }

    // 清理事件订阅
    void OnDestroy()
    {
        scoreManager.OnThresholdReached -= HandleGameOver;
    }

    // 新增协程控制重启
    IEnumerator RestartGame()
    {
        yield return new WaitForSeconds(restartDelay);

        // 重置静态变量
        MovingObject.canMove = true;
        PlayerCollectMateController.EnablePlayerMovement(true);

        // 重新加载场景
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

}
