using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    //�������ó����еĿ�Ƭ
    [SerializeField] private MemoryCard originalcard;
    //����sprite������
    [SerializeField] private Sprite[] images;
    //��ʾ����
    [SerializeField] private TextMeshPro scoreLabel;
    //�ɹ��ı�
    [SerializeField] private TextMeshPro victoryText;

    //�ؿ��������
    public int[] numbers = { 0, 0, 1, 1, 2, 2, 3, 3, 3, 3 };
    //����֮������о���
    public int gridRows = 2;
    public int gridColumns = 5;
    public const int offsetX = 2;
    public const int offsetY = 3;
    //�ؿ���
    public string levelName = "Scene_Card_Level1";

    public int targetScore = 5;


    //��¼���ſ�Ƭ
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

        //��һ�ſ�Ƭ��λ�ã����������Ŀ�Ƭ���Ե�һ�ſ�Ƭ��Ϊ��λ�㿪ʼ��������ƫ��
        Vector3 startPos = originalcard.transform.position;

        //ʹ��ID�����е����ֿ�Ƭ����һ����������
        //int[] numbers = { 0, 0, 1, 1, 2, 2, 3, 3, 3, 3};

        //���ҿ�Ƭ ϴ���㷨
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

    //��¼������ʱ�������ſ�Ƭ  ��ƥ��÷�
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
        //���ſ�Ƭƥ��
        if (_firstRevealed.id == _secondRevealed.id)
        {
            _score++;
            Debug.Log("Score: " + _score);
            scoreLabel.text = "Score:" + _score;

            // �������������Ƿ���
            if (_score >= targetScore)
            {
                // ��ʾͨ������
                ShowVictory();
                //// �ӳ�2��������һ��
                yield return new WaitForSeconds(2f);
                LoadNextLevel();
            }
        }
        else
        {
            //���ſ�Ƭ��ƥ��
            yield return new WaitForSeconds(1.5f);
            _firstRevealed.Unreal();
            _secondRevealed.Unreal();
        }
        //�����Ƿ�ƥ�� �������ŷ����Ŀ�Ƭ��Ҫ�ͷ�
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

    //�������п�Ƭ�ĵ��
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
            SceneManager.LoadScene(0); // �ص����˵����һ��
        }
    }
}
