using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractObjectDetect : MonoBehaviour
{
    public Transform center;
    // Update is called once per frame
    void Update()
    {

        Active();
    }

    void Active()
    {
        if(Camera.main.transform.position == center.position)
        {
            foreach(Transform child in transform)
            {
                child.gameObject.SetActive(true);
            }
        }
        else
        {
            foreach (Transform child in transform)
            {
                child.gameObject.SetActive(false);
            }
        }
    }
}
