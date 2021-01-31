using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUDUserInterface : MonoBehaviour {

    public Unit player;
    public Image healthBar;
    public Text healthLabel;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        healthBar.fillAmount = (float)player.GetcurHealth() / (float)player.Health;//转化为浮点数
        healthLabel.text = player.GetcurHealth().ToString();
	}
}
