using UnityEngine;
using System.Collections;
using UnityEngine.Advertisements;

public class AddManager : MonoBehaviour
{
    static public AddManager refrence;

    private bool connected = false;
    void Awake()
    {
        refrence = this;
    }

    void Start()
    {
        //StartCoroutine(RefreshInternetConnection());
    }
     




    public enum E_REWARD
    {
        UPGRADE,
        END_LVL_COINS
    }

    public void ShowRewardedAd(E_REWARD _rewardID)
    {
        StartCoroutine(ShowAddWhenReady(_rewardID));                        
    }

    private IEnumerator ShowAddWhenReady(E_REWARD _rewardID)
    {
        while (!Advertisement.IsReady("rewardedVideo"))
        {
            Advertisement.Initialize("1415243");
            UnityAdsHelper.Initialize();
            yield return null;
        }
                
        var options = (_rewardID == E_REWARD.UPGRADE) ?
                new ShowOptions { resultCallback = OnUpgrade } :
                new ShowOptions { resultCallback = OnLvlEndCoins };
            Advertisement.Show("rewardedVideo", options);
    }





    private void OnUpgrade(ShowResult result)
    {
        switch (result)
        {
            case ShowResult.Finished:
                if (!UpgradeSlotGUI.UpgradeInfos.IsEverythingUpgraded())
                {
                    //get random upgradeID
                    UpgradeSlotGUI.E_UPGRADE randID = (UpgradeSlotGUI.E_UPGRADE)Random.Range(0, (int)UpgradeSlotGUI.E_UPGRADE.SIZE);
                    while(UpgradeSlotGUI.UpgradeInfos.IsUpgradedToMax(randID))
                    {
                        randID = (UpgradeSlotGUI.E_UPGRADE)Random.Range(0, (int)UpgradeSlotGUI.E_UPGRADE.SIZE);
                    }

                    UpgradeSlotGUI.UpgradeInfos.Upgrade(randID);
                    if (UpgradeSlotGUI.UpgradeInfos.IsUpgradedToMax(randID))
                        UpgradesGUI.refrence.DisableSlot(randID);

                    AudioManager.refrence.PlaySound(AudioManager.E_AUDIO.CASH);
                    BonusText.refrence.SetText(randID + " UPGRADED TO LVL " + (UpgradeSlotGUI.UpgradeInfos.lvlsDictionary[randID]));
                    UpgradesGUI.refrence.shopAddsContent.SetActive(false);
                }
                break;
            case ShowResult.Skipped:
                break;
            case ShowResult.Failed:
                Debug.LogError("The ad failed to be shown.");
                break;
        }
    }

    private void OnLvlEndCoins(ShowResult result)
    {
        switch (result)
        {
            case ShowResult.Finished:
                GameManager.refrence.coinsInfo.AddCoins(LevelFinishedGUI.refrence.GetRewardCoinsAmount());
                GameManager.refrence.AdvanceToNextLevel();
                LevelFinishedGUI.refrence.SetActive(false);
                AudioManager.refrence.PlaySound(AudioManager.E_AUDIO.CASH);
                BonusText.refrence.SetText("+"+Global.GetSeparatedNumber(LevelFinishedGUI.refrence.GetRewardCoinsAmount())+" COINS");
                break;
            case ShowResult.Skipped:
                break;
            case ShowResult.Failed:
                Debug.LogError("The ad failed to be shown.");
                break;
        }
    }






    private IEnumerator RefreshInternetConnection()
    {        
        float timeCheck = 1.0f;//will check google.com every one seconds
        float t1;
        float t2;
        while (!connected)
        {
            WWW www = new WWW("http://google.com");
            t1 = Time.fixedTime;
            yield return www;
            if (www.error == null)//if no error
            {
#if UNITY_ANDROID
                Advertisement.Initialize("1415243"); // initialize Unity Ads.
                UnityAdsHelper.Initialize(); // initialize Unity Ads.
#elif UNITY_IOS
                 UnityAdsHelper.Initialize(); // initialize Unity Ads.
#endif

                connected = true;

                break;//will end the coroutine
            }
            t2 = Time.fixedTime - t1;
            if (t2 < timeCheck)
                yield return new WaitForSeconds(timeCheck - t2);
        }
    }




}