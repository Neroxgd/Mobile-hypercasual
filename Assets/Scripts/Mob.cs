using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Mob : MonoBehaviour
{
    [SerializeField] private float speed = 1f, distanceCanAttack = 3f, timeBeforeAttack = 0.5f, damage = 10f, animationSpeed = 3f, maxHealth = 100;
    [SerializeField] private Animator animator;
    private bool CloseEnoughToPlayForAttack => Vector3.Distance(player.GetPlayerPosition, transform.position) < distanceCanAttack;
    public Image healthBar;
    public float CurrentHealth { get; set; }
    public float MaxHealth => maxHealth;
    private bool isAttacking, dead;
    private PlayerReference player;

    private void Start()
    {
        CurrentHealth = maxHealth;
        player = PlayerReference.Instance;
    }

    private void Update()
    {
        if (dead) return;
        if (CloseEnoughToPlayForAttack)
        {
            if (!isAttacking)
                StartCoroutine(Attack());
            animator.SetFloat("MoveSpeed", 0);
            animator.speed = 1f;
            return;
        }
        Move();
    }

    private void Move()
    {
        transform.position = Vector3.MoveTowards(transform.position, player.GetPlayerPosition, speed * Time.deltaTime);
        transform.rotation = Quaternion.LookRotation(player.GetPlayerPosition - transform.position, Vector3.up);
        healthBar.transform.parent.LookAt(Camera.main.transform);

        animator.SetFloat("MoveSpeed", 1f);
        animator.speed = animationSpeed;
    }

    private IEnumerator Attack()
    {
        isAttacking = true;
        animator.SetTrigger("Attack");
        yield return new WaitForSeconds(timeBeforeAttack);
        if (CloseEnoughToPlayForAttack)
            player.DealDamage(damage);
        isAttacking = false;
    }

    public void Dead()
    {
        dead = true;
        animator.SetTrigger("Dead");
        Destroy(gameObject, 3f);
    }

    public void OnDestroy()
    {
        if (GameManager.Instance)
            GameManager.Instance.IsWinning();
    }
}
