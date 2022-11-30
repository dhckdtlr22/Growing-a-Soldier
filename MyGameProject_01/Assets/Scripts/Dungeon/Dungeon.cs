using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Dungeon : MonoBehaviour
{
    public GameObject System;
    public GameObject Content;
    public MyState myState;
    public EnemyState enemyState;
    // Start is called before the first frame update
    void Start()
    {
        Content = GameObject.Find("Content");
        myState = GetComponent<MyState>();
        enemyState = GetComponent<EnemyState>();
    }

    // Update is called once per frame
    void Update()
    {
        if (myState.IsAttack == true)
        {
            myState.IsAttack = false;
            GameObject systems = Instantiate(System);
            systems.transform.SetParent(Content.transform);
            Debug.Log(myState.ttD);
            systems.GetComponent<Text>().text = $"<color=#008000>내가</color>가 <color=#ff0000>적</color>에게 Damage{myState.ttD}를 입힘";
        }
         else if(enemyState.IsAttack == true)
        {
            enemyState.IsAttack = false;
            GameObject systems = Instantiate(System);
            systems.transform.SetParent(Content.transform);
            systems.GetComponent<Text>().text = $"<color=#ff0000>적</color>이 <color=#008000>나</color>에게 Damage{enemyState.Damage}를 입음";
        }

        
        if(Content.transform.childCount >= 10)
        { 
           Destroy(Content.transform.GetChild(0).gameObject);
        }
        
    }
}
