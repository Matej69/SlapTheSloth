using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class EndGameGUI : MonoBehaviour {

    public Image img_background;
    public Text txt_credits;
    

    RectTransform txtRect;

	void Awake()
	{
        txtRect = txt_credits.GetComponent<RectTransform>();
    }
	
	void Start () 
	{	
	}

	void Update () 
	{

        if (GameManager.refrence.gameEnded)
        {
            txtRect.position = new Vector2(txtRect.position.x, txtRect.position.y + (1 * Time.deltaTime));
            Color col = img_background.color;
            col.a += 1f * Time.deltaTime;
            img_background.color = new Color(col.r, col.g, col.b, col.a);
        }

    }
}
