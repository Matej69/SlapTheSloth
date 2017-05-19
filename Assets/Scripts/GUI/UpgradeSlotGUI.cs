using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;


public class UpgradeSlotGUI : MonoBehaviour {

    public enum E_UPGRADE
    {
        PER_CLICK,
        PER_SEC,
        BONUS_STUN,
        BONUS_PER_CLICK,
        BONUS_PER_SEC,
        SIZE
    }
    public E_UPGRADE upgradeType;





    static public class UpgradeInfos
    {
        static private int maxLvl = 30;
        static private int perClickLvl = 1;
        static private int perSecLvl = 1;
        static private int stunForSecLvl = 1;
        static private int perSecBonusLvl = 1;
        static private int perClickBonusLvl = 1;

        static public Dictionary<E_UPGRADE, int> lvlsDictionary = new Dictionary<E_UPGRADE, int>()
        {
            { E_UPGRADE.PER_CLICK, perClickLvl },
            { E_UPGRADE.PER_SEC, perSecLvl },
            { E_UPGRADE.BONUS_STUN, stunForSecLvl },
            { E_UPGRADE.BONUS_PER_CLICK, perClickBonusLvl },
            { E_UPGRADE.BONUS_PER_SEC, perSecBonusLvl }
        };

        static public int GetUpgradeCost(E_UPGRADE _id)
        {
            if(_id == E_UPGRADE.PER_CLICK) { int[] costs = new int[]{0,250,600,1300,2800,5000,9000,15000,25000,40000,78000,110000,200000,400000,650000, 950000,1300000, 1750000, 2200000, 2600000, 3000000, 3400000, 3800000, 4400000, 4900000, 5500000, 6300000, 7000000, 7800000, 8500000, 10000000 }; return costs[lvlsDictionary[_id]]; }
            if(_id == E_UPGRADE.PER_SEC) { int[] costs = new int[]{0,250,600,1300,2800,5000,9000,15000,25000,40000,78000,110000,200000,400000,650000, 950000,1300000, 1750000, 2200000, 2600000, 3000000, 3400000, 3800000, 4400000, 4900000, 5500000, 6300000, 7000000, 7800000, 8500000, 10000000}; return costs[lvlsDictionary[_id]]; }
            if (_id == E_UPGRADE.BONUS_STUN) { int[] costs = new int[] { 0, 50, 150, 300, 500, 800, 1400, 2200, 3300, 5100, 7500, 10000, 13000, 17500, 220000, 275000, 320000, 390000, 460000, 520000, 600000, 700000, 830000, 930000, 1200000, 1500000, 200000, 270000, 350000, 500000, 750000, 1000000 }; return costs[lvlsDictionary[_id]]; }
            if (_id == E_UPGRADE.BONUS_PER_CLICK) { int[] costs = new int[] { 0, 50, 150, 300, 500, 800, 1400, 2200, 3300, 5100, 7500, 10000, 13000, 17500, 220000, 275000, 320000, 390000, 460000, 520000, 600000, 700000, 830000, 930000, 1200000, 1500000, 200000, 270000, 350000, 500000, 750000, 1000000 }; return costs[lvlsDictionary[_id]]; }
            if (_id == E_UPGRADE.BONUS_PER_SEC) { int[] costs = new int[] { 0, 50, 150, 300, 500, 800, 1400, 2200, 3300, 5100, 7500, 10000, 13000, 17500, 220000, 275000, 320000, 390000, 460000, 520000, 600000, 700000, 830000, 930000, 1200000, 1500000, 200000, 270000, 350000, 500000, 750000, 1000000 }; return costs[lvlsDictionary[_id]]; }
            return 0;
        }

        static public int GetNextUpgradeValue(E_UPGRADE _id)
        {
            if (_id == E_UPGRADE.PER_CLICK) { int[] upgradeValues = new int[] { 0,0, 2, 5, 9, 16, 21, 27, 36, 50, 70, 100, 150, 230, 350, 490, 650, 850, 1200, 1800, 2200, 3300, 5700, 8000, 11500, 21000,30000,40000,52000,80000, 13000, 2000 }; return upgradeValues[lvlsDictionary[_id] + 1]; }
            if (_id == E_UPGRADE.PER_SEC) { int[] upgradeValues = new int[] { 0, 0, 2, 5, 10, 20, 40, 80, 160, 300, 450, 750, 1100, 1600, 2100, 3000, 4400, 5800, 7300, 10000, 14000, 20000, 30000, 43000, 65000, 97000, 14000, 20000, 30000, 44000,88000,140000,200000 }; return upgradeValues[lvlsDictionary[_id] + 1]; }
            if (_id == E_UPGRADE.BONUS_STUN) { int[] upgradeValues = new int[] { 0,1,2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15 ,16,17,18,19,20,21,22,23,24,25,26,27,28,29,30,31,32,33,34,35 }; return upgradeValues[lvlsDictionary[_id] + 1]; }
            if (_id == E_UPGRADE.BONUS_PER_CLICK) { int[] upgradeValues = new int[] { 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15 ,16,17,18,19,20,21,22,23,24,25,26,27,28,29,30,31,32,33,34,35 }; return upgradeValues[lvlsDictionary[_id] + 1]; }
            if (_id == E_UPGRADE.BONUS_PER_SEC) { int[] upgradeValues = new int[] { 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15 ,16,17,18,19,20,21,22,23,24,25,26,27,28,29,30,31,32,33,34,35}; return upgradeValues[lvlsDictionary[_id] + 1]; }
            return 0;
        }

