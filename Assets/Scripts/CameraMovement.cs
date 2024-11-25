using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] private float speed = 5f;
    [SerializeField] private Vector3 cameraTarget = new Vector3(0f, 35f, -35f);

    private void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, PlayerReference.Instance.GetPlayerPosition + cameraTarget, speed * Time.deltaTime);
    }
}
