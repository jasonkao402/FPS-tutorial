using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletData : MonoBehaviour
{
    public gunHandle projtileSource;
    float dmg;
    private void OnEnable() {
        Invoke("disable", 2);
    }
    void disable()
    {
        gameObject.SetActive(false);
    }
    private void OnCollisionEnter(Collision other) {
        if(other.gameObject.CompareTag("enemy") && projtileSource != null)
            projtileSource.hitFeedback();
        //gameObject.SetActive(false);
    }
}
