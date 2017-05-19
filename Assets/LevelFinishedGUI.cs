using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class LevelFinishedGUI : MonoBehaviour {

    static public LevelFinishedGUI refrence;

    public Text txt_lvlCompleted;
    public Text txt_lvlsLeft;
    public Text txt_bonusCoins;

    public Button btn_playAdd;
    public Button btn_close;

    public GameObject content;

    void Awake()
	{
        refrence = this;
    }
	
	void Start () 
	{
        SetButtonListeners();
    }

	void Update () 
	{	
	}


    void SetButtonListeners()
    {
        //Exit button
        btn_close.onClick.AddListener(delegate
        {
            content.SetActive(false);
            GameManager.refrence.AdvanceToNextLevel();
        });
        //Watch addbutton
        btn_playAdd.onClick.AddListener(delegate
        {
            if (Application.internetReachability != NetworkReachability.NotReachable)
                AddManager.refrence.ShowRewardedAd(AddManager.E_REWARD.END_LVL_COINS);
            else
                BonusText.refrence.SetText("YOU MUST BE CONNECTED TO A NETWORK");
        });
    }

    public void SetActive(bool _state)
    {
        content.SetActive(_state);
        if (_state == true)
            UpdateTextGUI();
    }

    void UpdateTextGUI()
    {
        GameManager.LevelInfo lvlInfo = GameManager.refrence.levelInfo;
        txt_lvlCompleted.text = "LEVEL " + lvlInfo.curLevel + " COMPLETED";
        txt_lvlsLeft.text = (lvlInfo.numOfLevels - lvlInfo.curLevel) + " LEVELS LEFT";

        GameManager.WeaponInfo weaponInfo = GameManager.refrence.weaponInfo;
        txt_bonusCoins.text = "GET " + Global.GetSeparatedNumber(GetRewardCoinsAmount()) + " BONUS COINS";
    }

    public int GetRewardCoinsAmount()
    {
        return GameManager.refrence.weaponInfo.baseDamagePerClick * 100 + GameManager.refrence.weaponInfo.baseDamagePerSec * 70;
    }





}
