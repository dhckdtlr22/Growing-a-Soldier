using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletState : MonoBehaviour
{
    public float Score;
    public int BulletHp;

    private void Update()
    {
        if(BulletHp <=0)
        {
            Destroy(gameObject);
        }
    }
}
