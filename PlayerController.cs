using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float lookSensitivity = 3f;
    
    private Camera playerCamera;
    private float xRotation = 0f;
    private Rigidbody rb;
    
    void Start()
    {
        playerCamera = GetComponentInChildren<Camera>();
        rb = GetComponent<Rigidbody>();
        
        // Khóa và ẩn con trỏ chuột
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        
        // Đóng băng xoay để ngăn lật đổ
        rb.freezeRotation = true;
    }
    
    void Update()
    {
        // Di chuyển chuột
        float mouseX = Input.GetAxis("Mouse X") * lookSensitivity;
        float mouseY = Input.GetAxis("Mouse Y") * lookSensitivity;
        
        // Xoay theo chiều dọc (nhìn lên/xuống)
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);
        playerCamera.transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        
        // Xoay theo chiều ngang (nhìn trái/phải)
        transform.Rotate(Vector3.up * mouseX);
        
        // Đầu vào di chuyển
        float moveX = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");
        
        Vector3 move = transform.right * moveX + transform.forward * moveZ;
        move.y = 0f; // Ngăn bay lên
        
        // Áp dụng di chuyển
          rb.linearVelocity = new Vector3(move.x * moveSpeed, rb.linearVelocity.y, move.z * moveSpeed);
    }
}
