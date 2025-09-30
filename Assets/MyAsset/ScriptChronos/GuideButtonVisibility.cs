using UnityEngine;
using System.Collections.Generic;

public class GuideButtonVisibility : MonoBehaviour
{
    // Tiene traccia di quante descrizioni sono attive in questo momento
    private static readonly HashSet<GameObject> activeDescriptions = new HashSet<GameObject>();

    private void OnEnable()
    {
        // Questa descrizione è ora attiva
        activeDescriptions.Add(gameObject);
        SyncButtons();
    }

    private void OnDisable()
    {
        // Questa descrizione non è più attiva
        activeDescriptions.Remove(gameObject);
        SyncButtons();
    }

    private void OnDestroy()
    {
        activeDescriptions.Remove(gameObject);
        SyncButtons();
    }

    private static void SyncButtons()
    {
        bool anyDescriptionActive = activeDescriptions.Count > 0;
        GameObject[] guideButtons = GameObject.FindGameObjectsWithTag("GuideButton");

        foreach (var btn in guideButtons)
        {
            if (btn != null)
                btn.SetActive(!anyDescriptionActive);
        }
    }
}
