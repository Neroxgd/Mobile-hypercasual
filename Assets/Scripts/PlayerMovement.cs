using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody rigidbodyPlayer => rb;
    public Vector3 GetInputPosition => inputPosition;
    [SerializeField] private LayerMask layerGround;
    [SerializeField] private float speed = 1f;
    private Rigidbody rb;
    private Vector3 target, inputPosition;
    private bool isPressing;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();

        target = transform.position;
    }

    public void GetInputsPressed(InputAction.CallbackContext context)
    {
        if (context.canceled)
        {
            isPressing = false;
            return;
        }
        isPressing = true;
    }

    public void GetInputsPosition(InputAction.CallbackContext context)
    {
        inputPosition = context.ReadValue<Vector2>();
    }

    private void Update()
    {
        if (isPressing)
        {
            Ray ray = Camera.main.ScreenPointToRay(inputPosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, 100, layerGround))
                target = hit.point + Vector3.up;
        }
        Vector3 relativePos = target - transform.position;
        rb.velocity = relativePos * speed;
        if (relativePos != Vector3.zero)
            transform.rotation = Quaternion.LookRotation(relativePos, Vector3.up);
    }
}