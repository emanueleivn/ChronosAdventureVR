using UnityEngine;

public class ButtonClickController : MonoBehaviour
{
    [Header("Descrizioni da monitorare (Canvas o GameObject)")]
    public GameObject[] descriptions;

    [Header("Oggetto da mostrare quando tutte le descrizioni sono state viste")]
    public GameObject objectToActivate;

    // Stato delle descrizioni (se sono mai state viste almeno una volta)
    private bool[] viewedStates;

    void Start()
    {
        viewedStates = new bool[descriptions.Length];

        if (objectToActivate != null)
            objectToActivate.SetActive(false);
    }

    void Update()
    {
        // Controlla se una descrizione è stata resa attiva almeno una volta
        for (int i = 0; i < descriptions.Length; i++)
        {
            if (descriptions[i] != null && descriptions[i].activeInHierarchy)
            {
                viewedStates[i] = true;
            }
        }

        // Se tutte sono state viste → attiva l'oggetto finale
        if (AllDescriptionsViewed())
        {
            if (objectToActivate != null && !objectToActivate.activeSelf)
                objectToActivate.SetActive(true);
        }
    }

    bool AllDescriptionsViewed()
    {
        foreach (bool viewed in viewedStates)
        {
            if (!viewed) return false;
        }
        return true;
    }
}
