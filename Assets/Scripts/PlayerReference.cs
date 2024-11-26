using UnityEngine;

public class PlayerReference : MonoBehaviour
{
    public static PlayerReference Instance { get; private set; }
    private PlayerMovement playerMovement;
    [SerializeField] private PlayerHealthBar playerHealthBar;
    public Vector3 GetPlayerPosition => transform.position;
    public Vector3 GetInputPosition => playerMovement.GetInputPosition;
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
    }

    public void DealDamage(float damage)
    {
        playerHealthBar.SetHealth(damage);
    }
}
