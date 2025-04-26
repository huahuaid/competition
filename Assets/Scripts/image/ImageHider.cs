using UnityEngine;
using UnityEngine.UI;

public class ImageHider : MonoBehaviour
{
	public GameObject gameObject;
	public Image[] images = new Image[9]; // ��ʼ��һ����СΪ5������
	public Button button; // ��ť������
	private int currentImageIndex = 0; // ��ǰͼƬ����

	// ��̬���������ڼ������ͼƬ�Ƿ��������
	public static bool AllImagesHidden { get; private set; } = false;

	void Start()
	{
		// �ֶ���ͼƬ�����ӵ�������
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

		// Ϊ��ť��ӵ���¼�
		button.onClick.AddListener(TaskOnClick);
	}

	public void TaskOnClick()
	{
		if (currentImageIndex < images.Length - 1)
		{
			images[currentImageIndex].gameObject.SetActive(false); // ���ص�ǰͼƬ
			currentImageIndex++; // �ƶ�����һ��ͼƬ����

			// ����Ƿ�ֻʣ���һ��ͼƬ
			if (currentImageIndex == images.Length - 1)
			{
				button.GetComponentInChildren<Text>().text = "����"; // �޸İ�ť����Ϊ��������
			}
		}
		else if (currentImageIndex == images.Length - 1)
		{
			// �����ť��ʾΪ���������������ť���������һ��ͼƬ�Ͱ�ť
			images[currentImageIndex].gameObject.SetActive(false); // �������һ��ͼƬ
			button.gameObject.SetActive(false); // ���ذ�ť

			// ����ͼƬ��������ϣ����þ�̬����Ϊtrue
			AllImagesHidden = true;
			gameObject.SetActive(true);
		}
		Debug.Log(AllImagesHidden);
	}
}
