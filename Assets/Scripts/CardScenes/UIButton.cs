using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIButton : MonoBehaviour
{
    //���һ�����ڷ���֪ͨ�Ķ���
    [SerializeField] private GameObject targetObject;
    //���һ�����͵���Ϣ
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
    //�����ͣ�ڶ�����
    public void OnMouseEnter()
    {
        SpriteRenderer sprite = GetComponent<SpriteRenderer>();
        if (sprite != null)
        {
            sprite.color = highlightColor;
        }
    }
    //����뿪����
    public void OnMouseExit()
    {
        SpriteRenderer sprite = GetComponent<SpriteRenderer>();
        if (sprite != null)
        {
            sprite.color = Color.white;
        }
    }
    //�������ť ��ť��΢���
    public void OnMouseDown()
    {
        transform.localScale = new Vector3(1.1f, 1.1f, 1.1f);
    }
    //����ɿ� ����ԭ
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
        Debug.Log("��ť������ˣ�");
    }
}
