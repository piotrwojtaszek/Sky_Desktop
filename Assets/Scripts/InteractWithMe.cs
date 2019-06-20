using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class InteractWithMe : MonoBehaviour
{

    public GameObject textPanel;
    public GameObject buttonPanel;
    [TextArea] public string myText;
    EventSystem m_EventSystem;
    private Renderer renderer;
    public Transform textPosRef;

    void OnEnable()
    {
        
        m_EventSystem = EventSystem.current;
        renderer = GetComponent<Renderer>();

    }
    void OnDisable()
    {
        if (buttonPanel.gameObject.activeSelf == true)
        {
            buttonPanel.gameObject.SetActive(false);
        }

    }

    void Update()
    {
        if (renderer.isVisible)
        {
            Vector3 textPos = Camera.main.WorldToScreenPoint(textPosRef.position);
            Vector3 buttonPos = Camera.main.WorldToScreenPoint(this.transform.position);
            textPanel.transform.position = textPos;
            buttonPanel.transform.position = buttonPos;
            buttonPanel.gameObject.SetActive(true);
        }
        else
        {
            buttonPanel.gameObject.SetActive(false);
            DisableText();
        }



        //buttonPanel.transform.position = new Vector3(buttonPanel.transform.position.x, buttonPanel.transform.position.y, Mathf.Clamp(buttonPanel.transform.position.z, 0f, 6f));

        if (GetMeTag(m_EventSystem) == buttonPanel.name)
        {
            if (textPanel.gameObject.activeSelf == false)
            {
                DisplayText();
            }
            else
            {
                DisableText();
            }
        }
    }

    public void DisplayText()
    {
        Text tempText = textPanel.GetComponentInChildren<Text>();
        if (tempText.text != myText)
        {
            tempText.text = myText;
        }
        textPanel.gameObject.SetActive(true);
        buttonPanel.GetComponentInChildren<Text>().text = "HIDE";
    }

    public void DisableText()
    {
        textPanel.gameObject.SetActive(false);
        buttonPanel.GetComponentInChildren<Text>().text = "SHOW";
    }

    public string GetMeTag(EventSystem m_EventSystem)
    {
        if (m_EventSystem != null && Input.GetKeyDown(KeyCode.Mouse0) && m_EventSystem.IsPointerOverGameObject())
        {
            return m_EventSystem.currentSelectedGameObject.name;
        }
        else
        {
            return " ";
        }
    }


}
