using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using SimpleJSON;
public class TotalState : MonoBehaviour
{
    //유닛 개개인 스텟관련
    //일반유닛
    public int MyCoin;//Save
    public int UnitDamage;
    public float UnitSPD;
    public int ItemDamage;
    public int UnitTotalDamage;
    //영웅 유닛
    public int EpicUnitDamage;
    public float EpicUnitSPD;
    public float EpicUnitSkill01;
    public int EpicUnitSkillDMG;
    public float EpicUnitSkill02;
    public float EpicUnitSkill03;

    public List<Dictionary<string, object>> data;

    //업그레이드 관련
    public int CastleHpMax;
    public int CastleHp;
    public int UnitUpgradeLv;//Save
    public int CastleUpgradeLv;//Save
    public int EpicUnitUpgradeLv;//Save

    //유닛 생성 수 관련
    public int UnitNum;//Save
    public int UnitNumMax = 15;
    public int EpicMax = 3;
    public int EpicUnitNum = 0;//Save

    //레벨업 관련
    public int PlayerLv;//Save
    public int PlayerExp;//Save
    public int PlayerExpMax;//Save
    public int LvDamage;//Save

    //유닛 업그레이드 비용 관련
    public int CastleUpgradeCost;
    public int UnitUpgradeCost;
    public int EpicUnitUpgardeCost;

    //생성관련
    public int UnitInsCost;
    public int EpicUnitInsCost;

    public int Stage;//Save
    //드랍한 코인 & 경험치 저장
    public int CoinCheck;
    public int ExpCheck;

    public Text MyCoinText;
    public Text CastleCostText;
    public Text UnitCostText;
    public Text UnitInsCostText;
    public Text EpicUnitInsCostText;
    public Text EpicUnitCostText;
    public Text CastleHPText;
    public Text LvText;

    public Slider Hpbar;
    public Slider ExpBar;
    
    public EnemyState enemyState;
    public EnemyMaker enemyMaker;
    public UnitUpgrade Up;

    public InputField hide;
    public Animator LevelUp;

    public List<AudioSource> ShootAudio;
    public Slider Volume;

    public Slider DieVolume;

    public Inventori inventori;

    public GameObject CamChage;
    public GameObject Cam;
    public void Awake()
    {
        Screen.orientation = ScreenOrientation.LandscapeLeft;
        //Importdata();
    }
    // Start is called before the first frame update
    void Start()
    {
        inventori = GameObject.Find("ItemMgr").GetComponent<Inventori>();
        Volume.value = PlayerPrefs.GetFloat("ShootVol");
        Volume.value = 0.15f;
        data = CSVReader.Read("Character");
        enemyMaker = GameObject.Find("EnemyMake").GetComponent<EnemyMaker>();
        CastleHp = int.Parse(data[CastleUpgradeLv]["CastleHp"].ToString());
        CastleHpMax = CastleHp;
    }

