using UnityEngine;

public class CloseDialogByClick : MonoBehaviour
{
	public GameObject dialogUI;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
		if (Input.GetMouseButtonDown(0))
		{
			dialogUI.SetActive(false);
		}
    }
}
