using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMaker : MonoBehaviour
{
    public GameObject Enemy;
    public float Curtime;
    public float Cooltime;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Curtime += Time.deltaTime;
        if(Curtime >= Cooltime)
        {
            GameObject enemy = Instantiate(Enemy, transform.position, transform.rotation);
            enemy.name = "Enemy";
            Curtime = 0;
        }
    }
}
