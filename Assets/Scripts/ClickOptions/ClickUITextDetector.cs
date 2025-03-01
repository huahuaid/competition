using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ClickUITextDetector : MonoBehaviour, IPointerClickHandler
{
	void Start()
	{

	}

	void Update()
	{

	}

	public void OnPointerClick(PointerEventData eventData)
	{
		Text text = eventData.pointerCurrentRaycast.gameObject.GetComponent<Text>();
		if (text != null)
		{
			Debug.Log("你点击了: " + text.text);
		}
	}
}
