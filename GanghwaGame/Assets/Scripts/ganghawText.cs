using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ganghawText : MonoBehaviour
{
    public TotalScript total;
    // Start is called before the first frame update
    void Start()
    {
        total = GameObject.Find("Total").GetComponent<TotalScript>();
    }

    // Update is called once per frame
    void Update()
    {
        GetComponent<Text>().text = $"{total.Swordname} +{total.Lv}\n" +
            $"공격력 {total.Damage}\n공격속도{total.Speed}\n자동공격 성공확률 {total.Hide}%\n크리티컬 공격력{total.Cri*100}%\n비용:{total.Cost}" +
            $"\n강화 확률:{total.Range/100f}%";
        
    }
}
