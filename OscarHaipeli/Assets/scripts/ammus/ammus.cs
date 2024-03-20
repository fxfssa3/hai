using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ammus : MonoBehaviour
{
    private float currentSpeed = 5f;
    private float lifespan = 2.5f;
    private float lifeTimer;
    
    private void OnEnable(){
        lifeTimer = lifespan;
    }
   
    void Update()
    {
     transform.Translate (Vector3.up * -1 * currentSpeed * Time.deltaTime); 
     lifeTimer -= Time.deltaTime;
     if(lifeTimer <= 0){
        ammusPoolManager.Instance.ReturnBullet(gameObject);
     }
    }
}
