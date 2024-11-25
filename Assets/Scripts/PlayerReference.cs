using UnityEngine;

public class PlayerReference : MonoBehaviour
{
    public static PlayerReference Instance { get; private set; }
    private PlayerMovement playerMovement;
    private PlayerHealthBar playerHealthBar;
    public Vector3 GetPlayerPosition => transform.position;
    public float GetCurrentVelocity => playerMovement.rigidbodyPlayer.velocity.magnitude;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;

        playerMovement = GetComponent<PlayerMovement>();
        playerHealthBar = GetComponent<PlayerHealthBar>();
    }

    public void DealDamage(int damage)
    {
        playerHealthBar.SetHealth(damage);
    }
}
