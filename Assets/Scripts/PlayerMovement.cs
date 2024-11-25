using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody rigidbodyPlayer => rb;
    [SerializeField] private LayerMask layerGround;
    [SerializeField] private float speed = 1f;
    private Rigidbody rb;
    private Vector3 target;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, 100, layerGround))
            target = hit.point + Vector3.up;
        Vector3 relativePos = target - transform.position;
        rb.velocity = relativePos * speed;
        transform.rotation = Quaternion.LookRotation(relativePos, Vector3.up);
    }
}