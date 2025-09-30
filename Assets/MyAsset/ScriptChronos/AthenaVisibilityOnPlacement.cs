using UnityEngine;

public class AthenaVisibilityOnPlacement : MonoBehaviour
{
    [Header("Oggetti")]
    [SerializeField] private GameObject helmet;  // Riferimento all'oggetto "helmet"
    [SerializeField] private GameObject colonnaAthena; // Riferimento all'oggetto "ColonnaAthena"
    [SerializeField] private GameObject athena;  // Riferimento all'oggetto "Athena"
    [SerializeField] private GameObject circle;
    [SerializeField] private GameObject buttonAnte;
    [SerializeField] private GameObject buttonPost;
    [SerializeField] private GameObject description;
    private bool isHelmetOnColonna = false; // Flag per verificare se il casco è sopra la colonna

    void Start()
    {
        athena.SetActive(false); // Rendi invisibile l'oggetto "Athena" all'inizio
    }

    void Update()
    {
        if (!isHelmetOnColonna && IsHelmetOnColonna())
        {
            isHelmetOnColonna = true;
            circle.SetActive(true);
            Invoke("MakeAthenaVisible", 5f); // Attendi 2 secondi e poi rendi visibile "Athena"
        }
    }

    // Verifica se l'oggetto "helmet" è sopra "ColonnaAthena"
    bool IsHelmetOnColonna()
    {
        // Aggiungi una logica per verificare se il casco è sopra la colonna (ad esempio, con una distanza)
        return Vector3.Distance(helmet.transform.position, colonnaAthena.transform.position) < 0.2f;
    }

    // Rende visibile l'oggetto "Athena"
    void MakeAthenaVisible()
    {
        athena.SetActive(true);
        colonnaAthena.SetActive(false);
        helmet.SetActive(false);
        circle.SetActive(false);
        buttonAnte.SetActive(false);
        buttonPost.SetActive(true);
        description.SetActive(true);
    }
}
