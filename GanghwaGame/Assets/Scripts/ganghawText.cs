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
            $"���ݷ� {total.Damage}\n���ݼӵ�{total.Speed}\n�ڵ����� ����Ȯ�� {total.Hide}%\nũ��Ƽ�� ���ݷ�{total.Cri*100}%\n���:{total.Cost}" +
            $"\n��ȭ Ȯ��:{total.Range/100f}%";
        
    }
}
