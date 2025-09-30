using UnityEngine;

public class HideAfterAudio : MonoBehaviour
{
    private AudioSource audioSource;

    void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (audioSource != null && !audioSource.isPlaying && gameObject.activeSelf)
        {
            gameObject.SetActive(false);
        }
    }
}

