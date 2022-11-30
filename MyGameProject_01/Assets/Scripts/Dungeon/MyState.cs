using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class MyState : MonoBehaviour
{
    public Text myState;
    public Text CoinText;
    public Text resultText;
    public Image resultimage;
    public Image Myimage;
   

    public float curtime;
    public int ttD;
    

    public EnemyState enemyState;
    public Image Enemyimage;

    public bool IsAttack = false;
    // Start is called before the first frame update
    void Start()
    {
        CoinText = GameObject.Find("Coin").GetComponent<Text>();
        Enemyimage = GameObject.Find("Enemyimage").GetComponent<Image>();
        enemyState = GameObject.Find("System").GetComponent<EnemyState>();
        myState = GameObject.Find("MyState").GetComponent<Text>();
        resultimage.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        CoinText.text = $"내 코인: {Player.PlayerCoin}";
        curtime += Time.deltaTime;
        myState.text =  $"레벨:{Player.PlayerLv}\n체력:{Player.PlayerHP}\n데미지:{Player.PlayerDamage + Player.sword.Damage}\n공속:{Player.sword.Speed}s";
        Myimage.sprite = Player.Swordimage.sprite;
        if(curtime >= Player.sword.Speed)
        {
            IsAttack = true;
            ttD = Player.PlayerDamage + Player.sword.Damage;
            enemyState.HP -= ttD;
            colorC();
            //맞을 때마다 색깔이 변함
            if(enemyState.HP <= 0)
            {
                enemyState.HP = 0;  
                Enemyimage.color = Color.black;
                Player.Exp += enemyState.Exp;
                Player.PlayerCoin += enemyState.Exp /10 ;
                Time.timeScale = 0;
                Debug.Log("내가 이김");
                
                resultimage.gameObject.SetActive(true);
                resultText.text = "<color=#008000>승리</color>";
               
            }
            curtime = 0;
            
        }
    }

    void colorC()
    {
        Enemyimage.color = Color.red;
        Color color = Enemyimage.color;
        color.a = 1f;
        Enemyimage.color = color;
        StartCoroutine(Wait());
       
    }
    IEnumerator Wait()
    {
        yield return new WaitForSeconds(0.3f);

        Color color = Enemyimage.color;
        color.a = 0.5f;
        Enemyimage.color = color;
        Enemyimage.color = Color.black;
    }
}
