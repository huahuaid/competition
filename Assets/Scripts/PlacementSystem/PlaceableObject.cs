using UnityEngine;

public class PlaceableObject : MonoBehaviour
{
	public static bool isPutOnThePlacementArea;
	public static bool isCurrentObjectInPlacementArea;
	public bool isVisablePut;
	public SpriteRenderer spriteRenderer;
	public string itemName;
	public static PlaceableObject Instance;

	public InventoryManager inventoryManager;

	private void Awake()
	{
		if (Instance == null)
		{
			Instance = this;
			DontDestroyOnLoad(gameObject);
		}
		else
		{
			Destroy(gameObject);
		}
	}

	void Update()
	{
		if (isCurrentObjectInPlacementArea && Input.GetMouseButtonDown(0))
		{
			isVisablePut = true;
			spriteRenderer.sprite = null;
			inventoryManager.RemoveItemByName(itemName);
		}
		else if(!isPutOnThePlacementArea && Input.GetMouseButtonDown(0))
		{
			spriteRenderer.sprite = null;
			itemName = null;
		}
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.CompareTag("Area"))
		{
			isCurrentObjectInPlacementArea = true;
		}
	}

	void OnTriggerExit2D(Collider2D other)
	{
		if (other.CompareTag("Area"))
		{
			isCurrentObjectInPlacementArea = false;
		}
	}
}
