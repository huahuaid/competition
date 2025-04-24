using UnityEngine;
using UnityEngine.SceneManagement; 

public class BackTimp : MonoBehaviour
{
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            LoadOtherScene(); 
        }
    }

    void LoadOtherScene()
    {
		SceneManager.LoadScene("SceneTimp");
	}
}

