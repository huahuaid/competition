using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    //用于引用场景中的卡片
    [SerializeField] private MemoryCard originalcard;
    //引用sprite的数组
    [SerializeField] private Sprite[] images;
    //显示分数
    [SerializeField] private TextMeshPro scoreLabel;
    //成功文本
    [SerializeField] private TextMeshPro victoryText;

    //关卡相关配置
    public int[] numbers = { 0, 0, 1, 1, 2, 2, 3, 3, 3, 3 };
    //网格之间的行列距离
    public int gridRows = 2;
    public int gridColumns = 5;
    public const int offsetX = 2;
    public const int offsetY = 3;
    //关卡名
    public string levelName = "Scene_Card_Level1";

    public int targetScore = 5;


    //记录两张卡片
    private MemoryCard _firstRevealed;
    private MemoryCard _secondRevealed;

    private int _score = 0;

    public void Restart()
    {
        Debug.Log("Button clicked!");
        SceneManager.LoadScene(levelName);
    }

    // Start is called before the first frame update
    void Start()
    {
        victoryText.gameObject.SetActive(false);
        //int id = Random.Range(0, images.Length);
        //originalcard.SetCard(id, images[id]);

        //第一张卡片的位置，所有其他的卡片将以第一张卡片作为定位点开始向右向下偏移
        Vector3 startPos = originalcard.transform.position;

        //使用ID对所有的四种卡片声明一个整型数组
        //int[] numbers = { 0, 0, 1, 1, 2, 2, 3, 3, 3, 3};

        //打乱卡片 洗牌算法
        numbers = ShuffleArray(numbers);

        for (int i = 0; i < gridColumns; i++)
        {
            for (int j = 0; j < gridRows; j++)
            {
                MemoryCard card;
                if (i == 0 && j == 0)
                {
                    card = originalcard;
                }
                else
                {
                    card = Instantiate(originalcard) as MemoryCard;
                }
                //int id = Random.Range(0, images.Length);
                int index = numbers[i * gridRows + j];
                card.SetCard(index, images[index]);
                float posX = startPos.x + (offsetX * i);
                float posY = startPos.y - (offsetY * j);
                card.transform.position = new Vector3(posX, posY, startPos.z);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    private int[] ShuffleArray(int[] numbers)
    {
        int[] newArray = numbers.Clone() as int[];
        for (int i = 0; i < newArray.Length; i++)
        {
            int tmp = newArray[i];
            int r = Random.Range(i, newArray.Length);
            newArray[i] = newArray[r];
            newArray[r] = tmp;
        }
        return newArray;
    }

    public bool canReveal
    {
        get { return _secondRevealed == null; }
    }

    //记录下来随时填充的两张卡片  做匹配得分
    public void cardRevealed(MemoryCard card)
    {
        if (_firstRevealed == null)
        {
            _firstRevealed = card;
        }
        else
        {
            _secondRevealed = card;
            Debug.Log("Match? " + (_firstRevealed.id == _secondRevealed.id));
            StartCoroutine(checkMatch());
        }
    }

    private IEnumerator checkMatch()
    {
        //两张卡片匹配
        if (_firstRevealed.id == _secondRevealed.id)
        {
            _score++;
            Debug.Log("Score: " + _score);
            scoreLabel.text = "Score:" + _score;

            // 新增：检查分数是否达标
            if (_score >= targetScore)
            {
                // 显示通关文字
                ShowVictory();
                //// 延迟2秒后加载下一关
                yield return new WaitForSeconds(2f);
                LoadNextLevel();
            }
        }
        else
        {
            //两张卡片不匹配
            yield return new WaitForSeconds(1.5f);
            _firstRevealed.Unreal();
            _secondRevealed.Unreal();
        }
        //不管是否匹配 ，这两张翻开的卡片都要释放
        _firstRevealed = null;
        _secondRevealed = null;
    }

    private void ShowVictory()
    {
        if (victoryText != null)
        {
            victoryText.gameObject.SetActive(true);
        }
        SetCardsInteractable(false);
    }

    //禁用所有卡片的点击
    private void SetCardsInteractable(bool state)
    {
        MemoryCard[] cards = FindObjectsOfType<MemoryCard>();
        foreach (MemoryCard card in cards)
        {
            card.GetComponent<Collider2D>().enabled = state;
        }
    }

    private void LoadNextLevel()
    {
        int nextSceneIndex = SceneManager.GetActiveScene().buildIndex + 1;
        if (nextSceneIndex < SceneManager.sceneCountInBuildSettings)
        {
            SceneManager.LoadScene(nextSceneIndex);
        }
        else
        {
            SceneManager.LoadScene(0); // 回到主菜单或第一关
        }
    }
}
