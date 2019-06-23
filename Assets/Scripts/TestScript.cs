using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestScript : MonoBehaviour
{
    public Texture texture;
    // Start is called before the first frame update
    void Update()
    {
        if(Camera.main != null)
        {
            float distance = Vector3.Distance(this.transform.position, Camera.main.transform.position);

            if (this.transform.position == Camera.main.transform.position || distance > 1f)
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
        


    }

    void ChangeSkybox()
    {
        ChangeSky skyChange = GameObject.FindGameObjectWithTag("GM").GetComponent<ChangeSky>();
        skyChange.sky.mainTexture = texture;
    }
    void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, 1f);
    }
}
