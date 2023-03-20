using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    private static GameObject panel;
    [SerializeField]
    private bool is_Panel;
    private void Start() 
    {
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
}
