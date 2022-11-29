using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyState : MonoBehaviour
{
    
    public float EnemySpeed;
    public int DropCoin;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(EnemySpeed * Time.deltaTime, 0, 0);

    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Bullet"))
        {
            other.GetComponent<BulletState>().BulletHp--;
            Destroy(gameObject);
        }
    }

}
