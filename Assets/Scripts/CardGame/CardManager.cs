using UnityEngine;
using UnityEngine.UI;
using System.Collections;

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

    // Color definitions
    private Color originalColor = Color.white; // Default button color
    private Color firstClickColor = new Color(0.8352941f, 0.8352941f, 0.8352941f); // #D5D5D5
    private Color wrongColor = new Color(0.7843137f, 0.4078431f, 0.4078431f); // #C86868

    void Start()
    {
        if (SCOREOBJECT != null)
        {
            SCOREOBJECT.SetActive(true);
        }
        foreach (Button button in buttons)
        {
            button.onClick.AddListener(() => OnButtonClick(button));
            // Store the original color of each button
            originalColor = button.colors.normalColor;
        }
    }

    void Update()
    {
        UpdateScoreText();
    }

    void OnButtonClick(Button button)
    {
        if (clickCount >= 2) return; // Prevent more than 2 clicks

        clickCount++;

        if (clickCount == 1)
        {
            firstButton = button;
            ChangeButtonColor(firstButton, firstClickColor); // Change to #D5D5D5 on first click
        }
        else if (clickCount == 2)
        {
            secondButton = button;
            ChangeButtonColor(secondButton, firstClickColor); // Also change second button to #D5D5D5
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
                StartCoroutine(FlashWrongCards());
                return; // Don't reset click count here - the coroutine will handle it
            }
        }

        ResetSelection();
    }

    IEnumerator FlashWrongCards()
    {
        // Change colors to wrong color
        ChangeButtonColor(firstButton, wrongColor);
        ChangeButtonColor(secondButton, wrongColor);

        // Wait for 2 seconds
        yield return new WaitForSeconds(2f);

        // Change colors back to original
        ChangeButtonColor(firstButton, originalColor);
        ChangeButtonColor(secondButton, originalColor);

        // Reset selection
        ResetSelection();
    }

    void ChangeButtonColor(Button button, Color color)
    {
        ColorBlock colors = button.colors;
        colors.normalColor = color;
        colors.highlightedColor = color;
        colors.pressedColor = color;
        colors.selectedColor = color;
        button.colors = colors;
    }

    void ResetSelection()
    {
        clickCount = 0;
        firstButton = null;
        secondButton = null;
    }

    void UpdateScoreText()
    {
        Score.text = "分数:" + score.ToString();
    }
}
