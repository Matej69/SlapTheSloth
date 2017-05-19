using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class StarSpawner : MonoBehaviour {

    public GameObject pref_star;

    List<GameObject> stars = new List<GameObject>();
    Timer timer_spawnStar;

	void Awake()
	{
	}
	
	void Start () 
	{
        timer_spawnStar = new Timer(Random.Range(0.3f,1.1f));
    }

	void Update () 
	{
        HandleStarLifetime();
        //destroy if sloth not stunned
        if (SlothStats.refrence.state != SlothStats.E_STATE.STUNNED)
            Destroy(gameObject);
    }


    void HandleStarLifetime()
    {
        timer_spawnStar.Tick(Time.deltaTime);
        if(timer_spawnStar.IsFinished())
        {
            timer_spawnStar = new Timer(Random.Range(0.2f, 0.75f));
            Vector2 starStartPos = new Vector2(transform.position.x + Random.Range(-0.55f, 0.55f), transform.position.y);
            stars.Add((GameObject)Instantiate(pref_star, starStartPos, Quaternion.identity));
            //get star random size
            float randomScale = Random.Range(0.55f, 1f);
            stars[stars.Count - 1].transform.localScale *= randomScale;
        }

        foreach (GameObject star in stars)
        {
            //reduce each star opacity
            Color col = star.GetComponent<SpriteRenderer>().color;
            col.a -= Time.deltaTime;
            star.GetComponent<SpriteRenderer>().color = col;                        
            //move existing stars
            star.transform.Translate(Vector2.up * Time.deltaTime);
        }
    }

    void OnDestroy()
    {
        for(int i = stars.Count - 1; i >= 0; --i)
        {
            Destroy(stars[i]);
        }
    }
    


}