    // Update is called once per frame
    void Update()
    {
        //JSONdate();

        UnitTotalDamage = UnitDamage + LvDamage +EpicUnitSkillDMG + ItemDamage;
        CastleUpgradeCost = int.Parse(data[CastleUpgradeLv]["CastleCost"].ToString());
        UnitDamage = int.Parse(data[UnitUpgradeLv]["UnitATK"].ToString());
        UnitInsCost = int.Parse(data[UnitNum]["UnitInsCost"].ToString());
        UnitSPD = float.Parse(data[UnitUpgradeLv]["UnitSPD"].ToString());
        
        EpicUnitInsCost = int.Parse(data[EpicUnitNum]["EPICUnitInsCost"].ToString());
        UnitUpgradeCost = int.Parse(data[UnitUpgradeLv]["UnitCost"].ToString());
        EpicUnitUpgardeCost = int.Parse(data[EpicUnitUpgradeLv]["EPICUnitCost"].ToString());
        EpicUnitDamage = int.Parse(data[EpicUnitUpgradeLv]["EPICUnitATK"].ToString());
        EpicUnitSPD = float.Parse(data[EpicUnitUpgradeLv]["EPICUnitSPD"].ToString());
        EpicUnitSkill01 = float.Parse(data[EpicUnitUpgradeLv]["EPICUnitSkill1"].ToString());
        EpicUnitSkill02 = float.Parse(data[EpicUnitUpgradeLv]["EPICUnitSkill2"].ToString());
        EpicUnitSkill03 = float.Parse(data[EpicUnitUpgradeLv]["EPICUnitSkill3"].ToString());
        CastleHPText.text = $"{string.Format("{0:#,###}", CastleHp)}";
        LvText.text = $"LV:{PlayerLv}";
        Hpbar.value = (float)CastleHp / CastleHpMax;
        ExpBar.value = (float)PlayerExp / PlayerExpMax;

        if(CastleHp > CastleHpMax)
        {
            CastleHp = CastleHpMax;
        }

        if (MyCoin > 0 )
        {
            MyCoinText.text = $"{string.Format("{0:#,###}", MyCoin)}";
        }
        else
        {
            MyCoinText.text = $"0";
        }
        if(EpicUnitUpgradeLv == 19){EpicUnitCostText.text = $"비용:MAX";}else{ EpicUnitCostText.text = $"비용:{ string.Format("{0:#,###}", EpicUnitUpgardeCost)}"; }
        if (UnitUpgradeLv == 49) { UnitCostText.text = $"비용:MAX"; } else { UnitCostText.text = $"비용:{ string.Format("{0:#,###}", UnitUpgradeCost)}"; }
        if (UnitNum == UnitNumMax) { UnitInsCostText.text = $"비용:MAX"; } else { UnitInsCostText.text = $"비용:{ string.Format("{0:#,###}", UnitInsCost)}"; }
        if (CastleUpgradeLv == 49) { CastleCostText.text = $"비용:MAX"; } else { CastleCostText.text = $"비용:{ string.Format("{0:#,###}", CastleUpgradeCost)}"; }
        if (EpicUnitNum == 3) { EpicUnitInsCostText.text = $"비용:MAX"; } else { EpicUnitInsCostText.text = $"비용:{ string.Format("{0:#,###}", EpicUnitInsCost)}"; }
        if(PlayerExp >= PlayerExpMax)
        {
            LvDamage += (int)(UnitDamage * 0.1f);
            PlayerExp = 0;
            PlayerExpMax = (int)(PlayerExpMax* 1.3f);
            PlayerLv++;
            LevelUp.SetTrigger("LevelUp");
        }
        if(hide.textComponent.text =="asd123")
        {
            MyCoin = 1000000000;
            
        }
        ShootVolume();
        
        if(enemyMaker.IsBattle == true)
        {
            CamChage.SetActive(true);
        }
        else if(enemyMaker.IsBattle == false)
        {
            CamChage.SetActive(false);
            Cam.SetActive(false);
        }
    }
    public void StageUp()
    {
        Stage++;
        
        if (enemyMaker.CountMax < 2000)
        {
            enemyMaker.CountMax  = 10 + Stage;
        }
    }
    public void JSONdate()
    {
        var PlayerState = new JSONObject();

        PlayerState["MyCoin"] = MyCoin;
        PlayerState["UnitUpgradeLv"] = UnitUpgradeLv;
        PlayerState["CastleUpgradeLv"] = CastleUpgradeLv;
        PlayerState["EpicUnitUpgradeLv"] = EpicUnitUpgradeLv;
        PlayerState["UnitNum"] = UnitNum;
        PlayerState["EpicUnitNum"] = EpicUnitNum;
        PlayerState["PlayerLv"] = PlayerLv;
        PlayerState["PlayerExp"] = PlayerExp;
        PlayerState["PlayerExpMax"] = PlayerExpMax;
        PlayerState["LvDamage"] = LvDamage;
        PlayerState["Stage"] = Stage;

        PlayerPrefs.SetString("PlayerState", PlayerState.ToString());
        
    }
    public void Importdata()
    {
        string data = PlayerPrefs.GetString("PlayerState");

        var PlayerState = JSON.Parse(data);

        MyCoin = int.Parse(PlayerState["MyCoin"]);
        UnitUpgradeLv = int.Parse(PlayerState["UnitUpgradeLv"]);
        CastleUpgradeLv = int.Parse(PlayerState["CastleUpgradeLv"]);
        EpicUnitUpgradeLv = int.Parse(PlayerState["EpicUnitUpgradeLv"]);
        UnitNum = int.Parse(PlayerState["UnitNum"]);
        EpicUnitNum = int.Parse(PlayerState["EpicUnitNum"]);
        PlayerLv = int.Parse(PlayerState["PlayerLv"]);
        PlayerExp = int.Parse(PlayerState["PlayerExp"]);
        PlayerExpMax = int.Parse(PlayerState["PlayerExpMax"]);
        LvDamage = int.Parse(PlayerState["LvDamage"]);
        Stage = int.Parse(PlayerState["Stage"]);
  


    }
    public void ShootVolume()
    {
        
        for (int i = 0; i < ShootAudio.Count; i++)
        {
            ShootAudio[i].volume = Volume.value;
        }
        PlayerPrefs.SetFloat("ShootAudio", Volume.value);
    }
   
}
