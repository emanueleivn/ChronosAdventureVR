using UnityEngine;

public class LionStatueIllumination : MonoBehaviour
{
    [Header("Referenze")]
    [SerializeField] private Light statueLight;      // La luce che illumina la statua
    [SerializeField] private AudioSource roarSound;  // Il suono del ruggito

    [Header("Bracieri")]
    [SerializeField] private GameObject torchLeft;   // Riferimento al braciere sinistro
    [SerializeField] private GameObject torchRight;  // Riferimento al braciere destro

    [Header("Descrizione")]
    [SerializeField] private GameObject descrizione;

    [Header("Bottoni")]
    [SerializeField] private GameObject bottonAnte;
    [SerializeField] private GameObject bottonPost;

    private bool bothTorchesLit = false;

    private void Update()
    {
        if (torchLeft.GetComponent<ParticleSystem>().isPlaying && torchRight.GetComponent<ParticleSystem>().isPlaying)
        {
            if (!bothTorchesLit)
            {
                bothTorchesLit = true;
                Invoke("LightUpStatue", 3f);
            }
        }
    }

    private void LightUpStatue()
    {
        if (statueLight != null)
        {
            statueLight.intensity = 2f;
            statueLight.range = 10f;
        }

        if (roarSound != null && roarSound.clip != null)
        {
            roarSound.Play();
            // Dopo la durata del ruggito → mostra descrizione e cambia bottoni
            Invoke("MostraDescrizione", roarSound.clip.length-0.6f);
        }
    }

    private void MostraDescrizione()
    {
        if (descrizione != null)
        {
            descrizione.SetActive(true);
        }

        if (bottonAnte != null) bottonAnte.SetActive(false);
        if (bottonPost != null) bottonPost.SetActive(true);
    }
}
