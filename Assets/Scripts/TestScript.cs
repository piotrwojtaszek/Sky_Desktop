using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestScript : MonoBehaviour
{
    public Texture texture;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

       
        CheckForCam();

    }

    void ChangeSkybox()
    {
        ChangeSky skyChange = GameObject.FindGameObjectWithTag("GM").GetComponent<ChangeSky>();
        skyChange.sky.mainTexture = texture;
    } 

    void CheckForCam()
    {
        float distance = Vector3.Distance(this.transform.position, Camera.main.transform.position);

        if (this.transform.position == Camera.main.transform.position)
        {

            foreach (Transform child in transform)
            {
                if (child.tag == "NextPoint")
                {
                    child.gameObject.SetActive(false);
                }
            }
        }
        else if (distance > 1f)
        {

            foreach (Transform child in transform)
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
        if (this.transform.position == Camera.main.transform.position)
        {
            ChangeSkybox();
        }
    }

    void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(this.transform.position, 1f);
    }

}
