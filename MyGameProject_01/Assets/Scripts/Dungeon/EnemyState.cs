using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class EnemyState : MonoBehaviour
{
   
    public Text EnemyStateText;
    public Image Playerimage;
    public Text resultText;
    public Image resultimage;
    public int Damage;
    public int HP;
    public float Speed;
    public float CriDG;
    public int Exp;
    public float curtime;
    public bool IsAttack = false;
    void Start()
    {
        Playerimage = GameObject.Find("Playerimage").GetComponent<Image>();
        
        HP = Random.Range(70, 250);
        Damage = Random.Range(10, 20);
        Speed = Random.Range(0.7f, 1.3f);
        CriDG = Random.Range(1.3f, 2f);
        Exp = HP;
        Debug.Log(Exp);
    }

    // Update is called once per frame
    void Update()
    {//�÷��̾� ������ ����� ���ȿ����� ����
        curtime += Time.deltaTime;
        EnemyStateText.text = $"ü��:{HP}\n���ݷ�:{Damage}\n����:{Speed.ToString("F1")}";
        if(curtime >= Speed)
        {
            IsAttack = true;
            Player.PlayerHP -= Damage;
            
            colorC();
            Debug.Log("d");
            if (Player.PlayerHP <= 0)
            {
                Playerimage.color = Color.black;
                Player.PlayerHP = 0;
                resultimage.gameObject.SetActive(true);
                Debug.Log("111111");
                Time.timeScale = 0;
                Debug.Log("���� �̱�!!!!");
                resultText.text = "<color=#ff0000>�й�</color>";
            }
            curtime = 0;
            
        }
    }
    void colorC()
    {
        Playerimage.color = Color.red;
        Color color = Playerimage.color;
        color.a = 1f;
        Playerimage.color = color;
        StartCoroutine(Wait());

    }
    IEnumerator Wait()
    {
        yield return new WaitForSeconds(0.3f);

        Color color = Playerimage.color;
        color.a = 0.5f;
        Playerimage.color = color;
        Playerimage.color = Color.black;
    }
}
