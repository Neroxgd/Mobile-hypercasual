using UnityEngine;

public class AttackHitBox : MonoBehaviour
{
    private Mob mob;
    private PlayerReference player;

    private void Start()
    {
        mob = GetComponentInParent<Mob>();
        player = PlayerReference.Instance;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            mob.CurrentHealth -= player.GetCurrentVelocity;
            if (mob.CurrentHealth <= 0)
                Destroy(mob.gameObject);
            mob.healthBar.fillAmount = mob.CurrentHealth / mob.MaxHealth;
        }
    }
}
