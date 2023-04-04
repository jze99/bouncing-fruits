using UnityEngine;
using TMPro;
public class Withdrawal_Of_The_Account : MonoBehaviour
{
    private static TextMeshProUGUI score;
    private static TextMeshProUGUI record_Score;
    private static TextMeshProUGUI money_Text;
    public Data_base data_Base;
    private void Start()
    {
        score = gameObject.transform.GetChild(2).GetComponent<TextMeshProUGUI>();
        record_Score = gameObject.transform.GetChild(3).GetComponent<TextMeshProUGUI>();
        money_Text=gameObject.transform.GetChild(4).GetComponent<TextMeshProUGUI>();
        score.text="score: "+data_Base.current_Account;
        record_Score.text="record: "+data_Base.record_Score;
        money_Text.text="dubl: "+Money(data_Base.platform_Red,data_Base.platform_Gren,data_Base.platform_Blu);
        
    }
    private int Money(int _red,int _grean,int _blu)
    {
        int m =(Mathf.FloorToInt(_red*0.8f)+Mathf.FloorToInt(_grean*1.2f)+Mathf.FloorToInt(_blu*1.5f));
        data_Base.money += m;
        PlayerPrefs.SetInt("money",data_Base.money);
        return m;
    }
}
