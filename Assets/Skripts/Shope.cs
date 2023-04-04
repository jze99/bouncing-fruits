using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class Shope : MonoBehaviour
{
    [SerializeField]
    private Data_base data_Base;
    private GameObject pay_Button;
    private GameObject equip_Button;
    [SerializeField]
    private int price;
    public int equip;
    public int buy;
    private Animator anim;
    public int element;
    [SerializeField]
    private Equip_Manager equip_Manager;
    private void Start() 
    {
        pay_Button=gameObject.transform.GetChild(1).gameObject;
        equip_Button=gameObject.transform.GetChild(2).gameObject;
        anim=equip_Button.GetComponent<Animator>();
        if(buy==1)
        {
            if(equip==1)
            {
                pay_Button.SetActive(false);
                equip_Button.SetActive(true);
                equip_Button.GetComponent<Button>().interactable=false;
                anim.Play("on");
            }
            else
            {
                pay_Button.SetActive(false);
                equip_Button.SetActive(true);
                equip_Button.GetComponent<Button>().interactable=true;
                anim.Play("off");
            }
        }
    }
    public void Buy()
    {
        if(price<=data_Base.money)
        {
            data_Base.money-=price;
            PlayerPrefs.SetInt("money",data_Base.money);
            pay_Button.SetActive(false);
            equip_Button.SetActive(true);
            buy=1;
        }
    }
    public void Equip()
    {
        equip=1;
        equip_Button.GetComponent<Button>().interactable=false;
        equip_Manager.Set_Equip(element);
        data_Base.skin=gameObject.transform.GetChild(0).GetComponent<Image>().sprite;
        anim.Play("on");
    }
    public void On_Equip()
    {
        equip=0;
        equip_Button.GetComponent<Button>().interactable=true;
        anim.Play("off");    
    }
}
