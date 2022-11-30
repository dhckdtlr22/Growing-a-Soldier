using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class CoinMove_Mine : MonoBehaviour
{
    public GameObject Coin;
    public GameObject CoinMaker;
    public float curtime;
    public float cooltime;
    // Start is called before the first frame update
    void Start()
    {
        CoinMaker = GameObject.Find("CoinMaker");
    }

    // Update is called once per frame
    void Update()
    {
        curtime += Time.deltaTime;
        if(curtime >= cooltime)
        {
            int randX = Random.Range(-440, 441);
            int randY = Random.Range(-980, 800);

            
            GameObject coin = Instantiate(Coin);
            coin.name = "Coin";
            coin.transform.SetParent(CoinMaker.transform);
            coin.transform.localPosition = new Vector2(randX, randY);
            curtime = 0;
            Destroy(coin, 1f);
        }
    }
}
