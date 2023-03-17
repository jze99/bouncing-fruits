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
    public void Save_Record_Score (int _record_Score)
    {
        data_Base.current_Account=_record_Score;
        if(data_Base.current_Account>data_Base.record_Score)
        {
            data_Base.record_Score=data_Base.current_Account;
            PlayerPrefs.SetInt("score",data_Base.record_Score);
            record_Score_Text.text="record "+data_Base.record_Score;
        }
        score_Text.text="score "+data_Base.current_Account;
    }
    public void Load_Record_Score()
    {
        data_Base.record_Score=PlayerPrefs.GetInt("score");
        record_Score_Text.text="record "+data_Base.record_Score;
    }
}
