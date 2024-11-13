using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoor : MonoBehaviour
{
    public Animation hingehere; // 애니메이션.
    public bool OnTrigger; // 콜라이더 태그.
    public bool doorOpen; //문 열기.
    public Transform doorHinge; //문 종류.
    public GameObject uiObject;

    void Start()
    {
        uiObject.SetActive(false);
    }

    void OnTriggerEnter(Collider other)
    {
        uiObject.SetActive(true);
        OnTrigger = true;
    }
    
    void OnTriggerStay()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            hingehere.Play();
            doorOpen = true;
            OnTrigger = false;
        }
        if (doorOpen)
        {
            if (OnTrigger)
            {
                uiObject.SetActive(false);
            }
        }
    }
    
    void OnTriggerExit(Collider other)
    {
        uiObject.SetActive(false);
        OnTrigger = false;
    }
    /*
    void OnGUI()
    {
        if (!doorOpen)
        {
            if (OnTrigger)
            {
                GUI.Box(new Rect(600, 500, 400, 100), "E키를 누르세요");

                if (Input.GetKeyDown(KeyCode.E))
                {
                    doorOpen = true;
                    OnTrigger = false;
                }
                else
                {
                    if (Input.GetKeyDown(KeyCode.E))
                    {
                        doorOpen = false;
                    }
                }

            }
        }

    }*/
}