using UnityEngine;

public class ClickSoundPlayer : MonoBehaviour
{
	private static ClickSoundPlayer instance;
	public AudioClip clickSound;

	[Range(0f, 1f)] // 添加这一行，使音量可视化
		public float volume = 1f; // 默认音量

	private void Awake()
	{
		if (instance == null)
		{
			instance = this;
			DontDestroyOnLoad(gameObject);
		}
		else
		{
			Destroy(gameObject);
		}
	}

	private void Update()
	{
		if (Input.GetMouseButtonDown(0))
		{
			PlayClickSound();
		}
	}

	public void PlayClickSound()
	{
		if (clickSound == null)
		{
			Debug.LogWarning("没有传入点击音效 AudioClip！");
			return;
		}

		GameObject tempSoundObj = new GameObject("TempClickSound");
		AudioSource audioSource = tempSoundObj.AddComponent<AudioSource>();
		audioSource.spatialBlend = 0f;

		// 设置音量
		audioSource.volume = volume; // 使用可视化的音量值

		audioSource.PlayOneShot(clickSound);
		Object.Destroy(tempSoundObj, clickSound.length + 0.1f);
	}
}

