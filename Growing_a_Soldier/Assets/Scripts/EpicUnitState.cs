using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EpicUnitState : MonoBehaviour
{
    public AttackZone attackZone;
    public EnemyState enemyState;
    public EnemyMaker enemyMaker;
    public TotalState totalState;

    public Animator anime;

    public float Attackcur;
    public float Attackcool;
    public GameObject MezzlePrefab;
    public Transform MPos;

    public GameObject Effect;
    public AudioSource shootAudio;
    
    // Start is called before the first frame update
    void Start()
    {
        anime = GetComponentInChildren<Animator>();
        enemyMaker = GameObject.Find("EnemyMake").GetComponent<EnemyMaker>();
        attackZone = GameObject.Find("AttackZone").GetComponent<AttackZone>();
        totalState = GameObject.Find("TotalState").GetComponent<TotalState>();
    }

    // Update is called once per frame
    void Update()
    {
        Attackcool = totalState.EpicUnitSPD;
        if(enemyMaker.IsBattle == true)
        {
            if (attackZone.EnemyIn == true && attackZone.Enemy.Count >= 1)
            {
                Debug.Log(attackZone.Enemy);
                transform.LookAt(attackZone.Enemy[0].transform);
                Vector3 dir = transform.localRotation.eulerAngles;
                dir.x = 0;
                transform.localRotation = Quaternion.Euler(dir);
                enemyState = attackZone.Enemy[0].GetComponent<EnemyState>();
                Attackcur += Time.deltaTime;
                anime.SetTrigger("Attack");
                if (Attackcur > Attackcool)
                {
                    shootAudio.Play();
                    Instantiate(MezzlePrefab, MPos.transform.position, MPos.transform.rotation);
                    Instantiate(Effect, enemyState.gameObject.transform.position, Quaternion.LookRotation(-enemyState.transform.position.normalized));
                    if (enemyState.gameObject.name == "Enemy")
                    {
                        enemyState.Hp -= totalState.EpicUnitDamage;
                        Attackcur = 0;
                        if (enemyState.Hp <= 0)
                        {
                            enemyState.Die();
                        }
                    }
                    else if (enemyState.gameObject.name == "Boss")
                    {
                        
                        enemyState.BossHp -= totalState.EpicUnitDamage;
                    }
                }
            }
            
        }
    }
}
