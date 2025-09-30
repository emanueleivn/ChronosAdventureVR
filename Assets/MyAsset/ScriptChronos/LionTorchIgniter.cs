using UnityEngine;

public class LionTorchIgniter : MonoBehaviour
{
    private ParticleSystem fireParticles;
    private AudioSource audioSource;
    private void Start()
    {
        fireParticles = GetComponentInChildren<ParticleSystem>();
        audioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Torch") && !fireParticles.isPlaying)
        {
            fireParticles.Play();
            audioSource.Play();
        }
    }
}

