using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class MyCoin : MonoBehaviour
{
    public Text Coin;
    // Start is called before the first frame update
    void Start()
    {
        Coin = GetComponent<Text>();
       
    }

    // Update is called once per frame
    void Update()
    {
        
        Coin.text = $"³» ÄÚÀÎ: {Player.PlayerCoin}";

    }
}
