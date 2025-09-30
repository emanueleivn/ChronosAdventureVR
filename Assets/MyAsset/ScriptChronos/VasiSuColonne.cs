using UnityEngine;

public class VasiSuColonne : MonoBehaviour
{
    [Header("Vasi e Colonne")]
    public Transform[] vasi;
    public Transform[] colonne;

    [Header("Bottoni UI")]
    public GameObject bottone1;
    public GameObject bottone2;

    [Header("Parametri di controllo")]
    public float distanzaMassima = 1.2f;
    public float tolleranzaY = 0.5f;

    void Update()
    {
        if (TutteColonneOccupate())
        {
            bottone1.SetActive(false);
            bottone2.SetActive(true);
        }
    }

    bool TutteColonneOccupate()
    {
        foreach (Transform colonna in colonne)
        {
            bool colonnaOccupata = false;

            foreach (Transform vaso in vasi)
            {
                if (VasoSuColonna(vaso, colonna))
                {
                    colonnaOccupata = true;
                    break;
                }
            }

            if (!colonnaOccupata)
                return false;
        }

        return true;
    }

    bool VasoSuColonna(Transform vaso, Transform colonna)
    {
        Vector3 differenza = vaso.position - colonna.position;

        // controllo distanza orizzontale (XZ) e verticale con tolleranza
        bool vicinoOrizzontale = new Vector2(differenza.x, differenza.z).magnitude < distanzaMassima;
        bool altezzaCorretta = Mathf.Abs(vaso.position.y - colonna.position.y) < tolleranzaY;

        return vicinoOrizzontale && altezzaCorretta;
    }
}
