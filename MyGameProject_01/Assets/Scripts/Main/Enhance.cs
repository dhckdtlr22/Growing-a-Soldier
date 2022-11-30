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
        
        Player.SwordName = "��";
        bUTZip = GameObject.Find("BUTMgr").GetComponent<BUTZip>();
        
        SwordPrefb = GameObject.Find($"{Player.SwordName}").GetComponent<SwordState>();
        
        result.SetActive(false);
        needMoney.SetActive(false);
        SwordPrefb.Lv = PlayerPrefs.GetInt($"{SwordPrefb}.Lv");



    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(Player.sword + "�÷��̾�");
        //�κ��丮�� ��� �ٲ�� �ڵ����� �ٲ���
        if (GameObject.Find($"{Player.SwordName}") ==true)
        {
            SwordPrefb = GameObject.Find($"{Player.SwordName}").GetComponent<SwordState>();
           
        }


        PlayerPrefs.SetInt($"{SwordPrefb}.Lv",SwordPrefb.Lv);


        curtime += Time.deltaTime;
        SwordState.text = $"������:{SwordPrefb.Damage}\n����:{SwordPrefb.Speed}s\nũ��Ȯ��:{SwordPrefb.CriticalRange}%\nũ��������:{SwordPrefb.CriticalDamage * 100}%";
        Swordname.text = $"{Player.SwordName} +{SwordPrefb.Lv-1}�� ";
        a = (float)prizeProbability / MaxProbability;
        a *= 100;
        Pb.text = "��ȭ Ȯ��:" + a.ToString("F1") + "%";
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
                Debug.Log("��ȭ ����");
                SwordPrefb.Lv++;
                resultText.text = "<color=#008000>��ȭ ����</color>";
                BG.color = Color.green;
                //��ȭ ����
                StartCoroutine(Wait());

            }
            else
            {
                Debug.Log("��ȭ ����");
                int Fail = Random.Range(1, 100);
                BG.color = Color.red;
                if (Fail < 10)
                {
                    Debug.Log("��� �ı�");
                    //�ı�
                    resultText.text = "��� �ı�";
                    StartCoroutine(Wait());


                }
                resultText.text = "<color=#ff0000>��ȭ ����</color>";
                StartCoroutine(Wait());
                    
                //��ȭ ����
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
