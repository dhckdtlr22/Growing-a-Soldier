using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UHDHpBar : MonoBehaviour
{
    public Transform target;
    public RectTransform canvas;
    public RectTransform hpBar;
    public Camera mainCam;
    public GameObject hpBarPrefab;
    public GameObject hpobj;
    public float maxHp;
    public GameObject enemyMake;
    // Start is called before the first frame update
    void Start()
    {
        enemyMake = GameObject.Find("EnemyMake");
        hpobj = Instantiate(hpBarPrefab, transform.position,transform.rotation) ;
        hpobj.name = "Hpbar";
        target = gameObject.transform;
        canvas = GameObject.Find("Canvas02").GetComponent<RectTransform>();
        hpobj.transform.parent = canvas;
        hpBar = hpobj.GetComponent<RectTransform>();
        
        if(gameObject.transform.parent.name == "Boss")
        {
            Debug.Log("보스채력바");
            hpBar.localScale = new Vector3(2, 2, 2);
            hpBar.localRotation = Quaternion.Euler(0, 0, 0);
            mainCam = Camera.main;
            maxHp = transform.parent.GetComponent<EnemyState>().BossHp;
        }
        else
        {
            hpBar.localScale = new Vector3(1, 1, 1);
            hpBar.localRotation = Quaternion.Euler(0, 0, 0);
            mainCam = Camera.main;
            maxHp = transform.parent.GetComponent<EnemyState>().Hp;
        }
       
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 curPos = target.transform.position;
        Vector2 screenPoint = Camera.main.WorldToScreenPoint(curPos);
        Vector2 canvasPos;
        RectTransformUtility.ScreenPointToLocalPointInRectangle(canvas, screenPoint, mainCam, out canvasPos);
        if (hpBar != null)
        {
           
            if (gameObject.transform.parent.name == "Boss")
            {
               
                hpBar.localPosition = canvasPos + new Vector2(0, 200);
                hpBar.GetComponent<Slider>().value = transform.parent.GetComponent<EnemyState>().BossHp / maxHp;
            }
            else
            {
                hpBar.localPosition = canvasPos + new Vector2(0, 100);
                hpBar.GetComponent<Slider>().value = transform.parent.GetComponent<EnemyState>().Hp / maxHp;
            }
           
        }
        
    }
    public void DestroyHpBar()
    {
        Destroy(hpBar.gameObject);
    }
    
}
