using UnityEngine;

public class VegetableReset : MonoBehaviour
{
    private Vector3 initialPosition;
    private Quaternion initialRotation;

    [SerializeField] private string basketTag = "Basket";

    void Start()
    {
        initialPosition = transform.position;
        initialRotation = transform.rotation;
    }

    void OnCollisionEnter(Collision collision)
    {
        // Controlla se l’oggetto con cui ho colliso è la cesta
        if (collision.gameObject.CompareTag(basketTag))
        {
            // Riporta la verdura nella posizione originale
            transform.position = initialPosition;
            transform.rotation = initialRotation;

            // Se ha un rigidbody, resetta anche la fisica
            Rigidbody rb = GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.velocity = Vector3.zero;
                rb.angularVelocity = Vector3.zero;
            }
        }
    }
}
