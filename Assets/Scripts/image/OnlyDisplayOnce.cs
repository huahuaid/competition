using UnityEngine;

public class OnlyDisplayOnce : MonoBehaviour
{
	public static bool ToggleOpen = true;
	// Start is called before the first frame update
	void Start()
	{
		if (ToggleOpen)
		{
			gameObject.SetActive(true);
		}
		else
		{
			gameObject.SetActive(false);
		}
	}

	// Update is called once per frame
	void Update()
	{

	}
}
