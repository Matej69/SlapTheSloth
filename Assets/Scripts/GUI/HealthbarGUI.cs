using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class HealthbarGUI : MonoBehaviour {

    public RectTransform frontBar;
    public RectTransform backBar;
    float maxBarWidth;

	void Awake()
	{
    }
	
	void Start () 
	{
        maxBarWidth = backBar.rect.width;
    }

	void Update () 
	{
        UpdateBar();
	}

    void UpdateBar()
    {
        float percentFilled = (SlothStats.refrence.health.curHealth / SlothStats.refrence.health.maxHealth);       
        frontBar.localScale = new Vector2(percentFilled, frontBar.localScale.y);
    }
    
}
