using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Coin_Mine : MonoBehaviour
{
    private int ClickSclae = 1;
    public Text CoinText;
    // Start is called before the first frame update
    void Start()
    {
        CoinText = GameObject.Find("CoinText").GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        CoinText.text = $"³» ÄÚÀÎ: {Player.PlayerCoin}";
    }
    public void CoinClick()
    {
        

        Player.PlayerCoin += ClickSclae;
        Destroy(gameObject);
    }
}
