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
		CurrentPositionError();
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

	private void CurrentPositionError(){
		if (isPositionPopup == false && ModulePositioningJudge.isPositionCorrect == ModulePositioningJudge.PositionStatus.Incorrect){
			isPositionPopup = true;
		}
		if (isPositionPopup == true && Input.GetKeyDown(KeyCode.Escape))
		{
			isPositionPopup = false;
			ModulePositioningJudge.isPositionCorrect = ModulePositioningJudge.PositionStatus.Waiting;
		}
		dialogPositionError.SetActive(isPositionPopup);
	}
}
