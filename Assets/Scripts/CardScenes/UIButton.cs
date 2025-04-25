using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIButton : MonoBehaviour
{
    //添加一个用于发送通知的对象
    [SerializeField] private GameObject targetObject;
    //添加一个发送的消息
    [SerializeField] private string targetMessage;

    public Color highlightColor = Color.cyan;
    // Start is called before the first frame update
    void Start()
    {

    }
    // Update is called once per frame
    void Update()
    {

    }
    //鼠标悬停在对象上
    public void OnMouseEnter()
    {
        SpriteRenderer sprite = GetComponent<SpriteRenderer>();
        if (sprite != null)
        {
            sprite.color = highlightColor;
        }
    }
    //鼠标离开对象
    public void OnMouseExit()
    {
        SpriteRenderer sprite = GetComponent<SpriteRenderer>();
        if (sprite != null)
        {
            sprite.color = Color.white;
        }
    }
    //鼠标点击按钮 按钮稍微变大
    public void OnMouseDown()
    {
        transform.localScale = new Vector3(1.1f, 1.1f, 1.1f);
    }
    //鼠标松开 对象还原
    public void OnMouseUp()
    {
        transform.localScale = Vector3.one;
        if (targetObject != null)
        {
            targetObject.SendMessage(targetMessage);
        }
    }

    public void OnButtonClick()
    {
        Debug.Log("按钮被点击了！");
    }
}
