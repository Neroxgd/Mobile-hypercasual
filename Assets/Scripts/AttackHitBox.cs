using UnityEngine;

public class AttackHitBox : MonoBehaviour
{
    [SerializeField] private int damage = 10;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerReference.Instance.DealDamage(damage);
            print("atk");
        }
    }
}
