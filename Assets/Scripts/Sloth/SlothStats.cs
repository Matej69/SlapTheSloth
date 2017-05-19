using UnityEngine;
using System.Collections;


public class SlothStats : MonoBehaviour {

    static public SlothStats refrence;

    public class Health
    {
        public float curHealth;
        public float maxHealth;

        public Health(float _cur, float _max) { curHealth = _cur; maxHealth = _max; }

        public void SetHealth(float _amount) { maxHealth = _amount; curHealth = _amount; }
        public void ReduceHealthBy(float _amount) { curHealth -= (curHealth - _amount >= 0) ? _amount : curHealth; }
        public void ResetHealth() { curHealth = maxHealth; }
        public int GetHealthForLevelX(int _lvl) { int[] hlts = new int[] { 100,180,380,650,1000,1500,2300,3500,5000,7500,11000,15500,20000, 26500, 31000,39000,52000,70000,88000, 110000,150000,200000,270000,340000,465000,650000,890000, 1200000,1700000,2400000,4000000 }; return hlts[_lvl]; }
    }
    public Health health;


    public enum E_STATE
    {
        FALLING,
        WALKING,
        STUNNED,
        KILLED,
        FINISHED
    }
    [HideInInspector]
    public E_STATE state;

    void Awake()
    {
        refrence = this;                
    }

    void Start()
    {
        SetState(E_STATE.FALLING);
        health = new Health(1, 1);
        health.SetHealth(health.GetHealthForLevelX(GameManager.refrence.levelInfo.curLevel));
    }

    void Update()
    {
        if (health.curHealth <= 0)
            SetState(E_STATE.KILLED);
    }


    public void SetState(E_STATE _state)
    {
        if (_state == E_STATE.KILLED && state != E_STATE.KILLED)
            OnDeath();

        state = _state;
        //SHOULDN'T BE HERE BUT THERE IS NO EVENT SYSTEM SO IT'S HERE..... SRY FUTURE SMARTER ME :)
        SlothAnimationController.refrence.SetAnimation(_state);
    }
    
    void OnDeath()
    {
        LevelFinishedGUI.refrence.SetActive(true);
    }












}