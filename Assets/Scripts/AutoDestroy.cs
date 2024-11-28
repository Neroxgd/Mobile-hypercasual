using UnityEngine;

public class AutoDestroy : MonoBehaviour
{
    [SerializeField] private float timeToDestroy = 2f;

    private void Start()
    {
        Destroy(gameObject, timeToDestroy);
    }
}
