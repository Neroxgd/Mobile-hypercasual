using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Mob : MonoBehaviour
{
    [SerializeField] private float speed = 1f, distanceCanAttack = 3f, timeBeforeAttack = 0.5f, timeHitBoxAttack = 0.5f;
    [SerializeField] private int maxHealth = 100;
    [SerializeField] private Image healthBar;
    [SerializeField] private GameObject attackHitBox;
    private float currentHealth;
    private PlayerReference player;

    private void Start()
    {
        currentHealth = maxHealth;
        player = PlayerReference.Instance;
    }

    private void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, player.GetPlayerPosition, speed * Time.deltaTime);
        transform.rotation = Quaternion.LookRotation(player.GetPlayerPosition - transform.position, Vector3.up);
        if (Vector3.Distance(player.GetPlayerPosition, transform.position) < distanceCanAttack)
            StartCoroutine(Attack());
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            currentHealth -= player.GetCurrentVelocity;
            if (currentHealth <= 0)
                Destroy(gameObject);
            healthBar.fillAmount = currentHealth / maxHealth;
        }
    }

    private IEnumerator Attack()
    {
        yield return new WaitForSeconds(timeBeforeAttack);
        attackHitBox.SetActive(true);
        yield return new WaitForSeconds(timeHitBoxAttack);
        attackHitBox.SetActive(false);
    }
}
