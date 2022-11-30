using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Player : MonoBehaviour
{
    public static Player instance;

    public static int PlayerDamage;
    public static int PlayerHP;
    public static int PlayerCoin;
    public static int PlayerLv;
    public static int Exp;
    public static int ExpMax;
    public static string SwordName;
    public static Image Swordimage;
    public static SwordState sword;
    // Start is called before the first frame update
    void Awake()
    {
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);

        DontDestroyOnLoad(gameObject);
        
    }
    private void Start()
    {

        Debug.Log(SwordName+"12313");
        Swordimage = GameObject.Find("SwordImage").GetComponent<Image>();
        sword = GameObject.Find($"{SwordName}").GetComponent<SwordState>();
        
    }

    // Update is called once per frame
    void Update()
    {
        
        
    }
}
