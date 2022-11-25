using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Shop : MonoBehaviour
{
    public int NeedCoin;
    public Image Myimg;
    public Item Item;
    public TotalState total;
    public bool buy; 
    public tutorial Tutorial;
    // Start is called before the first frame update
    void Start()
    {
        total = GameObject.Find("TotalState").GetComponent<TotalState>();
        Tutorial = GameObject.Find("Tutorial").GetComponent<tutorial>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Buy()
    {
        
        if (total.MyCoin >= NeedCoin && buy == false)
        {
            if (Tutorial.Quest == 5)
            {
                Tutorial.QuestClear = true;
            }
            total.MyCoin -= NeedCoin;
            Myimg.color = Color.white;
            Item.buy = true;
            buy = true;
        }
    }
}
