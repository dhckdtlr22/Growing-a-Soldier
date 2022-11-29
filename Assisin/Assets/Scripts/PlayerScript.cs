using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PlayerScript : MonoBehaviour
{
    public enum STATE
    {
        IDLE = 0,
        SHOOT,
    }
    public RectTransform img;
    public float Speed;
    public float a;
    public bool Stop;
    public bool turn;
    public GameObject[] Bullet;
    public Transform Pos;
    Vector3 dir;
    public float Curtime;
    public float Cooltime;
    // Start is called before the first frame update
    void Start()
    {
        int a = Random.Range(76, 1845);
        dir = img.transform.position;
        dir.x = a;
        img.transform.position = dir;
    }

    // Update is called once per frame
    void Update()
    {
        if(Stop == false)
        {
            if (img.transform.position.x <= 75)
            {
                turn = true;
            }
            if (img.transform.position.x >= 1845)
            {
                turn = false;
            }
            if(turn == true)
            {
                img.transform.Translate(Speed * Time.deltaTime, 0, 0);
            }
            else
            {
                img.transform.Translate(-Speed * Time.deltaTime, 0, 0);
            }
            a = img.transform.position.x;
        }
        else
        {
            Curtime += Time.deltaTime;
        }


        if (Input.GetKeyDown(KeyCode.Space) && Stop == false)
        {
            Stop = true;
            if (a >= 925 && a <= 995)
            {
                Debug.Log("Perfact");

                GameObject bullet = Instantiate(Bullet[1], Pos.transform.position,transform.rotation);
                bullet.name = "Bullet";
            }
           else if (a >= 800 && a <= 1120)
            {
                GameObject bullet = Instantiate(Bullet[0], Pos.transform.position, transform.rotation);
                bullet.name = "Bullet";
            }
            else
            {
                Debug.Log("bad");
            }
            int b = Random.Range(76, 1845);
            dir = img.transform.position;
            dir.x = b;  
            img.transform.position = dir;
            Curtime = 0;
        }
        if(Curtime> Cooltime)
        {
            Stop = false;
            
        }
    }
    public void Shoot()
    {

    }
}
