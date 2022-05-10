using UnityEngine;
using UnityEngine.Events;

public class Mob : MonoBehaviour
{
    public float destroyDelay = 1f;

    public UnityEvent OnCreated;
    public UnityEvent OnDestroyed;

    private bool isDestroyed = false;
    
    private void Start()
    {
        OnCreated?.Invoke();
    }

    public void Destroy()
    {
        if (isDestroyed)
            return;
        isDestroyed = true;

        Destroy(gameObject, destroyDelay);

        OnDestroyed?.Invoke();
    }
}
