using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordState : MonoBehaviour
{

    public  int Damage;
    public  float Speed;
    public  float CriticalRange;
    public  float CriticalDamage;
    public  int Lv ;

    public Enhance enhance;

    public void Start()
    {
        if(Lv <= 0)
        {
            Lv = 1;
        }
        
    }

    public void Update()
    {
        
        switch (Player.SwordName)
        {
            case "°Ë":
                Damage = Lv * 10;
                CriticalDamage = Lv * 0.05f;
                CriticalRange = Lv * 0.5f;
                if (CriticalRange >= 30)
                {
                    CriticalRange = 30;
                }
                break;
            case "ÇØ¸Ó":
                Damage = Lv * 15;
                CriticalDamage = Lv * 0.1f;
                CriticalRange = Lv * 0.5f;
                if (CriticalRange >= 30)
                {
                    CriticalRange = 30;
                }
                break;

        }
        
    }
}
