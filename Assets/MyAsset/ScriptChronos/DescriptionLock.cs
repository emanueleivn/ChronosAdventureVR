using UnityEngine;
using System;

public class DescriptionLock : MonoBehaviour
{
    public static event Action<bool> OnLockChanged; // true = lock attivo
    public static bool IsLocked { get; private set; }
    private static int activeCount = 0;

    private void OnEnable()
    {
        activeCount++;
        SetLocked(true);
    }

    private void OnDisable()
    {
        activeCount = Mathf.Max(0, activeCount - 1);
        if (activeCount == 0) SetLocked(false);
    }

    private static void SetLocked(bool locked)
    {
        if (IsLocked == locked) return;
        IsLocked = locked;
        OnLockChanged?.Invoke(IsLocked);
    }
}
