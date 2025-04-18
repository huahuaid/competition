using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevelScence : MonoBehaviour
{
	public int SceneIndex;
	private bool isVisableChangScene;

	void Start()
	{

	}

	void Update()
	{
		if (Input.GetKeyDown(KeyCode.E) && isVisableChangScene)
		{
			ChangeScene();
		}
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.CompareTag("Player"))
		{
			isVisableChangScene = true;
		}
	}

	void OnTriggerExit2D(Collider2D other)
	{
		if (other.CompareTag("Player"))
		{
			isVisableChangScene = false;
		}
	}

	public void ChangeScene(){
		SceneManager.LoadScene(SceneIndex);
	}
}

