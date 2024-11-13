using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HammerController : MonoBehaviour
{


    // 현재 장착된 Hammer형 타입 무기.
    [SerializeField]
    private Hammer currentHammer;

    // 공격중??
    private bool isAttack = false;
    private bool isSwing = false;

    private RaycastHit hitInfo;


    // Update is called once per frame
    void Update()
    {

        TryAttack();

    }

    private void TryAttack()
    {
        if (Input.GetButton("Fire1"))
        {
            if (!isAttack)
            {
                StartCoroutine(AttackCoroutine());
            }
        }
    }

    IEnumerator AttackCoroutine()
    {
        isAttack = true;
        currentHammer.anim.SetTrigger("Attack");

        yield return new WaitForSeconds(currentHammer.attackDelayA);
        isSwing = true;

        StartCoroutine(HitCoroutine());

        yield return new WaitForSeconds(currentHammer.attackDelayB);
        isSwing = false;


        yield return new WaitForSeconds(currentHammer.attackDelay - currentHammer.attackDelayA - currentHammer.attackDelayB);
        isAttack = false;
    }

    IEnumerator HitCoroutine()
    {
        while (isSwing)
        {
            if (CheckObject())
            {
                isSwing = false;
                Debug.Log(hitInfo.transform.name);
            }
            yield return null;
        }
    }

    private bool CheckObject()
    {
        if (Physics.Raycast(transform.position, transform.forward, out hitInfo, currentHammer.range))
        {
            return true;
        }
        return false;
    }

}
