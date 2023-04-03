using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "New score", menuName = "score")]
public class Data_base : ScriptableObject
{
    public int record_Score;
    public int current_Account;
    public int platform_Red;
    public int platform_Blu;
    public int platform_Gren;
    public int money;
    public Sprite skin;
}
