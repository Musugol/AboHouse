using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndScript : MonoBehaviour
{
    public GameObject EndUi;

    void OnTriggerEnter(Collider other)
    {
        if (other.tag.Equals("Player"))
        {
            EndUi.SetActive(true);
            Time.timeScale = 0f;
        }
    }
}
