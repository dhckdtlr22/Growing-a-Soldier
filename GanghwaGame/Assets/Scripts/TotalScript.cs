using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TotalScript : MonoBehaviour
{
    public List<Dictionary<string,object>> data;

    public int Damage;
    public float Speed;
    public int Hide;
    public float Cri;
    public int Cost;

    public int Lv;
    public float Range;

    public string Swordname;
    // Start is called before the first frame update
    void Start()
    {
        data = CSVReader.Read("GameResources");
    }

    // Update is called once per frame
    void Update()
    {
        Damage = int.Parse(data[Lv]["1_ATK"].ToString());
        Hide = int.Parse(data[Lv]["1_HIDE"].ToString());
        Cost = int.Parse(data[Lv]["1_COST"].ToString());
        Speed = float.Parse(data[Lv]["1_SPD"].ToString());
        Cri = float.Parse(data[Lv]["1_CRI"].ToString());
        Range = int.Parse(data[Lv]["RANGE"].ToString());
        Swordname = data[Lv]["1_SwordName"].ToString();
        
    }
}
