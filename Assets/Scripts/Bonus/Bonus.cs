using UnityEngine;
using System.Collections;


public class Bonus : MonoBehaviour {

    public GameObject pref_explosion;

    public enum E_BONUS
    {
        PER_SEC_MULTIPLIER,
        PER_CLICK_MULTIPLIER,
        STUN,
        SIZE
    }
    E_BONUS bonusID;
            
    static public class BonusInfo
    {
       static public float stunForSec = 1;
       static public int perSecMultiplier = 2;
       static public int perClickMultiplier = 2;
    }

    public Sprite[] spr_gift;

    Timer timer_destroy;

    public GameObject pref_starSpawner;






    void Awake()
	{
        SetRandomSprite();
        bonusID = (E_BONUS)Random.Range(0, (int)E_BONUS.SIZE);
    }
	
	void Start () 
	{	
	}

	void Update () 
	{
        HandleMovement();
    }

    void OnMouseDown()
    {
        ApplyBonus();
        Instantiate(pref_explosion, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }





    void HandleDestroyTimer()
    {
        timer_destroy.Tick(Time.deltaTime);
        if (timer_destroy.IsFinished())
            Destroy(gameObject);
    }

    void SetRandomSprite()
    {
        GetComponent<SpriteRenderer>().sprite = spr_gift[Random.Range(0, spr_gift.Length)];
    }

    void ApplyBonus()
    {
        switch(bonusID)
        {
            case E_BONUS.STUN:
                {
                    if (SlothStats.refrence.state == SlothStats.E_STATE.WALKING)
                        OnStunBonus();
                    else
                        OnPerClickBonus();
                } break;
            case E_BONUS.PER_CLICK_MULTIPLIER:
                {
                    OnPerClickBonus();
                } break;
            case E_BONUS.PER_SEC_MULTIPLIER:
                {
                    OnPerSecBonus();
                } break;
        }
        GameManager.refrence.SetBonusTimer(10f);
    }



    
    void OnStunBonus()
    {
        SlothMovementController.refrence.SetStunnedTimer();
        SlothStats.refrence.SetState(SlothStats.E_STATE.STUNNED);
        SpawnStarSpawner();
        BonusText.refrence.SetText("Sloth stunned for " + BonusInfo.stunForSec + " seconds");
    }
    void OnPerClickBonus()
    {
        GameManager.refrence.weaponInfo.curDamagePerClick = GameManager.refrence.weaponInfo.baseDamagePerClick * (UpgradeSlotGUI.UpgradeInfos.lvlsDictionary[UpgradeSlotGUI.E_UPGRADE.BONUS_PER_CLICK] + 1);
        CoinInfoGUI.refrence.ref_perClick.color = new Color(0, 1, 0);
        BonusText.refrence.SetText(GameManager.refrence.weaponInfo.curDamagePerClick + " per click for 10 seconds");
    }
    void OnPerSecBonus()
    {
        GameManager.refrence.weaponInfo.curDamagePerSec = GameManager.refrence.weaponInfo.baseDamagePerSec * (UpgradeSlotGUI.UpgradeInfos.lvlsDictionary[UpgradeSlotGUI.E_UPGRADE.BONUS_PER_SEC] + 1);
        CoinInfoGUI.refrence.ref_perSecond.color = new Color(0, 1, 0);
        BonusText.refrence.SetText(GameManager.refrence.weaponInfo.curDamagePerSec + " per click for 10 seconds");
    }




    void HandleMovement()
    {
        transform.Translate(Vector3.down * Time.deltaTime);
    }

    void SpawnStarSpawner()
    {
        Vector2 spawnPos = new Vector2(SlothStats.refrence.transform.position.x + 1f, SlothStats.refrence.transform.position.y + 1f);
        Instantiate(pref_starSpawner, spawnPos, Quaternion.identity);
    }




}
