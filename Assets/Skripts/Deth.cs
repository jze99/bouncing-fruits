using UnityEngine.SceneManagement;
using UnityEngine;

public class Deth : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.transform.tag=="Player")
        {
            SceneManager.LoadScene(2);
        }    
    }
}
