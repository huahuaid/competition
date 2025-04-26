using UnityEngine;
using UnityEngine.UI;

public class CardManager : MonoBehaviour
{
	public GameObject CONCLUSION;
	public GameObject SCOREOBJECT;

	[SerializeField]
	private GameObject NEXTLEVE;
	private GameObject CURRENTLEVE;

	[SerializeField]
	private Text Score;

	public Button[] buttons;
	private Button firstButton;
	private Button secondButton;
	private int clickCount = 0;
	private static int score = 0;
	public static bool isGameWon = false;

	void Start()
	{
		if (SCOREOBJECT != null)
		{
			SCOREOBJECT.SetActive(true);
		}
		foreach (Button button in buttons)
		{
			button.onClick.AddListener(() => OnButtonClick(button));
		}
	}

	void Update(){
		UpdateScoreText();
	}

	void OnButtonClick(Button button)
	{
		clickCount++;

		if (clickCount == 1)
		{
			firstButton = button;
		}
		else if (clickCount == 2)
		{
			secondButton = button;
			CheckCards();
		}
	}

	void CheckCards()
	{
		Card firstCard = firstButton.GetComponent<Card>();
		Card secondCard = secondButton.GetComponent<Card>();

		if (firstCard != null && secondCard != null)
		{
			if (firstCard.index == secondCard.index)
			{
				Destroy(firstButton.gameObject);
				Destroy(secondButton.gameObject);
				score++;
				UpdateScoreText();

				if (score == 4)
				{
					if (NEXTLEVE != null)
					{
						NEXTLEVE.SetActive(true);
						CURRENTLEVE.SetActive(false);
					}
				}
				if (score >= 8)
				{
					isGameWon = true;
					CONCLUSION.SetActive(true);
				}
			}
			else
			{
				Debug.Log("卡片不相同，请重新选择。");
			}
		}

		clickCount = 0;
		firstButton = null;
		secondButton = null;
	}

	void UpdateScoreText()
	{
		Score.text = "分数:"+score.ToString();
	}
}

