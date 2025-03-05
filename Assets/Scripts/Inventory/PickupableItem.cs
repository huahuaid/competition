// PickupableItem.cs
using UnityEngine;

public class PickupableItem : MonoBehaviour
{
	public new GameObject gameObject;
	public Item item;
	public int amount = 1;

	void Start(){
		if (PlacementArea.isAllPrefab)
		{
			gameObject.SetActive(false);
		}
	}
}
