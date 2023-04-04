using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    [SerializeField]
    private Data_base data_Base;
    private static GameObject panel;
    [SerializeField]
    private bool is_Panel;
    private void Start() 
    {
        data_Base.money=PlayerPrefs.GetInt("money");//загружаем базу данных с деньгами 
        if(is_Panel)
        {
        panel = gameObject.transform.GetChild(5).gameObject;
        panel.SetActive(false);
        }    
    }
    public void Restart()
    {
        SceneManager.LoadScene(1);
    }
    public void Option_On()
    {
        panel.SetActive(true);
    }
    public void Option_Off()
    {
        panel.SetActive(false);
    }
    public void Go_To_Menu()
    {
        SceneManager.LoadScene(0);
    }
    public void Shop()
    {
        SceneManager.LoadScene(3);
    }
    public void Exit()
    {

    }
}
