using UnityEngine;

public class ModuleFunctionEvaluator : MonoBehaviour
{
	public GameObject assemblyProcess;
	public AssemblyProcessQuestion question;
	private int currentStep;
	public enum FunctionStatus{
		Correct,    
		Incorrect,  
		Waiting     
	};

	public static FunctionStatus isCurrentStepFunctionQuestionCorrect = FunctionStatus.Waiting;
	public bool isAllQuestionCorrect = false;
	private AssemblyProcessor assemblyProcessor;
    private object isPositionCorrect;

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
					assemblyProcess.SetActive(true);
					if (question.isCorrect)
					{
						assemblyProcess.SetActive(false);
					}
					ModulePositioningJudge.isPositionCorrect = ModulePositioningJudge.PositionStatus.Waiting;
					break;
				case 2:
					ModulePositioningJudge.isPositionCorrect = ModulePositioningJudge.PositionStatus.Waiting;
					break;
				default:
					break;
			}
		}
	}
}
