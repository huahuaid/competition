using UnityEngine;

public static class ClickSoundPlayer
{
    // 播放点击音效
    public static void Play(AudioClip clickSound = null)
    {
        if (clickSound == null)
        {
            Debug.LogWarning("没有传入点击音效 AudioClip！");
            return;
        }

        // 临时创建一个 GameObject 来播放音效（播放后自动销毁）
        GameObject tempSoundObj = new GameObject("TempClickSound");
        AudioSource audioSource = tempSoundObj.AddComponent<AudioSource>();
        
        // 设置为 2D 音效（不受3D空间影响）
        audioSource.spatialBlend = 0f;
        
        // 播放音效，并在播放完成后销毁临时对象
        audioSource.PlayOneShot(clickSound);
        Object.Destroy(tempSoundObj, clickSound.length + 0.1f); // 稍微延长一点时间确保播放完成
    }
}
