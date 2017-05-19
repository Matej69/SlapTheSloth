using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class CoinInfoGUI : MonoBehaviour {

    static public CoinInfoGUI refrence;

    public Text ref_perClick;
    public Text ref_perSecond;
    public Text ref_coinsAmount;

    [HideInInspector]
    Color normalColor;


    void Awake()
	{
        refrence = this;
    }
	
	void Start () 
	{
        normalColor = ref_perClick.color;
    }

	void Update () 
	{
        UpdateCoinGUI();
    }


    void UpdateCoinGUI()
    {        
        ref_perClick.text = Global.GetSeparatedNumber(GameManager.refrence.weaponInfo.GetCoinsPerClick());
        ref_perSecond.text = Global.GetSeparatedNumber(GameManager.refrence.weaponInfo.GetCoinsPerSec());
        ref_coinsAmount.text = Global.GetSeparatedNumber(GameManager.refrence.coinsInfo.coinsAmount);     
    }

    public void ResetTextColor()
    {
        ref_perClick.color = normalColor;
        ref_perSecond.color = normalColor;
        ref_coinsAmount.color = normalColor;
    }
    





}
