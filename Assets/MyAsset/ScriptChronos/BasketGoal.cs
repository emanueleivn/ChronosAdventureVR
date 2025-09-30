using UnityEngine;

public class BasketGoal : MonoBehaviour
{
    [SerializeField] private GameObject object1;      // Primo oggetto richiesto
    [SerializeField] private GameObject object2;      // Secondo oggetto richiesto
    [SerializeField] private AudioClip successClip;   // Suono da riprodurre

    private AudioSource audioSource;
    private int collectedCount = 0;

    void Start()
    {
        // Recupera (o aggiunge) l'AudioSource sulla cesta
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        // Se collide con il primo oggetto
        if (collision.gameObject == object1 && object1.activeSelf)
        {
            collectedCount++;
        }

        // Se collide con il secondo oggetto
        if (collision.gameObject == object2 && object2.activeSelf)
        {
            collectedCount++;
        }

        // Se ho raccolto entrambi
        if (collectedCount >= 2)
        {
            if (successClip != null)
            {
                audioSource.PlayOneShot(successClip);
            }

            // Fai sparire la cesta dopo il suono
            Destroy(gameObject, successClip != null ? successClip.length : 0f);
            object1.SetActive(false);
            object2.SetActive(false);
        }
    }
}
