using UnityEngine;
using UnityEngine.UI;

public class ImageHider : MonoBehaviour
{
	public GameObject gameObject;
	public Image[] images = new Image[9]; // 初始化一个大小为5的数组
	public Button button; // 按钮的引用
	private int currentImageIndex = 0; // 当前图片索引

	// 静态变量，用于检测所有图片是否都隐藏完毕
	public static bool AllImagesHidden { get; private set; } = false;

	void Start()
	{
		// 手动将图片组件添加到数组中
		images[0] = GameObject.Find("image").GetComponent<Image>();
		images[1] = GameObject.Find("image (1)").GetComponent<Image>();
		images[2] = GameObject.Find("image (2)").GetComponent<Image>();
		images[3] = GameObject.Find("image (3)").GetComponent<Image>();
		images[4] = GameObject.Find("image (4)").GetComponent<Image>();
		images[5] = GameObject.Find("image (5)").GetComponent<Image>();
		images[6] = GameObject.Find("image (6)").GetComponent<Image>();
		images[7] = GameObject.Find("image (7)").GetComponent<Image>();
		images[8] = GameObject.Find("image (8)").GetComponent<Image>();
		images[9] = GameObject.Find("image (9)").GetComponent<Image>();

		button = GameObject.Find("Button").GetComponent<Button>();

		// 为按钮添加点击事件
		button.onClick.AddListener(TaskOnClick);
	}

	public void TaskOnClick()
	{
		if (currentImageIndex < images.Length - 1)
		{
			images[currentImageIndex].gameObject.SetActive(false); // 隐藏当前图片
			currentImageIndex++; // 移动到下一个图片索引

			// 检查是否只剩最后一张图片
			if (currentImageIndex == images.Length - 1)
			{
				button.GetComponentInChildren<Text>().text = "结束"; // 修改按钮文字为“结束”
			}
		}
		else if (currentImageIndex == images.Length - 1)
		{
			// 如果按钮显示为“结束”，点击按钮后隐藏最后一张图片和按钮
			images[currentImageIndex].gameObject.SetActive(false); // 隐藏最后一张图片
			button.gameObject.SetActive(false); // 隐藏按钮

			// 所有图片都隐藏完毕，设置静态变量为true
			AllImagesHidden = true;
			gameObject.SetActive(true);
		}
		Debug.Log(AllImagesHidden);
	}
}
