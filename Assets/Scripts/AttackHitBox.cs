using UnityEngine;

public class AttackHitBox : MonoBehaviour
{
    private Mob mob;
    private PlayerReference player;
    [SerializeField] private GameObject[] sparksParticules;
    [SerializeField] private float minVelocityToSpark = 30f;

    private void Start()
    {
        mob = GetComponentInParent<Mob>();
        player = PlayerReference.Instance;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (player.GetCurrentVelocity > minVelocityToSpark)
                Instantiate(sparksParticules[Random.Range(0, sparksParticules.Length)], transform.position + Vector3.up, Quaternion.identity);
            mob.CurrentHealth -= player.GetCurrentVelocity;
            if (mob.CurrentHealth <= 0)
                mob.Dead();
            mob.healthBar.fillAmount = mob.CurrentHealth / mob.MaxHealth;
        }
    }
}
