using UnityEngine;
using System.Collections;

public class SlothAnimationController : MonoBehaviour {

    static public SlothAnimationController refrence;


    Animator animator;
    public GameObject pref_FallingAnim;
    public GameObject pref_WalkingAnim;
    public GameObject pref_FinishedAnim;

    private GameObject ref_AnimObject = null;



    void Awake()
    {
        refrence = this;
        animator = GetComponent<Animator>();
    }

    void Start()
    {
        SetAnimation(SlothStats.E_STATE.FALLING);
    }

    void Update()
    {        
    }



    //FUNCTION IS CALLED FROM 'SlothStats' WHEN STATE IS CHANGED
    public void SetAnimation(SlothStats.E_STATE _state)
    {
        //destroy previous anim object
        if (ref_AnimObject != null)
            Destroy(ref_AnimObject);

        //SetAnimation animation
        if (_state == SlothStats.E_STATE.FALLING)
        {
            ref_AnimObject = (GameObject)Instantiate(pref_FallingAnim,transform.position,Quaternion.identity);
        }
        else if (_state == SlothStats.E_STATE.WALKING)
        {
            Vector2 startPos = new Vector2(transform.position.x, transform.position.y - 0.8f);
            ref_AnimObject = (GameObject)Instantiate(pref_WalkingAnim, startPos, Quaternion.identity);
        }
        else if (_state == SlothStats.E_STATE.STUNNED)
        {
            Vector2 startPos = new Vector2(transform.position.x, transform.position.y - 0.1f);
            ref_AnimObject = (GameObject)Instantiate(pref_FallingAnim, startPos, Quaternion.identity);
        }
        else if (_state == SlothStats.E_STATE.KILLED)
        {
            Vector2 startPos = new Vector2(transform.position.x, transform.position.y - 1f);
            ref_AnimObject = (GameObject)Instantiate(pref_FallingAnim, startPos, Quaternion.identity);
        }
        else if (_state == SlothStats.E_STATE.FINISHED)
        {
            Vector2 startPos = new Vector2(transform.position.x, transform.position.y - 0.95f);
            ref_AnimObject = (GameObject)Instantiate(pref_FinishedAnim, startPos, Quaternion.identity);
        }
        //set new anim object as parent
        ref_AnimObject.name = "AnimatedObject_"+ _state.ToString();
        ref_AnimObject.transform.SetParent(transform);    
    }

    



    



}