        static public void Upgrade(E_UPGRADE _id)
        {  
            if (_id == E_UPGRADE.PER_CLICK) { GameManager.refrence.weaponInfo.baseDamagePerClick = GameManager.refrence.weaponInfo.curDamagePerClick = GetNextUpgradeValue(_id); }
            if (_id == E_UPGRADE.PER_SEC) {   GameManager.refrence.weaponInfo.baseDamagePerSec = GameManager.refrence.weaponInfo.curDamagePerSec = GetNextUpgradeValue(_id); }
            if (_id == E_UPGRADE.BONUS_STUN) {  Bonus.BonusInfo.stunForSec = GetNextUpgradeValue(_id); }
            if (_id == E_UPGRADE.BONUS_PER_CLICK) {  Bonus.BonusInfo.perClickMultiplier = GetNextUpgradeValue(_id); }
            if (_id == E_UPGRADE.BONUS_PER_SEC) {  Bonus.BonusInfo.perSecMultiplier = GetNextUpgradeValue(_id); }
            IncreaseLvl(_id);
        }

        static private void IncreaseLvl(E_UPGRADE _id)
        {
            lvlsDictionary[_id] = lvlsDictionary[_id] + 1;
        }
        static public bool EnoughCoinsForUpgrade(E_UPGRADE _id)
        {
            return (GameManager.refrence.coinsInfo.coinsAmount >= GetUpgradeCost(_id));
        }

        static public bool IsUpgradedToMax(E_UPGRADE _upgrade)
        {
            if (lvlsDictionary[_upgrade] == maxLvl) 
                return true;
            return false;
        }
        static public bool IsEverythingUpgraded()
        {
            foreach (KeyValuePair<E_UPGRADE, int> upgradeItem in lvlsDictionary)
                if (upgradeItem.Value != maxLvl)
                    return false;
            return true;
        }

    }


    public Text txt_upgradeInfo;
    public Text txt_upgradePrice;
    public Text txt_upgradeLvl;






	void Awake()
	{
        SetOnClickListener();
    }
	
	void Start () 
	{	
	}

    void Update()
    {
        UpdateSlotGUI();
    }
    
	



    void UpdateSlotGUI()
    {
        //add unique info about what will happen on upgrade
        switch(upgradeType)
        {
            case E_UPGRADE.PER_CLICK: { txt_upgradeInfo.text = Global.GetSeparatedNumber(UpgradeInfos.GetNextUpgradeValue(upgradeType)) + "/click"; } break;
            case E_UPGRADE.PER_SEC: { txt_upgradeInfo.text = Global.GetSeparatedNumber(UpgradeInfos.GetNextUpgradeValue(upgradeType)) + "/sec"; } break;
            case E_UPGRADE.BONUS_PER_CLICK: { txt_upgradeInfo.text = "X"+Global.GetSeparatedNumber(UpgradeInfos.GetNextUpgradeValue(upgradeType)) + "/click"; } break;
            case E_UPGRADE.BONUS_PER_SEC: { txt_upgradeInfo.text = "X" + Global.GetSeparatedNumber(UpgradeInfos.GetNextUpgradeValue(upgradeType)) + "/sec"; } break;
            case E_UPGRADE.BONUS_STUN: { txt_upgradeInfo.text = "Sloth stunned for "+Global.GetSeparatedNumber(UpgradeInfos.GetNextUpgradeValue(upgradeType)) + " sec"; } break;
        }
        //add text info about level of upgrade
        txt_upgradeLvl.text = "LVL:" + UpgradeInfos.lvlsDictionary[upgradeType];
        //set text for price
        txt_upgradePrice.text = Global.GetSeparatedNumber(UpgradeInfos.GetUpgradeCost(upgradeType));         
    }

    void SetOnClickListener()
    {
        GetComponent<Button>().onClick.AddListener(delegate
        {
            if (UpgradeInfos.EnoughCoinsForUpgrade(upgradeType))
            {
                GameManager.refrence.coinsInfo.ReduceCoins(UpgradeSlotGUI.UpgradeInfos.GetUpgradeCost(upgradeType));
                UpgradeInfos.Upgrade(upgradeType);
                AudioManager.refrence.PlaySound(AudioManager.E_AUDIO.CASH);
                //if max lvl reached disable button
                DisableSlot();
            }
        });
    }

    public void DisableSlot()
    {
        if (UpgradeInfos.lvlsDictionary[upgradeType] >= GameManager.refrence.levelInfo.numOfLevels)
        {
            GetComponent<Button>().interactable = false;
        }
    }


}
