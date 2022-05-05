using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletData : MonoBehaviour
{
    public gunHandle projtileSource;
    float dmg; 
    private void OnCollisionEnter(Collision other) {
        if(other.gameObject.CompareTag("enemy"))
            projtileSource.hitFeedback();
        //gameObject.SetActive(false);
    }
}
