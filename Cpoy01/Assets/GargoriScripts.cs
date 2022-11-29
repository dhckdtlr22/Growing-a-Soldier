using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GargoriScripts : MonoBehaviour
{ public float Speed;
    public float FristSpeed;
    public Player player;
    public Vector3 dir;
    public Quaternion Qudir;
    public bool Check;
    // Start is called before the first frame update
    void Start()
    {
        FristSpeed = Speed;
    }

    // Update is called once per frame
    void Update()
    {
        if (Check == true)
        {
            transform.position = dir;
            transform.rotation = Qudir;
        }
       
    }
    public void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Wall"))
        {
            
            dir = transform.position;
            Qudir = transform.rotation;
            Debug.Log("1111");
            Check = true;
            Speed = 0;
            player.dir = player.transform.position;
            player.State = Player.PlayerSTATE.DOWN;
        }
        else
        {
            Check = false;
            Speed = FristSpeed;
            dir = Vector3.zero;
        }
    }
}
