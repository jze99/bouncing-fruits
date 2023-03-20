using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Disappearing_Platform : MonoBehaviour
{
    private void OnCollisionEnter(Collision other) 
    {
        if(other.transform.tag=="Player")
        {
           Destroy(gameObject); 
        }
    }
}
