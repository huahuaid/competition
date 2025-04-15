using UnityEngine;

public class ErrorDialogManager : MonoBehaviour
{
	// only change by other class
	public static bool isInError = true;
	private bool isStepPopup;
	private bool isPositionPopup;
	private bool isFunctionPopup;

	public GameObject dialogStepError;
	public GameObject dialogPositionError;
	public GameObject dialogFunctionError;

	void Start()
	{

	}

	void Update()
	{
		CurrentStepError();
	}

	private void CurrentStepError(){
		if (isStepPopup == false && AssemblyProcessor.isCurrentStepCorrect == false){
			isStepPopup = true;
		}
		if (isStepPopup == true && Input.GetKeyDown(KeyCode.Escape))
		{
			isStepPopup = false;
			AssemblyProcessor.isCurrentStepCorrect = true;
		}
		dialogStepError.SetActive(isStepPopup);
	}
}
