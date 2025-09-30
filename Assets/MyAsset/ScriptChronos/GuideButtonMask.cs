using UnityEngine;

[DisallowMultipleComponent]
public class GuideButtonMask : MonoBehaviour
{
    private CanvasGroup cg;
    private float baseAlpha = 1f;
    private bool baseInteractable = true;
    private bool baseBlocks = true;

    private void Awake()
    {
        cg = GetComponent<CanvasGroup>();
        if (cg == null) cg = gameObject.AddComponent<CanvasGroup>();

        // Salvo i valori originali del bottone
        baseAlpha = cg.alpha;
        baseInteractable = cg.interactable;
        baseBlocks = cg.blocksRaycasts;
    }

    private void OnEnable()
    {
        // Mi iscrivo agli eventi e applico subito lo stato corrente (utile se il bottone nasce durante un lock)
        DescriptionLock.OnLockChanged += HandleLockChanged;
        HandleLockChanged(DescriptionLock.IsLocked);
    }

    private void OnDisable()
    {
        DescriptionLock.OnLockChanged -= HandleLockChanged;
        // Non ripristino nulla qui: il ripristino avviene quando il lock torna false
    }

    private void HandleLockChanged(bool locked)
    {
        if (locked)
        {
            cg.alpha = 0f;
            cg.interactable = false;
            cg.blocksRaycasts = false;
        }
        else
        {
            cg.alpha = baseAlpha;
            cg.interactable = baseInteractable;
            cg.blocksRaycasts = baseBlocks;
        }
    }
}
