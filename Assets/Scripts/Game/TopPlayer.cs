﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopPlayer : MonoBehaviour {

    public RootBehaviour _Root;
    public TopPlayerHead Head;

	// Use this for initialization
	void Start () {
        //Maria.Command cmd = new Maria.Command(Bacon.MyEventCmd.EVENT_SETUP_TOPPLAYER, gameObject);
        //_Root.App.Enqueue(cmd);
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void ShowUI() {
        Head.Show();
    }
    public void HideUI() {
        Head.Close();
    }
}
