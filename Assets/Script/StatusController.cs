using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatusController : MonoBehaviour
{
    public GameObject EndUi;
    public GameObject StartUi;
    // 체력
    [SerializeField]
    private int hungry;
    private int currentHungry;

    // 체력이 줄어드는 속도
    [SerializeField]
    private int hungryDecreaseTime;
    private int currentHungryDecreaseTime;

    // 필요한 이미지
    [SerializeField]
    private Image[] images_Gauge;

    private const int HUNGRY = 0;

    // Use this for initialization
    void Start()
    {
        currentHungry = hungry;
    }

    // Update is called once per frame
    void Update()
    {
        Hungry();
        GaugeUpdate();
    }

    private void Hungry()
    {
        if (currentHungry > 0)
        {
            if (currentHungryDecreaseTime <= hungryDecreaseTime)
                currentHungryDecreaseTime++;
            else
            {
                currentHungry--;
                currentHungryDecreaseTime = 0;
            }
        }
        else
        {
            Debug.Log("체력이 0이 되었습니다.");
            Time.timeScale = 0;
            EndUi.SetActive(true);
            StartUi.SetActive(false);
        }
    }

    private void GaugeUpdate()
    {
        images_Gauge[HUNGRY].fillAmount = (float)currentHungry / hungry;
    }
    public void IncreaseHungry(int _count)
    {
        if (currentHungry + _count < hungry)
            currentHungry += _count;
        else
            currentHungry = hungry;
    }

    public void DecreaseHungry(int _count)
    {
        if (currentHungry - _count < 0)
            currentHungry = 0;
        else
            currentHungry -= _count;
    }
}
