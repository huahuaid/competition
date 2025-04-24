using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameReload : MonoBehaviour
{
	public GameObject game;
	void Start()
	{

	}

	// Update is called once per frame
	void Update()
	{
		if (Input.GetMouseButtonDown(0))
		{
			game.SetActive(false);
			// game.SetActive(true);
			// gameObject.SetActive(false);
		}
	}
}
