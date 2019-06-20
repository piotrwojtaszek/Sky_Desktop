using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotate : MonoBehaviour
{
    [SerializeField] private Vector2 speed;
    private float yaw, pitch;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        RotateCamera();
    }

    void RotateCamera()
    {
        if (Input.GetKey(KeyCode.Mouse0))
        {
            yaw -= speed.x * Input.GetAxis("Mouse X");
            pitch += speed.y * Input.GetAxis("Mouse Y");
            pitch = Mathf.Clamp(pitch, -90f, 40f);
            transform.eulerAngles = new Vector3(pitch, yaw, 0f);
        }
    }
}
