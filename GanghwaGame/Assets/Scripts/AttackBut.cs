using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackBut : MonoBehaviour
{
    public GameObject Check;
    public bool IsAttack;
    public float Speed;
    public bool turn;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (IsAttack == true)
        {
            if(Check.transform.position.x <= 45)
            {
                turn = false;
            }
            else if (Check.transform.position.x >= 1035)
            {
                turn = true;
            }

            if(turn == true)
            {
                Check.transform.Translate(-Speed * Time.deltaTime, 0, 0);
            }
            else if(turn == false)
            {
                Check.transform.Translate(Speed * Time.deltaTime, 0, 0);
            }
            
        }
    }
    public void Click()
    {
        
    }
}
