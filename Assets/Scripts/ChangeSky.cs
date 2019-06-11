using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeSky : MonoBehaviour
{

    public Material sky;
    [SerializeField] private Texture[] images;
    private int currentImage;
 
    // Start is called before the first frame update
    void Start()
    {
       RenderSettings.skybox = sky;
    }

    // Update is called once per frame
    void Update()
    {
        
        
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
