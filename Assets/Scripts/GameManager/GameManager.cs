using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class GameManager : MonoBehaviour {

    static public GameManager refrence;

    [HideInInspector]
    public bool gameEnded = false;

    public class LevelInfo
    {
        public int numOfLevels = 30;
        public int curLevel = 0;

        public void IncreaseLevel() {  curLevel++; }
    }
    public LevelInfo levelInfo;

    public class WeaponInfo
    {       
        public int baseDamagePerClick = 1;
        public int curDamagePerClick = 1;

        public int baseDamagePerSec = 0;
        public int curDamagePerSec = 0;

        public int GetCoinsPerClick() { return curDamagePerClick * 1; }
        public int GetCoinsPerSec() { return curDamagePerSec * 1; }

        public void ResetToBase() { curDamagePerClick = baseDamagePerClick; curDamagePerSec = baseDamagePerSec; }
    }
    public WeaponInfo weaponInfo;
    Timer timer_dmgPerClick;
    Timer timer_bonusDuration;

    public class CoinsInfo
    {
        public int coinsAmount = 0;

        public void AddCoins(int _amount) { coinsAmount += _amount; }
        public void ReduceCoins(int _amount) { coinsAmount -= _amount; }
    }
    public CoinsInfo coinsInfo;


    public RectTransform slothSpawPoint;

    GameObject ref_sloth;

    Timer timer_stayOnFinish;


    void Awake()
	{
        Screen.orientation = ScreenOrientation.LandscapeLeft;
        refrence = this;
        
        coinsInfo = new CoinsInfo();
        levelInfo = new LevelInfo();
        weaponInfo = new WeaponInfo();
    }
	
	void Start () 
	{
        ref_sloth = SlothStats.refrence.gameObject;
        timer_dmgPerClick = new Timer(1f);
        timer_stayOnFinish = new Timer(1.5f);
    }

	void Update () 
	{
        HandleDamagePerSec();
        HandleBonusDuration();
        HandleSlothReachedApple();
    }





    public void AdvanceToNextLevel()
    {
        levelInfo.IncreaseLevel();
        if (levelInfo.curLevel <= levelInfo.numOfLevels && !gameEnded)
        {
            SlothStats.refrence.health.SetHealth(SlothStats.refrence.health.GetHealthForLevelX(GameManager.refrence.levelInfo.curLevel));
            ResetSloth();
        }
        else
        {            
            gameEnded = true;
            AudioManager.refrence.isMusicMuted = false;
            AudioManager.refrence.UpdateMusicVolume();
            
        }
    }
    public void ResetSloth()
    {
        SlothStats.refrence.SetState(SlothStats.E_STATE.FALLING);
        SlothWorldInteraction.refrence.SetClickabilityState(false);        
        SlothStats.refrence.health.ResetHealth();
        ref_sloth.transform.position = slothSpawPoint.position;
    }

    private void HandleDamagePerSec()
    {
        if (SlothStats.refrence.state == SlothStats.E_STATE.WALKING)
        {
            timer_dmgPerClick.Tick(Time.deltaTime);
            if (timer_dmgPerClick.IsFinished())
            {
                SlothStats.refrence.health.ReduceHealthBy(weaponInfo.curDamagePerSec);
                coinsInfo.AddCoins(weaponInfo.GetCoinsPerSec());
                timer_dmgPerClick.Reset();
            }
        }
        else
        {
            timer_dmgPerClick.Reset();
        }
    }

    void HandleSlothReachedApple()
    {
        if (SlothStats.refrence.state == SlothStats.E_STATE.FINISHED)
        {
            timer_stayOnFinish.Tick(Time.deltaTime);
            if(timer_stayOnFinish.IsFinished())
            {
                ResetSloth();
                timer_stayOnFinish.Reset();
            }
            
        }
    }

    private void HandleBonusDuration()
    {
        if (timer_bonusDuration != null)
        {
            timer_bonusDuration.Tick(Time.deltaTime);
            if (timer_bonusDuration.IsFinished())
            {
                weaponInfo.ResetToBase();
                CoinInfoGUI.refrence.ResetTextColor();
                timer_bonusDuration = null;
            }
        }
    }
    public void SetBonusTimer(float _sec)
    {
        timer_bonusDuration = new Timer(_sec);
    }




}
