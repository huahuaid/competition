using UnityEngine;
using System;

/// <summary>
/// 水车组装处理器
/// </summary>
public class AssemblyProcessor : MonoBehaviour
{
	int Index = 0;
	public static bool isAllPrefab; // 标记所有预制件是否组装完成
	public static bool isCurrentStepCorrect = true; // 静态变量，向外界传输当前安装步骤是否正确

	private AssemblyValidator _validator = new AssemblyValidator();

	/// <summary>
	/// 尝试组装指定名称的组件
	/// </summary>
	public bool TryAssembleComponent(string componentName)
	{
		if (isAllPrefab)
		{
			Debug.LogWarning("所有部件已组装完成！");
			isCurrentStepCorrect = true;
			return false;
		}

		if (Enum.TryParse(componentName, true, out WaterwheelComponent component))
		{
			return TryAssembleComponent(component);
		}

		Debug.LogError($"无效的组件名称: {componentName}");
		isCurrentStepCorrect = false;
		return false;
	}

	/// <summary>
	/// 尝试组装指定枚举类型的组件
	/// </summary>
	public bool TryAssembleComponent(WaterwheelComponent component)
	{
		/// 测试用的
		Index++;
		if (Index == 2)
		{
			isAllPrefab = true;
		}




		if (isAllPrefab)
		{
			Debug.LogWarning("所有部件已组装完成！");
			isCurrentStepCorrect = true;
			return false;
		}

		var result = _validator.ValidateNextComponent(component);

		if (result.isValid)
		{
			Debug.Log($"成功组装: {component} (进度: {_validator.CurrentStep}/{_validator.TotalSteps})");
			isCurrentStepCorrect = true;

			// 检查是否是最后一个组件
			if (_validator.CurrentStep >= _validator.TotalSteps)
			{
				isAllPrefab = true;
				Debug.Log("水车组装全部完成！isAllPrefab = true");
				OnAllPrefabAssembled?.Invoke();
			}
			return true;
		}

		HandleAssemblyError(result.expectedComponent, component);
		isCurrentStepCorrect = false;
		return false;
	}

	private void HandleAssemblyError(WaterwheelComponent? expected, WaterwheelComponent actual)
	{
		if (expected.HasValue)
		{
			Debug.LogError($"组装顺序错误！当前应该安装: {expected.Value}，但尝试安装的是: {actual}");
		}
		else
		{
			Debug.LogError("所有组件已组装完成！");
		}
	}

	/// <summary>
	/// 重置组装流程
	/// </summary>
	public void ResetAssembly()
	{
		_validator.Reset();
		isAllPrefab = false;
		isCurrentStepCorrect = false;
		Debug.Log("组装流程已重置，isAllPrefab = false");
	}

	/// <summary>
	/// 所有预制件组装完成事件
	/// </summary>
	public static event Action OnAllPrefabAssembled;

	/// <summary>
	/// 获取当前组装进度(0-1)
	/// </summary>
	public int AssemblyProgressStep => _validator.CurrentStep;
}
