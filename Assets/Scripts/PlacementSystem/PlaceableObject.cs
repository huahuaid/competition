using UnityEngine;

public class PlaceableObject : MonoBehaviour
{
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
		}
		else if(!isCurrentObjectInPlacementArea && Input.GetMouseButtonDown(0))
		{
			isVisablePut = false;
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
