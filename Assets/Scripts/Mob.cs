using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Mob : MonoBehaviour
{
    [SerializeField] private float speed = 1f, distanceCanAttack = 3f, timeBeforeAttack = 0.5f, damage = 10f;
    [SerializeField] private float maxHealth = 100;
    private bool CloseEnoughToPlayForAttack => Vector3.Distance(player.GetPlayerPosition, transform.position) < distanceCanAttack;
    public Image healthBar;
    public float CurrentHealth { get; set; }
    public float MaxHealth => maxHealth;
    private bool isAttacking;
    private PlayerReference player;

    private void Start()
    {
        CurrentHealth = maxHealth;
        player = PlayerReference.Instance;
    }

    private void Update()
    {

        if (CloseEnoughToPlayForAttack)
        {
            if (!isAttacking)
                StartCoroutine(Attack());
            return;
        }
        transform.position = Vector3.MoveTowards(transform.position, player.GetPlayerPosition, speed * Time.deltaTime);
        transform.rotation = Quaternion.LookRotation(player.GetPlayerPosition - transform.position, Vector3.up);
        healthBar.transform.parent.LookAt(Camera.main.transform);
    }

    private IEnumerator Attack()
    {
        isAttacking = true;
        yield return new WaitForSeconds(timeBeforeAttack);
        if (CloseEnoughToPlayForAttack)
            player.DealDamage(damage);
        isAttacking = false;
    }
}
