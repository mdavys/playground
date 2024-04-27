using UnityEngine;

public class FirstPersonLook : MonoBehaviour
{
    private Camera cam;
    public float mouseSensitivity = 100f;
    
    private float rotationX;
    private float rotationY;

    private float upperClamp = 90f;
    private float lowerClamp = -90f;

    void Start()
    {
        cam = GetComponentInChildren<Camera>();
    }

    void Update()
    {
        float mouseX = Input.GetAxis("MouseX") * mouseSensitivity * Time.deltaTime;
        float mouseY = -Input.GetAxis("MouseY") * mouseSensitivity * Time.deltaTime;
        rotationX += mouseY;
        rotationX = Mathf.Clamp(rotationX, lowerClamp, upperClamp);
        rotationY += mouseX;

        transform.rotation = Quaternion.Euler(0, rotationY, 0);
        cam.transform.localRotation = Quaternion.Euler(rotationX, 0, 0);
    }
}
