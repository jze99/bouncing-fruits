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
    [SerializeField]
    private Sprite[] skins;
    public Sprite skin;
    public int save_Skin;
    private void Start() 
    {
        save_Skin=PlayerPrefs.GetInt("skin");
        for (int i = 0; i < skins.Length; i++)
        {
            if(save_Skin==i)
            {
                skin=skins[i];
            }
        }
    }
}
