using UnityEngine;
using System.Collections;


public class BonusSpawner : MonoBehaviour {

    Timer timer_spawnBonus;
    public GameObject pref_bonus; 


	void Awake()
	{
	}
	
	void Start () 
	{
        timer_spawnBonus = new Timer(Random.Range(1 * 60f, 2 * 60f));
    }

	void Update () 
	{
        HandleBonusSpawn();	
	}


    
    void HandleBonusSpawn()
    {
        timer_spawnBonus.Tick(Time.deltaTime);
        if(timer_spawnBonus.IsFinished())
        {
            SpawnBonus();
            timer_spawnBonus = new Timer(Random.Range(4 * 60f, 8 * 60f));
        }
        
    }

    void SpawnBonus()
    {
        Vector2 pos = new Vector2(transform.position.x + Random.Range(-2.5f, 2.5f),transform.position.y);
        Instantiate(pref_bonus, pos, Quaternion.identity);
    }





}
