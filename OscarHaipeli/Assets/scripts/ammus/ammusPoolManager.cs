using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ammusPoolManager : MonoBehaviour
{
    public static ammusPoolManager Instance;
    public GameObject bulletPrefab;
    public int poolSize = 20;
    private Queue<GameObject> bulletPool = new Queue<GameObject>();
    // Start is called before the first frame update
    void Awake()
    {

       Instance = this;
       InitializePool(); 
    }
    private void InitializePool()
    {
        for (int i = 0; i < poolSize; i++){
            GameObject newbullet = Instantiate(bulletPrefab);
            newbullet.SetActive(false);
            bulletPool.Enqueue(newbullet);
        }
    }
    // Update is called once per frame
    public GameObject GetBullet(){
        if (bulletPool.Count > 0){
            GameObject bullet = bulletPool.Dequeue();
            bullet.SetActive(true);
            return bullet;
     
        }
        return null;
    }

}
