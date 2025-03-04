using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Inventory/Item")]
public class Item : ScriptableObject
{
	[Header("Item Details")]
	public int id;
	public string itemName; 
	public Sprite icon;
	[TextArea] public string description;

	[Header("Stacking")]
	public int maxStack = 1; 
	public bool isStackable => maxStack > 1;
}
