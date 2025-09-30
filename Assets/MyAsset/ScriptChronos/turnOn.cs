using UnityEngine;

public class turnOn : MonoBehaviour
{
    private ParticleSystem fireParticles;

    private void Awake()
    {
        fireParticles = GetComponent<ParticleSystem>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("TorchLight"))
        {
            if (!fireParticles.isPlaying)
                fireParticles.Play();
        }
    }
}

