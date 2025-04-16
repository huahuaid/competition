using UnityEngine;

public class ModuleFunctionEvaluator : MonoBehaviour
{
	private int currentStep;
	public enum FunctionStatus{
		Correct,    
		Incorrect,  
		Waiting     
	};

	public static FunctionStatus isCurrentStepFunctionQuestionCorrect = FunctionStatus.Waiting;
	public bool isAllQuestionCorrect = false;
	private AssemblyProcessor assemblyProcessor;

	void Start()
	{
		assemblyProcessor = FindObjectOfType<AssemblyProcessor>();
	}

	void Update()
	{
		EvaluateModuleFunction();
	}

	private void EvaluateModuleFunction(){
		if( 
				AssemblyProcessor.isCurrentStepCorrect 
				&& ModulePositioningJudge.isPositionCorrect == ModulePositioningJudge.PositionStatus.Correct
		  )
		{
			switch (assemblyProcessor.AssemblyProgressStep)
			{
				case 1:
					Debug.Log("HUAHUAFUNCTIONONE");
					ModulePositioningJudge.isPositionCorrect = ModulePositioningJudge.PositionStatus.Waiting;
					break;
				case 2:
					Debug.Log("HUAHUAFUNCTIONTWO");
					ModulePositioningJudge.isPositionCorrect = ModulePositioningJudge.PositionStatus.Waiting;
					break;
				default:
					break;
			}
		}
	}
}
