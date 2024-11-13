using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public class Hammer : MonoBehaviour
{
    public float range; //공격 범위
    public int damage; //공격 데미지
    public float workSpeed; //작업 속도
    public float attackDelay; // 공격 딜레이
    public float attackDelayA; //공격 활성화
    public float attackDelayB; //공격 비활성화

    public Animator anim;
}
