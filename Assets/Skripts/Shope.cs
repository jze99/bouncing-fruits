using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class Shope : MonoBehaviour
{
    [SerializeField]
    private Data_base data_Base;//база данных
    private GameObject pay_Button;//кнопака покупки
    private GameObject equip_Button;//кнопка экипировка(выбора объекта в магазине)
    [SerializeField]
    private int price;//цена этого объекта
    public int equip;//показатель того что мы экипировали объект
    public int buy;//показатель того что мы купили этот объект
    private Animator anim;//аниматор для проигрывания анимаций кнопки экипировки объекта
    public int element;//порядковый номер товара
    [SerializeField]
    private Equip_Manager equip_Manager;//менаджер экипировки
    private void Start() 
    {
        pay_Button=gameObject.transform.GetChild(1).gameObject;//наполняем кнопку покупки
        equip_Button=gameObject.transform.GetChild(2).gameObject;//наполняем кнопку экипировки
        anim=equip_Button.GetComponent<Animator>();//наполняем аниматор кнопки экипировки
        if(buy==1)//после того как загрузили данные спрашиваем куплин ли у нас объкт
        {
            if(equip==1)//спрашиваем экипирован ли у нас объект
            {
                pay_Button.SetActive(false);//делаем кнопку пакупки не активной
                equip_Button.SetActive(true);//делаем кнопку экипировки ктивной
                equip_Button.GetComponent<Button>().interactable=false;//делаем кнопку экипировки не интерактивной
                anim.Play("on");//запускаем анимацию экипировки
            }
            else
            {
                pay_Button.SetActive(false);//кнопка покупки неактивной
                equip_Button.SetActive(true);//кнопа экипировки активна
                equip_Button.GetComponent<Button>().interactable=true;//делаем кнопку экипировки интерактивной
                anim.Play("off");//запускаем анимацию выключения экипировки
            }
        }
    }
    public void Buy()//метод покупка срабатывает по нажатию кнопки покупки
    {
        if(price<=data_Base.money)//спрашиваем достаточно ли у нас денег
        {
            data_Base.money-=price;//вычитываем цену из базы данных
            PlayerPrefs.SetInt("money",data_Base.money);//сохраням бозу данных
            pay_Button.SetActive(false);//делаем кнопку покупки неактивной
            equip_Button.SetActive(true);//делаем кнопку экипировки активной
            buy=1;//состояние покупки ставим правда
        }
    }
    public void Equip()//метод экипировки сробатывает по нажатию кнопки экипировка 
    {
        equip=1;//изменяем состояние экипирвки на правда
        equip_Button.GetComponent<Button>().interactable=false;//делаем кнопку экипировки не интерактивной
        equip_Manager.Set_Equip(element);//вызываем метод из другого скрипта 
        data_Base.skin=gameObject.transform.GetChild(0).GetComponent<Image>().sprite;//загружаем в базу данных наш скин
        anim.Play("on");//запускаем анимацию экипировано
    }
    public void On_Equip()//метод который делает наш объект обратно не экипированным 
    {
        equip=0;//изменяет состояния экипировки 
        equip_Button.GetComponent<Button>().interactable=true;//делает кнопку экипировки интерактивной
        anim.Play("off");//запускают анимацтю выключания экипировки
    }
}
