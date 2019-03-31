using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    public float rotationSpeed = 1;
    public Transform target;
    float mouseX, mouseY;
    public float distance = 2f;
    public Vector3 baseOffset;
    public Vector3 aimOffset;
    private Vector3 offset;
    private Vector3 lookOffset;

    // Use this for initialization
    void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void LateUpdate()
    {
       
        mouseX += Input.GetAxis("Mouse X") * rotationSpeed;
        mouseY -= Input.GetAxis("Mouse Y") * rotationSpeed;
        mouseY = Mathf.Clamp(mouseY, -35, 60);
        this.transform.rotation = Quaternion.Euler(mouseY, mouseX, 0);
        lookOffset = this.transform.rotation * (distance * Vector3.back);
        Vector3 targetOffset;
        if (Input.GetMouseButton(1))
        {
            targetOffset = this.transform.rotation * aimOffset;
        }
        else
        {
            targetOffset = this.transform.rotation * baseOffset;
        }
        offset = Vector3.Slerp(offset, targetOffset, 0.35f);
        this.transform.position = target.transform.position + offset + lookOffset;
    }
}
