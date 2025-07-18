using UnityEngine;

public class MouseFollowCamera : MonoBehaviour
{
    public Transform target;
    public Vector3 offset = new Vector3(-20, 2, -4);
    public float mouseSensitivity = 3f;

    public float maxPitch = 0f;      // Giới hạn nhìn lên
    public float minPitch = 0f;     // Giới hạn nhìn xuống
    public float maxYawOffset = 20f;  // Giới hạn lệch trái/phải so với hướng nhân vật

    float rotationX = 0f; // Pitch (dọc)
    float rotationY = 0f; // Yaw (ngang)

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        // Ban đầu, lấy hướng quay nhân vật để khởi tạo rotationY
        rotationY = target.eulerAngles.y;
    }

    void LateUpdate()
    {
        if (target == null) return;

        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity;

        rotationX -= mouseY;
        rotationX = Mathf.Clamp(rotationX, minPitch, maxPitch);

        rotationY += mouseX;

        // Lấy hướng Yaw của nhân vật để giới hạn góc lệch
        float targetYaw = target.eulerAngles.y;
        float yawDelta = Mathf.DeltaAngle(targetYaw, rotationY);
        yawDelta = Mathf.Clamp(yawDelta, -maxYawOffset, maxYawOffset);
        rotationY = targetYaw + yawDelta;

        // Tính toán vị trí camera
        Quaternion rotation = Quaternion.Euler(rotationX, rotationY, 0);
        Vector3 desiredPosition = target.position + rotation * offset;

        transform.position = desiredPosition;
        transform.LookAt(target.position + Vector3.up * 1.5f);
    }
}
