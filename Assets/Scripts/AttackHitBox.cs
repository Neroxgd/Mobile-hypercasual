using UnityEngine;

public class AttackHitBox : MonoBehaviour
{
    [SerializeField] private int damage = 10;

    private void OnTriggerEnter(Collider other)
    {
        if (CompareTag("Player"))
            PlayerReference.Instance.DealDamage(damage);
    }
}
