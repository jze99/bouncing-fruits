using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    public bool activ=false;
    private GameObject Player;
    private void Start() 
    {
        Player=GameObject.FindGameObjectWithTag("Player");    
    }
    private void FixedUpdate() 
    {
        if(Player.transform.position.y-0.28f<=transform.position.y)
        {
            gameObject.GetComponent<Collider2D>().isTrigger=true;
        }
        else
        {
            gameObject.GetComponent<Collider2D>().isTrigger=false;
        }
    }
    public bool Activiti_Platform()
    {
        return activ=true;
    }
}
