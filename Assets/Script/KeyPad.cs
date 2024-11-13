using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyPad : MonoBehaviour
{
    public static bool KeyPadActivated = false;  // 키패드.
    public string curPassword = "6785"; // 비밀번호.
    public string input; // 정답 입력창.
    public string tempInput; //번호 입력칸.
    public bool OnTrigger; // 콜라이더 태크.
    public bool doorOpen; //문 열기
    public bool keypadScreen; // 키패드 화면.
    public Transform doorHinge; // 문 종류.

    void OnTriggerEnter(Collider other)
    {
        OnTrigger = true;
    }

    void OnTriggerExit(Collider other)
    {
        OnTrigger = false;
        tempInput = "";
        keypadScreen = false;
        input = "";
    }

    void Update()
    {
        if (input == curPassword)
        {
            doorOpen = true;
        }

        if (doorOpen)
        {
            var newRot = Quaternion.RotateTowards(doorHinge.rotation, Quaternion.Euler(-90.0f, 0.0f, 0.0f), Time.deltaTime * 250);

            doorHinge.rotation = newRot;
        }
    }

    void OnGUI()
    {
        if (!doorOpen)
        {
            if (OnTrigger)
            {
                GUI.Box(new Rect(600, 500, 400, 100), "E키를 누르세요");

                if (Input.GetKeyDown(KeyCode.E))
                {
                    keypadScreen = true;
                    OnTrigger = false;
                }
            }

            if (keypadScreen)
            {
                GUI.Box(new Rect(0, 0, 320, 455), "");
                GUI.Box(new Rect(5, 5, 310, 25), input);

                if (GUI.Button(new Rect(5, 35, 100, 100), "1"))
                {
                    input = input + "1";
                }

                if (GUI.Button(new Rect(110, 35, 100, 100), "2"))
                {
                    input = input + "2";
                }

                if (GUI.Button(new Rect(215, 35, 100, 100), "3"))
                {
                    input = input + "3";
                }

                if (GUI.Button(new Rect(5, 140, 100, 100), "4"))
                {
                    input = input + "4";
                }

                if (GUI.Button(new Rect(110, 140, 100, 100), "5"))
                {
                    input = input + "5";
                }

                if (GUI.Button(new Rect(215, 140, 100, 100), "6"))
                {
                    input = input + "6";
                }

                if (GUI.Button(new Rect(5, 245, 100, 100), "7"))
                {
                    input = input + "7";
                }

                if (GUI.Button(new Rect(110, 245, 100, 100), "8"))
                {
                    input = input + "8";
                }

                if (GUI.Button(new Rect(215, 245, 100, 100), "9"))
                {
                    input = input + "9";
                }

                if (GUI.Button(new Rect(110, 350, 100, 100), "0"))
                {
                    input = input + "0";
                }


            }

        }

    }
}
