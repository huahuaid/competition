using UnityEngine;

public class FinishManager : MonoBehaviour
{
	public static bool isCollect;
	public static bool isModule;
	public static bool isAssembly;

	public GameObject Collect;
	public GameObject Module;
	public GameObject Assembly;

	void Start()
	{
		Collect.SetActive(isCollect);
		Module.SetActive(isModule);
		Assembly.SetActive(isAssembly);
	}

	// Update is called once per frame
	void Update()
	{

	}
}
