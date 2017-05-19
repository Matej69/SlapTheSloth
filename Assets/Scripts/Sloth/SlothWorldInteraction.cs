using UnityEngine;
using System.Collections;


public class SlothWorldInteraction : MonoBehaviour {

    static public SlothWorldInteraction refrence;

    public GameObject ref_rope;
    public GameObject ref_apple;
    
    public BoxCollider2D ref_col_clickArea;
    [HideInInspector]
    public bool canBeClicked = false;

    void Awake()
	{
        refrence = this;
	}
	
	void Start () 
	{	

	}

	void Update () 
	{	
	}

    void OnTriggerEnter2D(Collider2D _col)
    {
        if (_col.gameObject == ref_rope)
        {
            SlothStats.refrence.SetState(SlothStats.E_STATE.WALKING);
            SetClickabilityState(true);
        }
        else if(_col.gameObject == ref_apple)
        {
            SlothStats.refrence.SetState(SlothStats.E_STATE.FINISHED);
            SetClickabilityState(false);
        }
    }

    void OnMouseDown()
    {
        if (canBeClicked)
        {
            SlothStats.refrence.health.ReduceHealthBy(GameManager.refrence.weaponInfo.curDamagePerClick);
            GameManager.refrence.coinsInfo.AddCoins(GameManager.refrence.weaponInfo.GetCoinsPerClick());
            AudioManager.refrence.PlaySound(AudioManager.E_AUDIO.SLAP);
        }
    }

    public void SetClickabilityState(bool _state)
    {
        ref_col_clickArea.enabled = _state;
        canBeClicked = _state;
    }


}
