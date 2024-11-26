using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] private float speed = 1f;
    [SerializeField] private Vector3 cameraTarget = new Vector3(0f, 35f, -35f);
    private float currentSpeed;
    private float closeToBordure;
    private PlayerReference player;

    private void Start()
    {
        player = PlayerReference.Instance;
    }

    private void Update()
    {
        float closeToBordureWidth = Mathf.Abs(player.GetInputPosition.x - Screen.width / 2f) / Screen.width;
        float closeToBordureHeight = Mathf.Abs(player.GetInputPosition.y - Screen.height / 2f) / Screen.height;
        closeToBordure = closeToBordureWidth > closeToBordureHeight ? closeToBordureWidth : closeToBordureHeight;
        currentSpeed = Time.deltaTime * speed * closeToBordure;
        transform.position = Vector3.MoveTowards(transform.position, player.GetPlayerPosition + cameraTarget, currentSpeed);
    }
}
