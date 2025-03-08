using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class InventoryUI : MonoBehaviour
{
	[Header("UI Settings")]
	[SerializeField] private List<GameObject> slotObjects;


	public GameObject InventoryPlane;
	public static InventoryUI Instance;

	public GameObject Inventory;
	public GameObject followObject;
	public Sprite slotSprite;

	private List<Item> slotItem;
	private InventoryManager inventoryManager;
	private SpriteRenderer followSpriteRenderer; 

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

	private void Start()
	{
		// get InventoryManger for add ,remove ,get  
		inventoryManager = Inventory.GetComponent<InventoryManager>();
		InitializeSlotImages(); 
	}

	private void Update(){
		// follow mouse
		if (followObject != null)
		{
			Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
			mousePosition.z = 0; 
			followObject.transform.position = mousePosition;
		}
		// open backpack
		if (Input.GetKeyDown(KeyCode.Y))
		{
			InventoryPlane.SetActive(!InventoryPlane.activeSelf);
			followSpriteRenderer.sprite = null;
		}
		// init InventoryUI
		InitializeSlotImages(); 
	}

	private void InitializeSlotImages()
	{
		slotItem = inventoryManager.AllItem();
		for (int i = 0; i < slotObjects.Count; i++)
		{
			Image image = slotObjects[i].GetComponent<Image>();
			Button button = slotObjects[i].GetComponent<Button>();

			if (i < slotItem.Count && slotItem[i] != null && slotItem[i].icon != null)
			{
				image.sprite = slotItem[i].icon;
				image.enabled = true; 
				int index = i;
				// choice different object
				button.onClick.AddListener(()=>OnSlotClicked(index));
			}
			else
			{
				image.sprite = slotSprite;
			}
		}
	}

	private void OnSlotClicked(int slotIndex)
	{
		if (slotIndex < slotItem.Count && slotItem[slotIndex] != null)
		{
			followSpriteRenderer = followObject.GetComponent<SpriteRenderer>();
			followSpriteRenderer.sprite = slotItem[slotIndex].icon;
			followObject.GetComponent<PlaceableObject>().itemName = slotItem[slotIndex].itemName;
		}	
	}
}
