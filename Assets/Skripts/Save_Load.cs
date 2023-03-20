using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Save_Load : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI score_Text;//текущий счёт текст
    [SerializeField]
    private TextMeshProUGUI record_Score_Text;//рекордный счёт текст
    public Data_base data_Base;
    public void Save_Record_Score (int _record_Score)//сохраняем переданный сюда счёт
    {
        data_Base.current_Account=_record_Score;//присваеваем переданный сюда счет базе данных октуальный счёт
        if(data_Base.current_Account>data_Base.record_Score)//проверям если рекорд меньше или равен текущему счёту тогда 
        {
            data_Base.record_Score=data_Base.current_Account;//перезаписывам старый рекорд текущим счётом
            PlayerPrefs.SetInt("score",data_Base.record_Score);//сохраняем текущий рекорд
            record_Score_Text.text="record "+data_Base.record_Score;//обновлям текст с рекордом
        }
        score_Text.text="score "+data_Base.current_Account;//изменяем текст с счётом на атуальный
    }
    public void Load_Record_Score()
    {
        data_Base.record_Score=PlayerPrefs.GetInt("score");
        record_Score_Text.text="record "+data_Base.record_Score;
    }
}
