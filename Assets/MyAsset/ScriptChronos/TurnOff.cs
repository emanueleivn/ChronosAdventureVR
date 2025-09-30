using UnityEngine;

public class TurnOff : MonoBehaviour
{
    private ParticleSystem fireParticles;

    private void Awake()
    {
        fireParticles = GetComponent<ParticleSystem>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Water"))
        {
            if (fireParticles.isPlaying)
                fireParticles.Stop();
        }
    }
}
