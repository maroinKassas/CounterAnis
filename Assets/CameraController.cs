using UnityEngine;

public class CameraController : MonoBehaviour
{
    private const float ANGLE_MIN = -10.0f, ANGLE_MAX = 5.0f;
    private const float POSITION_CAM_X = 0, POSITION_CAM_Y = 2f, POSITION_CAM_Z = -4f;
    private const float MOUSE_SENSITIVITY = 5;
    private float mouseX, mouseY;
    private float rotateAmountX, rotateAmountY;
    private Vector3 direction;
    private Transform playerTransform;

    // Start is called before the first frame update
    void Start()
    {
        playerTransform = transform.parent.GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        Cursor.lockState = CursorLockMode.Locked;

        mouseX += Input.GetAxis("Mouse X");
        mouseY += Input.GetAxis("Mouse Y");

        mouseY = Mathf.Clamp(mouseY, ANGLE_MIN, ANGLE_MAX);
    }

    private void LateUpdate()
    {
        direction = new Vector3(POSITION_CAM_X, POSITION_CAM_Y, POSITION_CAM_Z);

        rotateAmountX = mouseX * MOUSE_SENSITIVITY;
        rotateAmountY = mouseY * MOUSE_SENSITIVITY;

        transform.rotation = Quaternion.Euler(-rotateAmountY, rotateAmountX, 0);
        playerTransform.transform.rotation = Quaternion.Euler(0, rotateAmountX, 0);

        transform.position = playerTransform.position + transform.rotation * direction;
    }
}