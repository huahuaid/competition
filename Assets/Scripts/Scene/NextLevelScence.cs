using UnityEngine;
using UnityEngine.SceneManagement; // 引入场景管理命名空间

public class NextLevelScence : MonoBehaviour
{
	void Start()
	{

	}

	void Update()
	{

	}


	public void LoadNextScene()
	{
		int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;

		int nextSceneIndex = (currentSceneIndex + 1) % SceneManager.sceneCountInBuildSettings;
		SceneManager.LoadScene(nextSceneIndex);
	}

	public void LoadPreScene()
	{
		int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;

		int nextSceneIndex = (currentSceneIndex - 1) % SceneManager.sceneCountInBuildSettings;
		SceneManager.LoadScene(nextSceneIndex);
	}
}

