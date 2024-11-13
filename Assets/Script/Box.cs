using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box : MonoBehaviour
{

    [SerializeField]
    private int hp; // 박스의 체력.

    [SerializeField]
    private BoxCollider col; // 박스 컬라이더.


    // 필요한 게임 오브젝트.
    [SerializeField]
    private GameObject go_box; // 일반 바위.

    public void Mining()
    {

        hp--;

        if (hp <= 0)
            Destruction();
    }

    private void Destruction()
    {
        col.enabled = false;
        Destroy(go_box);
    }

}
