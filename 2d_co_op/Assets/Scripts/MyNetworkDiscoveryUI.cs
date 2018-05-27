using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MyNetworkDiscoveryUI : MonoBehaviour {

    // Use this for initialization
    public Text uiText;
    public int test;

    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void setText(string text)
    {
        uiText.text = text; 

    }
}
