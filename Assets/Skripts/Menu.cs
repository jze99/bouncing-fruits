using UnityEngine.SceneManagement;
using UnityEngine;

public class Menu : MonoBehaviour
{
    public void Restart()
    {
        SceneManager.LoadScene(1);
    }
}
