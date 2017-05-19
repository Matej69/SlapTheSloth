using UnityEngine;
using System.Collections;

public class Explosion : MonoBehaviour {

	void Awake()
	{
	}
	
	void Start () 
	{
        StartCoroutine(DestroyAfter(2f));
	}

	void Update () 
	{	
	}


    IEnumerator DestroyAfter(float _sec)
    {
        yield return new WaitForSeconds(_sec);
        Destroy(gameObject);
    }


}
