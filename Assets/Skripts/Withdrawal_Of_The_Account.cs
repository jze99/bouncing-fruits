using UnityEngine;
using TMPro;
public class Withdrawal_Of_The_Account : MonoBehaviour
{
    private static TextMeshProUGUI score;
    private static TextMeshProUGUI record_Score;
    public Data_base data_Base;
    void Start()
    {
        score = gameObject.transform.GetChild(2).GetComponent<TextMeshProUGUI>();
        record_Score = gameObject.transform.GetChild(3).GetComponent<TextMeshProUGUI>();
        score.text="score: "+data_Base.current_Account;
        record_Score.text="record: "+data_Base.record_Score;
    }
}
