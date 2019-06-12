using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestScript : MonoBehaviour
{
    
    GameObject cam;
    CameraProperties cp;
    public Texture texture;
    public Transform centerPoint;
    [Range(0f,5f)]public float rotateAngle;
    private float oldRotateAngle;
    void Start()
    {
        cp = GameObject.FindGameObjectWithTag("GM").GetComponent<CameraProperties>();
        

    }
    // Start is called before the first frame update
    void Update()
    {
        

        cam = cp.camera;
        float distance = Vector3.Distance(this.transform.position,cam.transform.position);
        
        if (this.transform.position == cam.transform.position || distance>1f )
        {
            
            foreach(Transform child in transform)
            {
                child.gameObject.SetActive(false);
            }
        }
        else
        {
            foreach (Transform child in transform)
            {
                child.gameObject.SetActive(true);
            }
        }
        if(this.transform.position == cam.transform.position)
        {
            ChangeSkybox();
        }

        RotateAround();
    }

    void ChangeSkybox()
    {
        ChangeSky skyChange = GameObject.FindGameObjectWithTag("GM").GetComponent<ChangeSky>();
        skyChange.sky.mainTexture = texture;
    }

    void RotateAround()
    {
        if(oldRotateAngle != rotateAngle)
        {
            transform.RotateAround(centerPoint.position, Vector3.up, rotateAngle);
        }

        oldRotateAngle = rotateAngle;
    }


}
