using System;

/// <summary>
/// 水车组件类型枚举
/// </summary>
public enum WaterwheelComponent
{
	WaterwheelAxle,          // 水车中轴
	MainRib,                // 主辐条
	InnerLongLink,          // 内部长连杆
	InnerShortLink,         // 内部短连杆
	OuterLongLink,          // 外部长连杆
	OuterShortLink,         // 外部短连杆
	TailLongLink,           // 尾部长连杆
	TailShortLink,          // 尾部短连杆
	TailCrossbar,           // 尾部横杠
	HorizontalCrossbar,     // 横杠
	Paddle,                 // 刮板
	TungOilCoating,         // 桐油处理
	WaterwheelSupport,      // 水车支架
	InclinedBambooTube,     // 斜装竹筒
	WaterChute              // 水舰（导水槽）
}
