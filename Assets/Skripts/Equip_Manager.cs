using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Equip_Manager : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> elemnt_Shop=new List<GameObject>();
    [SerializeField]
    private Data_base data_Base;
    private void Start() 
    {
        for (int i = 0; i < elemnt_Shop.Count; i++)
        {
            elemnt_Shop[i].GetComponent<Shope>().equip=PlayerPrefs.GetInt("activ"+i);
            elemnt_Shop[i].GetComponent<Shope>().buy=PlayerPrefs.GetInt("buy"+i);
        }
    }
    public void Set_Equip(int _me_Element)
    {
        for(int i=0;i<elemnt_Shop.Count;i++)
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
