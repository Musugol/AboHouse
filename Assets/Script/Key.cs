using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Key : MonoBehaviour
{
    public Component doorcolliderhere; // 문 종류
    public GameObject keygone; // 키 종류
    public GameObject uiObject; //UI
    

    void Start()
    {
        uiObject.SetActive(false);
    }

    void OnTriggerStay()
    {
        uiObject.SetActive(true);

        if (Input.GetKeyDown(KeyCode.E))
        {
            doorcolliderhere.GetComponent<BoxCollider>().enabled = true;
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            keygone.SetActive(false);
            uiObject.SetActive(false);
        }
            
    }

    void OnTriggerExit()
    {
        uiObject.SetActive(false);
    }
}