using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Enhance : MonoBehaviour
{
    public SwordState SwordPrefb;

    public GameObject EnhancePop;
    public GameObject result;
    public GameObject needMoney;
    public BUTZip bUTZip;

    public Text Cost;
    public Text Swordname;
    public Text resultText;
    public Text SwordState;
    public Text Pb;
    public Image Sword;
    public Image BG;

    public int MaxProbability;
    public int prizeProbability;
    public float curtime;
    public float cooltime = 1f;
    public float a;
    public int coinCost;
    public int ab;
    // Start is called before the first frame update
    
    void Start()
    {
        
        Player.SwordName = "검";
        bUTZip = GameObject.Find("BUTMgr").GetComponent<BUTZip>();
        
        SwordPrefb = GameObject.Find($"{Player.SwordName}").GetComponent<SwordState>();
        
        result.SetActive(false);
        needMoney.SetActive(false);
        SwordPrefb.Lv = PlayerPrefs.GetInt($"{SwordPrefb}.Lv");



    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(Player.sword + "플레이어");
        //인벤토리의 장비가 바뀌면 자동으로 바꿔줌
        if (GameObject.Find($"{Player.SwordName}") ==true)
        {
            SwordPrefb = GameObject.Find($"{Player.SwordName}").GetComponent<SwordState>();
           
        }


        PlayerPrefs.SetInt($"{SwordPrefb}.Lv",SwordPrefb.Lv);


        curtime += Time.deltaTime;
        SwordState.text = $"데미지:{SwordPrefb.Damage}\n공속:{SwordPrefb.Speed}s\n크리확률:{SwordPrefb.CriticalRange}%\n크리데미지:{SwordPrefb.CriticalDamage * 100}%";
        Swordname.text = $"{Player.SwordName} +{SwordPrefb.Lv-1}강 ";
        a = (float)prizeProbability / MaxProbability;
        a *= 100;
        Pb.text = "강화 확률:" + a.ToString("F1") + "%";
        Debug.Log(SwordPrefb.gameObject.name);
        coinCost = SwordPrefb.Lv * 20;
        


        if (SwordPrefb.Lv >= 11)
        {
            MaxProbability = SwordPrefb.Lv * 20;
        }
        else
        {
            MaxProbability = SwordPrefb.Lv * 10;
        }
       
    }
    public void PlayEnhance()
    {
        Debug.Log(Player.PlayerCoin);
        if (curtime >= cooltime && Player.PlayerCoin >= coinCost)
        {
            Player.PlayerCoin -= coinCost;
            Debug.Log(Player.PlayerCoin);
            int rand = Random.Range(0, MaxProbability);
            
            result.SetActive(true);
            if (rand < prizeProbability)
            {
                Debug.Log("강화 성공");
                SwordPrefb.Lv++;
                resultText.text = "<color=#008000>강화 성공</color>";
                BG.color = Color.green;
                //강화 성공
                StartCoroutine(Wait());

            }
            else
            {
                Debug.Log("강화 실패");
                int Fail = Random.Range(1, 100);
                BG.color = Color.red;
                if (Fail < 10)
                {
                    Debug.Log("장비 파괴");
                    //파괴
                    resultText.text = "장비 파괴";
                    StartCoroutine(Wait());


                }
                resultText.text = "<color=#ff0000>강화 실패</color>";
                StartCoroutine(Wait());
                    
                //강화 실패
            }
            curtime = 0;
           
            
            
        }
        else if (Player.PlayerCoin < 20)
        {
            needMoney.SetActive(true);
            StartCoroutine(Wait());
        }

    }
    public IEnumerator Wait()
    {
        yield return new WaitForSeconds(1f);
        result.SetActive(false);
        needMoney.SetActive(false);
        BG.color = Color.black;

    }
}
