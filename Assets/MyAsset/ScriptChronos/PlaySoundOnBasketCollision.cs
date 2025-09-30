using UnityEngine;

public class PlaySoundOnBasketCollision : MonoBehaviour
{
    [SerializeField] private GameObject basket;    // La cesta con cui deve collidere
    [SerializeField] private AudioClip clip;       // Il suono da riprodurre

    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
            audioSource = gameObject.AddComponent<AudioSource>();

        audioSource.playOnAwake = false;
    }

    void OnCollisionEnter(Collision collision)
    {
        if (basket != null && collision.gameObject == basket)
        {
            if (clip != null)
            {
                audioSource.PlayOneShot(clip);
            }
            else if (audioSource.clip != null)
            {
                audioSource.Play(); // fallback se già assegnata nel componente
            }
        }
    }
}
