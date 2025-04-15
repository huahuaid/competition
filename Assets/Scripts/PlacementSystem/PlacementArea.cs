using UnityEngine.SceneManagement;
using UnityEngine;

public class PlacementArea : MonoBehaviour
{
	private bool isCurrentObjectInPlacementArea;
	public SpriteRenderer spriteRenderer;
	public Animator animator;
	private InventoryManager inventoryManager;
	private string itemName;
	private PlaceableObject placeableObject;
	public AssemblyProcessor assemblyProcessor;

	void Start()
	{
		inventoryManager = GameObject.FindWithTag("Inventory").GetComponent<InventoryManager>();
		// 确保AssemblyProcessor引用有效
		if (assemblyProcessor == null)
		{
			assemblyProcessor = FindObjectOfType<AssemblyProcessor>();
		}
	}

	void Update()
	{
		HandlePlacement();
		UpdateSpriteVisibility();
	}

	private void HandlePlacement()
	{
		if (placeableObject.isVisablePut && isCurrentObjectInPlacementArea)
		{
			ProcessItemPlacement();
		}
	}

	private void ProcessItemPlacement()
	{
		// 使用AssemblyProcessor处理组装逻辑
		bool assemblySuccess = assemblyProcessor.TryAssembleComponent(itemName);

		Debug.Log(assemblyProcessor.AssemblyProgressStep+" "+AssemblyProcessor.isCurrentStepCorrect);

		if (assemblySuccess)
		{
			ErrorDialogManager.isInError = false;
				// 这里传一个当前进度
				// 当前进度错误就返回错误弹窗
				// 对了就返回下一个逻辑
				// 放在一个类里面处理这个问题

				inventoryManager.RemoveItemByName(itemName);
			placeableObject.isVisablePut = false;

			// 检查AssemblyProcessor中的完成状态
			if (AssemblyProcessor.isAllPrefab)
			{
				BeginAnimator();
			}
		}else{
			placeableObject.isVisablePut = false;
		}
	}

	private void UpdateSpriteVisibility()
	{
		// 根据AssemblyProcessor的状态更新显示
		if (AssemblyProcessor.isAllPrefab)
		{
			Color color = spriteRenderer.color;
			color.a = 1f;
			spriteRenderer.color = color;
		}
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.CompareTag("Follow"))
		{
			isCurrentObjectInPlacementArea = true;
			placeableObject = other.GetComponent<PlaceableObject>();
			itemName = placeableObject.itemName;
		}
	}

	void OnTriggerExit2D(Collider2D other)
	{
		if (other.CompareTag("Follow"))
		{
			isCurrentObjectInPlacementArea = false;
		}
	}

	private void NextScene()
	{
		SceneManager.LoadScene(2);
	}

	private void BeginAnimator()
	{
		animator.SetBool("iswork", true);
	}
}
