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

	private void WaterwheelPositionValidator(){
		if (AssemblyProcessor.isCurrentStepCorrect && !ErrorDialogManager.isInError)
		{
			int num = assemblyProcessor.AssemblyProgressStep - 1;
			switch (assemblyProcessor.AssemblyProgressStep)
			{
				case 1:
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
					break;
				case 2:
					Debug.Log("HUAHUA");
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
					break;
				case 3:
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
					break;
				default:
					Debug.Log(assemblyProcessor.AssemblyProgressStep);
					break;
			}
		}
	}
}
