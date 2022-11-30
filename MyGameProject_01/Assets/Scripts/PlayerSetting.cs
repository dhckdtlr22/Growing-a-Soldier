using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSetting : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        if (Player.PlayerHP == 0 || Player.PlayerDamage == 0)
        {
            Player.PlayerLv = 1;
            Player.PlayerDamage = 10;
            Player.PlayerHP = 200;
            Player.ExpMax = 1000;
        }
        //PlayerPrefs.DeleteAll();

    }

    // Update is called once per frame
    void Update()
    {
        PlayerPrefs.SetInt("Coin", Player.PlayerCoin);
        PlayerPrefs.SetInt("PlayerLv", Player.PlayerLv);
        PlayerPrefs.SetInt("PlayerDamgae", Player.PlayerDamage);
        PlayerPrefs.SetInt("PlayerHP", Player.PlayerHP);
        PlayerPrefs.SetInt("PlayerExp", Player.Exp);
        
    }
}
