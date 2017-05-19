using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class BonusText : MonoBehaviour {

    static public BonusText refrence;

    Text txt_text;

    Timer timer_startOpacityReducement;
    float reduceVisiblitySpeed = 2f;
    

	void Awake()
	{
        refrence = this;
        txt_text = GetComponent<Text>();

    }
	
	void Start () 
	{
        timer_startOpacityReducement = new Timer(2.5f);
    }

	void Update () 
	{
        HandleVisibilityReducement();
    }


    void HandleVisibilityReducement()
    {
        timer_startOpacityReducement.Tick(Time.deltaTime);
        if (timer_startOpacityReducement.IsFinished())
        {
            float newAlpha = txt_text.color.a - reduceVisiblitySpeed * Time.deltaTime;
            if (newAlpha >= 0)
                txt_text.color = new Color(txt_text.color.r, txt_text.color.g, txt_text.color.b, newAlpha);
        }                
    }

    public void SetText(string _text)
    {
        txt_text.text = _text;
        txt_text.color = new Color(txt_text.color.r, txt_text.color.g, txt_text.color.b, 1);
        timer_startOpacityReducement.Reset();
    }




}
