using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Equip_Manager : MonoBehaviour
{
    [SerializeField]
    private GameObject[] elemnt_Shop;//массив с объектами магазина 
    [SerializeField]
    private Data_base data_Base;
    private void Awake() 
    {
        {
            for (int i = 0; i < elemnt_Shop.Length; i++)
            {
                elemnt_Shop[i].GetComponent<Shope>().equip=PlayerPrefs.GetInt("activ"+i);
                elemnt_Shop[i].GetComponent<Shope>().buy=PlayerPrefs.GetInt("buy"+i);
            }
        }
    }
    public void Set_Equip(int _me_Element)
    {
        for(int i=0;i<elemnt_Shop.Length;i++)
        {
            if(elemnt_Shop[i].GetComponent<Shope>().equip==1)
            {
                if(elemnt_Shop[i].GetComponent<Shope>().element!=_me_Element)
                {
                    elemnt_Shop[i].GetComponent<Shope>().On_Equip();
                }
            }
            PlayerPrefs.SetInt("activ"+i,elemnt_Shop[i].GetComponent<Shope>().equip);
            PlayerPrefs.SetInt("buy"+i,elemnt_Shop[i].GetComponent<Shope>().buy);
        }
        data_Base.save_Skin=_me_Element;
        PlayerPrefs.SetInt("skin",data_Base.save_Skin);
    }
}
