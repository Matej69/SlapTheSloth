using UnityEngine;
using System.Collections;


public class SlothMovementController : MonoBehaviour {

    static public SlothMovementController refrence;

    private Vector2 velocity;
    public float gravity = 1f;
    public float movementSpeed = 1f;

    Timer timer_stunned;

    void Awake()
	{
        refrence = this;
    }
	
	void Start () 
	{
    }

	void Update () 
	{
        HandleMovement(SlothStats.refrence.state);
        HandleStunned();
    }


    void HandleMovement(SlothStats.E_STATE _state)
    {
        //Set proper velocity
        if (_state == SlothStats.E_STATE.FALLING)
            velocity = new Vector2(0, -gravity);
        else if (_state == SlothStats.E_STATE.WALKING)
            velocity = new Vector2(movementSpeed, 0);
        else if (_state == SlothStats.E_STATE.STUNNED)
            velocity = new Vector2(0, 0);
        else if (_state == SlothStats.E_STATE.KILLED)
            velocity = new Vector2(0, -gravity);
        else if (_state == SlothStats.E_STATE.FINISHED)
            velocity = new Vector2(0, 0);

        //apply velocity to position
        transform.Translate(velocity * Time.deltaTime);
    }

    void HandleStunned()
    {
        if (SlothStats.refrence.state == SlothStats.E_STATE.STUNNED)
        {
            timer_stunned.Tick(Time.deltaTime);
            if (timer_stunned.IsFinished())
            {
                SlothStats.refrence.SetState(SlothStats.E_STATE.WALKING);
                timer_stunned = null;
            }
        }
    }

    public void SetStunnedTimer()
    {
        timer_stunned = new Timer(Bonus.BonusInfo.stunForSec);
    }



}
