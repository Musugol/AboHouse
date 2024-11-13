using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HammerAttack : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.tag.Equals("Box") && Input.GetMouseButtonDown(0))
        {
            Destroy(other.gameObject);
        }
    }
}
