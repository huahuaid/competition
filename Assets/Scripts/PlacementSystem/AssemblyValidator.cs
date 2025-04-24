// AssemblyValidator.cs
using System;

/// <summary>
/// 水车组装顺序验证器
/// </summary>
public class AssemblyValidator
{
    // 正确的组装顺序
    private static readonly WaterwheelComponent[] _correctOrder = 
    {
		WaterwheelComponent.Link,
		WaterwheelComponent.WaterwheelAxle,
		WaterwheelComponent.MainRib,
		WaterwheelComponent.HorizontalCrossbar,
		WaterwheelComponent.Paddle,
		WaterwheelComponent.InclinedBambooTube,
		WaterwheelComponent.WaterChute,
		WaterwheelComponent.WaterwheelSupport,
	};

	private int _currentStep = 0;

	/// <summary>
	/// 获取总组装步骤数
	/// </summary>
	public int TotalSteps => _correctOrder.Length;

	/// <summary>
	/// 获取当前步骤索引
	/// </summary>
	public int CurrentStep => _currentStep;

	/// <summary>
	/// 验证下一个组件是否正确
	/// </summary>
	public (bool isValid, WaterwheelComponent? expectedComponent) ValidateNextComponent(WaterwheelComponent component)
	{
		if (_currentStep >= _correctOrder.Length)
			return (false, null);

		if (component == _correctOrder[_currentStep])
		{
			_currentStep++;
			return (true, null);
		}

		return (false, _correctOrder[_currentStep]);
	}

	/// <summary>
	/// 重置验证状态
	/// </summary>
	public void Reset()
	{
		_currentStep = 0;
	}
}
