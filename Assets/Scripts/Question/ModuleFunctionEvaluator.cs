using UnityEngine;

public class ModuleFunctionEvaluator : MonoBehaviour
{
	public static bool isAllQuestionOver;
	public GameObject[] assemblyProcesses;  // 支持多个组装过程
	public AssemblyProcessQuestion[] questions;  // 支持多个问题
	private int currentStep;

	public enum FunctionStatus
	{
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

	private void EvaluateModuleFunction()
	{
		if (AssemblyProcessor.isCurrentStepCorrect && ModulePositioningJudge.isPositionCorrect == ModulePositioningJudge.PositionStatus.Correct)
		{
			currentStep = assemblyProcessor.AssemblyProgressStep - 1; // 获取当前步骤索引

			if (currentStep < questions.Length && currentStep < assemblyProcesses.Length) // 确保索引在范围内
			{
				assemblyProcesses[currentStep].SetActive(true);

				if (questions[currentStep].isCorrect)
				{
					assemblyProcesses[currentStep].SetActive(false);
					isCurrentStepFunctionQuestionCorrect = FunctionStatus.Correct;
					if (assemblyProcessor.AssemblyProgressStep == 8)
					{
						isAllQuestionOver = true;
					}
				}
				else
				{
					isCurrentStepFunctionQuestionCorrect = FunctionStatus.Incorrect;
				}

				// 重置位置状态为等待
				ModulePositioningJudge.isPositionCorrect = ModulePositioningJudge.PositionStatus.Waiting;
			}
			else
			{
				Debug.LogWarning("当前步骤超出问题或组装过程的范围");
			}
		}
	}
}

