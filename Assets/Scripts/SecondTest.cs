using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecondTest : MonoBehaviour
{
    public Transform center;
    public float distanceFromCenter;
    public float angle;
    public Texture texture;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        MoveAround();

        if (Camera.main.transform.position != center.position)
        {
            foreach (Transform child in transform)
            {
                child.gameObject.SetActive(false);
            }
        }
        else
        {
            CheckForCam();
        }
            

    }

    void ChangeSkybox()
    {
        ChangeSky skyChange = GameObject.FindGameObjectWithTag("GM").GetComponent<ChangeSky>();
        skyChange.sky.mainTexture = texture;
    }

    void MoveAround()
    {
        Vector2 thisPos = new Vector2(Mathf.Sin(angle), Mathf.Cos(angle)) * distanceFromCenter;
        transform.position = new Vector3(center.position.x + thisPos.x, center.position.y, center.position.z + thisPos.y);
    }

    void CheckForCam()
    {
        float distance = Vector3.Distance(this.transform.position, Camera.main.transform.position);

        if (this.transform.position == Camera.main.transform.position)
        {

            foreach (Transform child in transform)
            {
                if(child.tag == "NextPoint")
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
}
