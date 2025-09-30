using UnityEngine;

public class TorchShakeExtinguisher : MonoBehaviour
{
    [Header("Config")]
    [SerializeField] private float shakeThreshold = 10f; // Soglia per il movimento
    private ParticleSystem fireParticles;  // Riferimento al sistema delle particelle del fuoco
    private Rigidbody torchRigidbody;      // Riferimento al Rigidbody della torcia

    private void Awake()
    {
        fireParticles = GetComponentInChildren<ParticleSystem>(); // Ottieni il sistema delle particelle (fiamma)
        torchRigidbody = GetComponent<Rigidbody>();               // Ottieni il Rigidbody della torcia
    }

    private void Update()
    {
        // Se la velocità angolare supera la soglia, spegni il fuoco
        if (torchRigidbody.angularVelocity.magnitude > shakeThreshold || torchRigidbody.linearVelocity.magnitude > shakeThreshold)
        {
            if (fireParticles.isPlaying)
            {
                fireParticles.Stop();  // Ferma il sistema delle particelle
            }
        }
    }
}
