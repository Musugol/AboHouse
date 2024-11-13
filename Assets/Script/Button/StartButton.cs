using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartButton : MonoBehaviour
{
    public GameObject UIobj;

    public void OnClickExit()
    {
        Time.timeScale = 1f;
        UIobj.SetActive(false);
    }
}
