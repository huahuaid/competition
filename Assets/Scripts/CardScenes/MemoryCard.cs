using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MemoryCard : MonoBehaviour
{

    [SerializeField] private SceneController controller;
    [SerializeField] private GameObject cardback;
    //引用加载sprite
    // [SerializeField] private Sprite image;

    private int _id;

    public int id
    {
        get { return _id; }
    }

    //image id
    public void SetCard(int id, Sprite card)
    {
        _id = id;
        GetComponent<SpriteRenderer>().sprite = card;
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    //当单击对象时调用的方法
    public void OnMouseDown()
    {
        //Debug.Log("test");
        //if (cardback.activeSelf)
        //{
        //    cardback.SetActive(false);
        //}
        //Debug.Log("test");
        if (cardback.activeSelf && controller.canReveal)
        {
            cardback.SetActive(false);
            controller.cardRevealed(this);
        }
    }

    //cardback display
    public void Unreal()
    {
        cardback.SetActive(true);
    }
}
