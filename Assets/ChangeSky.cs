using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeSky : MonoBehaviour
{

    [SerializeField] private Material sky;
    [SerializeField] private Texture[] images;
    [SerializeField] private Transform cam;
    [SerializeField] private Vector2 speed;
    private int currentImage;
    private float yaw, pitch;
    // Start is called before the first frame update
    void Start()
    {
       RenderSettings.skybox = sky;
        cam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        LoadNext();
        RotateCamera();
        
    }

    void RotateCamera()
    {
        if (Input.GetKey(KeyCode.Mouse0))
        {
            yaw -= speed.x * Input.GetAxis("Mouse X");
            pitch += speed.y * Input.GetAxis("Mouse Y");
            pitch = Mathf.Clamp(pitch, -90f, 90f);
            cam.eulerAngles = new Vector3(pitch, yaw, 0f);
        }
    }

    void LoadNext()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("Load_Image");

                currentImage++;
                if (currentImage < 0)
                {
                    currentImage = images.Length - 1;
                }
                else if (currentImage > images.Length - 1)
                {
                    currentImage = 0;
                }
                sky.mainTexture = images[currentImage];
            
        }
    }
}
