using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevelScenceTrigger : MonoBehaviour
{
	public int SceneIndex;
	private bool isVisableChangScene;

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
}

