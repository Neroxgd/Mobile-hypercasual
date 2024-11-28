using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerReference : MonoBehaviour
{
    public static PlayerReference Instance { get; private set; }
    private PlayerMovement playerMovement;
    [SerializeField] private PlayerHealthBar playerHealthBar;
    private PlayerInput playerInput;
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
        playerInput = GetComponent<PlayerInput>();
    }

    public void DealDamage(float damage)
    {
        playerHealthBar.SetHealth(damage);
    }

    public void DisableInputs(bool enable)
    {
        playerInput.enabled = enable;
    }
}
