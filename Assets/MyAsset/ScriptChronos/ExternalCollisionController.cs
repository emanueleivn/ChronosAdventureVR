using UnityEngine;

public class ExternalCollisionController : MonoBehaviour
{
    [SerializeField] private GameObject greekCoin;      // Oggetto Greek_coin
    [SerializeField] private GameObject cilinder1;      // Oggetto cilinder1
    [SerializeField] private GameObject objectToDisable; // L'oggetto da disattivare
    [SerializeField] private GameObject objectToEnable1;
    [SerializeField] private GameObject objectToEnable2;
    [SerializeField] private GameObject objectToEnable3;
    [SerializeField] private GameObject objectToEnable4;
    [SerializeField] private GameObject objectToEnable5;
    [SerializeField] private GameObject objectToEnable6;
    private void Update()
    {
        if (greekCoin != null && cilinder1 != null)
        {
            // Otteniamo i collider
            Collider coinCollider = greekCoin.GetComponent<Collider>();
            Collider cilinderCollider = cilinder1.GetComponent<Collider>();

            if (coinCollider != null && cilinderCollider != null)
            {
                // Controlla se i collider si sovrappongono
                if (coinCollider.bounds.Intersects(cilinderCollider.bounds))
                {
                    if (objectToDisable != null && objectToDisable.activeSelf)
                    {
                        objectToDisable.SetActive(false);
                        objectToEnable1.SetActive(true);
                        objectToEnable2.SetActive(true);
                        objectToEnable3.SetActive(true);
                        objectToEnable4.SetActive(true);
                        objectToEnable5.SetActive(true);
                        objectToEnable6.SetActive(true);
                    }
                }
            }
        }
    }
}
