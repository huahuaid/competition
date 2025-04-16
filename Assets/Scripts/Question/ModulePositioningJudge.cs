using UnityEngine;

public class ModulePositioningJudge : MonoBehaviour
{
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
			switch (assemblyProcessor.AssemblyProgressStep)
			{
				case 1:
					if (Input.GetKeyDown(KeyCode.I))
					{
						Debug.Log("HUAHUAONE");
						isPositionCorrect = PositionStatus.Correct;
					}
					else if (Input.GetKeyDown(KeyCode.N))
					{
						isPositionCorrect = PositionStatus.Incorrect;
					}
					break;
				case 2:
					Debug.Log("HUAHUATWO");
					break;
				case 3:
					Debug.Log("HUAHUATHREE");
					break;
				default:
					Debug.Log(assemblyProcessor.AssemblyProgressStep);
					break;
			}
		}
	}
}
