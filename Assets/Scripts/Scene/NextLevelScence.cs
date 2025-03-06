using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevelScence : MonoBehaviour
{
	public int SceneIndex;

	void Start()
	{

	}

	void Update()
	{

	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.CompareTag("Player"))
		{
			ChangeScene();
		}
	}

	public void ChangeScene(){
		SceneManager.LoadScene(SceneIndex);
	}

	// public void LoadNextScene()
	// {
	// 	int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
	//
	// 	int nextSceneIndex = (currentSceneIndex + 1) % SceneManager.sceneCountInBuildSettings;
	// 	SceneManager.LoadScene(nextSceneIndex);
	// }
	//
	// public void LoadPreScene()
	// {
	// 	int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
	//
	// 	int nextSceneIndex = (currentSceneIndex - 1) % SceneManager.sceneCountInBuildSettings;
	// 	SceneManager.LoadScene(nextSceneIndex);
	// }
}

