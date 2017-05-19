using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;


public class UpgradesGUI : MonoBehaviour {

    static public UpgradesGUI refrence;

    public Button btn_shop;
    public Button btn_shopAdds;

    public Button btn_hideShop;
    public Button btn_hideShopAdds;

    public Button btn_watchVideo;
    public Text txt_secLeft;

    public GameObject shopContent;
    public GameObject shopAddsContent;

    Timer timer_watchVideo;

    public List<UpgradeSlotGUI> upgradeSlotList = new List<UpgradeSlotGUI>();

    void Awake()
	{
        refrence = this;
        timer_watchVideo = new Timer(4f * 60f * 0);
    }
	
	void Start () 
	{
        SetButtonListeners();
    }

	void Update () 
	{
        timer_watchVideo.Tick(Time.deltaTime);
        UpdateSecondsLeftToWatch();
    }



    void SetButtonListeners()
    {
        //normal shop button
        btn_shop.onClick.AddListener(delegate
        {
            shopContent.SetActive(true);            
        });
        //adds shop button
        btn_shopAdds.onClick.AddListener(delegate
        {
            shopAddsContent.SetActive(true);
        });

        //hide shop button
        btn_hideShop.onClick.AddListener(delegate
        {
            shopContent.SetActive(false);
        });
        //hide add shop button        
        btn_hideShopAdds.onClick.AddListener(delegate
        {
            shopAddsContent.SetActive(false);
        });

        //buy button
        btn_watchVideo.onClick.AddListener(delegate
        {
            if(timer_watchVideo.IsFinished())
            {
                if (Application.internetReachability != NetworkReachability.NotReachable)
                {
                    AddManager.refrence.ShowRewardedAd(AddManager.E_REWARD.UPGRADE);
                    timer_watchVideo = new Timer(6f * 60f);
                }
                else
                {
                    BonusText.refrence.SetText("YOU MUST BE CONNECTED TO A NETWORK");
                }                
            }                        
        });
    }


    void UpdateSecondsLeftToWatch()
    {
        int min = ((int)timer_watchVideo.currentTime / 60 >= 0) ? ((int)timer_watchVideo.currentTime / 60) : 0;
        int sec = ((int)timer_watchVideo.currentTime % 60 >= 0) ? ((int)timer_watchVideo.currentTime % 60) : 0;
        txt_secLeft.text = min + ":" + sec;
    }


    public void DisableSlot(UpgradeSlotGUI.E_UPGRADE _upgradeType)
    {
        foreach (UpgradeSlotGUI slot in upgradeSlotList)
            if (slot.upgradeType == _upgradeType)
                slot.DisableSlot();
    }





}
