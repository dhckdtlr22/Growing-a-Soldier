using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class EnemyMaker : MonoBehaviour
{
    public GameObject BattalPop;
    public GameObject EnemyPrefab;
    public GameObject BossPrefab;

    public Text EnemyCountText;
    public Text KillText;
    public Text Result;
    public Text ExpText;
    public Text CoinText;
    public Slider KillSlider;

    public float curtime;
    public float cooltime;

    public bool IsBattle;
    public bool IsClear;
    public bool Resetting;

    public int MonsterCount;
    public int CountMax;
    public int KillCount;
    

    public TotalState totalState;
    public AttackZone attackZone;
    public EnemyState enemyState;
    
    public GameObject AtiveBut;
    // Start is called before the first frame update
    private void Start()
    {
        totalState = GameObject.Find("TotalState").GetComponent<TotalState>();
        attackZone = GameObject.Find("AttackZone").GetComponent<AttackZone>();
        
    }

    // Update is called once per frame
    void Update()
    {

        if (CountMax < 2000)
        {
            CountMax = 10 + totalState.Stage;
        }
        if (IsBattle ==true)
        {
            AtiveBut.SetActive(true);
            IsClear = false;
            curtime += Time.deltaTime;
            if(totalState.Stage%5 == 0)
            {
                
                if (curtime > cooltime && MonsterCount < CountMax && attackZone.Enemy.Count < 100)
                {
                    if(MonsterCount == CountMax -1)
                    {
                        
                        GameObject Enemy = Instantiate(BossPrefab);
                        Enemy.name = "Boss";
                        Enemy.transform.position = new Vector3(transform.position.x,3.4f, transform.position.z);
                        Enemy.GetComponent<EnemyState>().BossHp = (int)(100 * (totalState.Stage / 5 * 1.5f));
                        Enemy.GetComponent<EnemyState>().BossDamage = (int)(200 * (totalState.Stage / 5 * 1.2f));
                        Enemy.GetComponent<EnemyState>().BossDropCoin = (int)(50 * (totalState.Stage / 5 * 1.5f));
                        Enemy.GetComponent<EnemyState>().BossDropExp = (int)(100 * (totalState.Stage / 5 * 1.5f));
                        curtime = 0;
                        MonsterCount++;
                    }
                    else
                    {
                        
                        int rand = Random.Range(-15, 14);
                        GameObject Enemy = Instantiate(EnemyPrefab);
                        Enemy.name = "Enemy";
                        float a = 50 * (totalState.Stage / 5 * 1.5f);
                        Enemy.GetComponent<EnemyState>().Damage = (int)a;
                        float b = 10 * (totalState.Stage / 5 * 1.2f);
                        Enemy.GetComponent<EnemyState>().Hp = (int)b;
                        float c = 2 * (totalState.Stage / 5 * 1.5f);
                        Enemy.GetComponent<EnemyState>().DropCoin = (int)c;
                        float d = 10 * (totalState.Stage / 5 * 1.1f);
                        Enemy.GetComponent<EnemyState>().DropExp = (int)d;
                        if (cooltime > 0.1)
                        {
                            cooltime = 1 - (totalState.Stage / 5 * 0.05f);
                        }
                        if (Enemy.GetComponent<EnemyState>().Speed < 3)
                        {
                            Enemy.GetComponent<EnemyState>().Speed = 1 + (totalState.Stage / 5 * 0.05f);
                            if (Enemy.GetComponent<EnemyState>().Speed > 3)
                            {
                                Enemy.GetComponent<EnemyState>().Speed = 3;
                            }
                        }
                        
                        Enemy.transform.position = new Vector3(transform.position.x + rand, transform.position.y, transform.position.z);
                        curtime = 0;
                        MonsterCount++;
                    }
                }
            }
            else
            {
                if (curtime > cooltime && MonsterCount < CountMax)
                {
                    int rand = Random.Range(-15, 14);
                    GameObject Enemy = Instantiate(EnemyPrefab);
                    Enemy.name = "Enemy";
                    
                        
                        float a =10 + 50 * (int)(totalState.Stage / 5 * 1.5f);
                        Enemy.GetComponent<EnemyState>().Hp = (int)a;
                        float b = 50+10 * (int)(totalState.Stage / 5 * 1.2f);
                        Enemy.GetComponent<EnemyState>().Damage = (int)b;
                        float c =2+ 2 * (int)(totalState.Stage / 5 * 1.5f);
                        Enemy.GetComponent<EnemyState>().DropCoin = (int)c;
                        float d =10+ 10 * (int)(totalState.Stage / 5 * 1.1f);
                        Enemy.GetComponent<EnemyState>().DropExp = (int)d;
                        if (cooltime > 0.1)
                        {
                            cooltime = 1 - (int)(totalState.Stage / 5 * 0.05f);
                        }
                        if (Enemy.GetComponent<EnemyState>().Speed < 3)
                        {
                            Enemy.GetComponent<EnemyState>().Speed = 1 + (int)(totalState.Stage / 5 * 0.05f);
                            if (Enemy.GetComponent<EnemyState>().Speed > 3)
                            {
                                Enemy.GetComponent<EnemyState>().Speed = 3;
                             }
                        }
                    
                    Enemy.transform.position = new Vector3(transform.position.x + rand, transform.position.y, transform.position.z);
                    curtime = 0;
                    MonsterCount++;
                }
            }
            
            EnemyCountText.text = $"{KillCount}/{CountMax}";
            KillSlider.value = (float)KillCount / CountMax;
        }
        else if(IsBattle == false)
        {
            AtiveBut.SetActive(false);
            AtiveBut.GetComponent<ItemAtive>().Curtime = 0;
            EnemyCountText.text = $"Stage {totalState.Stage}";
            KillSlider.value = 0;
            if(IsClear == false)
            {
                if (GameObject.Find("Enemy") || GameObject.Find("Boss") || GameObject.Find("Hpbar"))
                {

                    Destroy(GameObject.Find("Enemy"));
                    Destroy(GameObject.Find("Boss"));
                    Destroy(GameObject.Find("Hpbar"));
                }
                else
                {
                    IsClear = true;
                }
            }
            
            
            
            if (attackZone.EnemyIn == true)
            {
                attackZone.Enemy.RemoveAt(0);
            }
            
        }
        
        if (KillCount == CountMax)
        {
            totalState.CastleHp = int.Parse(totalState.data[totalState.CastleUpgradeLv]["CastleHp"].ToString());
            IsBattle = false;
            totalState.StageUp();
            curtime = 0;
            KillText.text = $"Ã³Ä¡ :{KillCount}¸¶¸®";
            
            CoinText.text = $"È¹µæ ÄÚÀÎ:{string.Format("{0:#,###}", totalState.CoinCheck)}";
            ExpText.text = $"È¹µæ °æÇèÄ¡:{string.Format("{0:#,###}", totalState.ExpCheck)}";
            totalState.ExpCheck = 0;
            totalState.CoinCheck = 0;
            KillCount = 0;
            MonsterCount = 0;
            BattalPop.SetActive(true);
            Result.text = "½Â¸®";
        }
        
        if(totalState.CastleHp <= 0)
        {
            totalState.CastleHp = int.Parse(totalState.data[totalState.CastleUpgradeLv]["CastleHp"].ToString());
            KillText.text = $"Ã³Ä¡ :{KillCount}¸¶¸®";
            IsBattle = false;
            BattalPop.SetActive(true);
            CoinText.text = $"È¹µæ ÄÚÀÎ:{totalState.CoinCheck}";
            ExpText.text = $"È¹µæ °æÇèÄ¡:{totalState.ExpCheck}";
            totalState.ExpCheck = 0;
            totalState.CoinCheck = 0;
            curtime = 0;
            KillCount = 0;
            MonsterCount = 0;
            Result.text = "ÆÐ¹è";
        }
        if(Resetting == true)
        {
            Restarted();
        }
    }
    public void Restarted()
    {
        
        if (IsClear == true)
        {
            IsBattle = true;
            Resetting = false;
            MonsterCount = 0;
            Time.timeScale = 1;
        }
        else
        {
            Resetting = true; 
            IsClear = false;
            IsBattle = false;

        }


    }

    public void MainReset()
    {

    }

}
