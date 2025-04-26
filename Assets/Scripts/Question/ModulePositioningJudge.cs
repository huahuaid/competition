using UnityEngine;

public class ModulePositioningJudge : MonoBehaviour
{
	public GameObject[] assemblyProcesses; 
	public AssemblyProcessQuestion[] questions; 
	public static PositionStatus isPositionCorrect = PositionStatus.Waiting;

	public enum PositionStatus
	{
		Correct,
		Incorrect,  
		Waiting
	} 

	private AssemblyProcessor assemblyProcessor;

	void Start()
	{
		assemblyProcessor = FindObjectOfType<AssemblyProcessor>();
	}

	void Update()
	{
		WaterwheelPositionValidator();
	}

	private void WaterwheelPositionValidator()
	{
		if (AssemblyProcessor.isCurrentStepCorrect && !ErrorDialogManager.isInError)
		{
			int num = assemblyProcessor.AssemblyProgressStep - 1;
			if (num < 0 || num >= assemblyProcesses.Length || num >= questions.Length)
			{
				Debug.LogError("Invalid assembly step: " + assemblyProcessor.AssemblyProgressStep);
				return;
			}

			assemblyProcesses[num].SetActive(true);
			if (questions[num].isCorrect)
			{
				assemblyProcesses[num].SetActive(false);
				isPositionCorrect = PositionStatus.Correct;
			}
			else
			{
				isPositionCorrect = PositionStatus.Incorrect;
			}
		}
	}
}

