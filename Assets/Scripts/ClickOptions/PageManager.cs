using UnityEngine;
using UnityEngine.UI;

public class PageManager : MonoBehaviour
{
	public int lastPageNumber;
	public GameObject[] pages; 
	public static int currentIndex = 0; 
	public static bool isLastPageReached = false;
	public Button nextButton; 

	private void Start()
	{
		nextButton.onClick.AddListener(OnNextButtonClicked); // 添加按钮点击事件
	}

	private void OnNextButtonClicked()
	{
		pages[currentIndex].SetActive(false);
		currentIndex++;
		if (lastPageNumber != 0 && currentIndex == lastPageNumber)
		{
			isLastPageReached = true;
			return;
		}
		pages[currentIndex].SetActive(true);
	}
}

