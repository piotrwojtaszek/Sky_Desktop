using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonDetecting : MonoBehaviour
{
    Camera cam;
    Renderer hitMaterial;
    // Start is called before the first frame update
    void Start()
    {
        cam = GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        DetectObjestTag();
       
    }

    void DetectObjestTag()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            RaycastHit hit;
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit))
            {
                //Transform objectHit = hit.transform;
                Debug.Log(hit.transform.name);
                Move(hit);
            }
        }

        CheckForMouse();


       
    }

    void Move(RaycastHit hit)
    {
        if (hit.transform.tag == "NextPoint")
        {
            this.transform.position = hit.transform.position;
        }
    }

    void CheckForMouse()
    {
        
        RaycastHit hit;
        Ray ray = cam.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit))
        {
            hitMaterial = hit.transform.gameObject.GetComponent<Renderer>();
            hitMaterial.material.color = new Color(1f, 1f, 1f, 0.5f);
        }
        else
        {
            if(hitMaterial != null)
            {
                
                hitMaterial.material.color = new Color(1f, 1f, 1f, 0.2f);
            }
        }
    }
}
