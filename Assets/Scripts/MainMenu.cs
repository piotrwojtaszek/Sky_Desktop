using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public Camera cam;
    public void StartButton()
    {
        cam.GetComponent<CameraRotate>().enabled = true;
        cam.GetComponent<ButtonDetecting>().enabled = true;
    }

    public void QuitButton()
    {
        Application.Quit();
    }
}
