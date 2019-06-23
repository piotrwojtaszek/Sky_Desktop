using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeSky : MonoBehaviour
{

    public Material sky;
    private int currentImage;
    public GameObject startPanel;
    public Camera cam;
    // Start is called before the first frame update
    void Start()
    {
        RenderSettings.skybox = sky;
        startPanel.SetActive(true);
        cam.GetComponent<CameraRotate>().enabled = false;
        cam.GetComponent<ButtonDetecting>().enabled = false;
    }


}
