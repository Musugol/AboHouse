using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ItemEffect
{
    public string itemName; // 아이템의 이름. (키값)
    [Tooltip("HUNGRY 가능합니다")]
    public string[] part; // 부위.
    public int[] num; // 수치.
}

public class ItemEffectDatabase : MonoBehaviour
{
    public GameObject Weapon;

    [SerializeField]
    private ItemEffect[] itemEffects;

    //필요한 컴포넌트
    [SerializeField]
    private StatusController thePlayerStatus;


    private const string HUNGRY = "HUNGRY";

    public void UseItem(Item _item)
    {

        if (_item.itemType == Item.ItemType.Equipment)
        {
            Weapon.SetActive(true);
            Debug.Log(_item.itemName + "를 장착했습니다.");
        }
        else if (_item.itemType == Item.ItemType.Used)
        {

            for (int x = 0; x < itemEffects.Length; x++)
            {

                if (itemEffects[x].itemName == _item.itemName)
                {

                    for (int y = 0; y < itemEffects[x].part.Length; y++)
                    {

                        switch (itemEffects[x].part[y])
                        {
                            case HUNGRY:
                                thePlayerStatus.IncreaseHungry(itemEffects[x].num[y]);
                                break;
                            default:
                                Debug.Log("HUNGRY만 가능합니다");
                                break;
                        }
                        Debug.Log(_item.itemName + " 을 사용했습니다");

                    }
                    return;
                }


            }
            Debug.Log("ItemEffectDatabase에 일치하는 itemName 없습니다");
        }

    }
}
