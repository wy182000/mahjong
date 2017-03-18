﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShareWnd : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Show() {
        if (!gameObject.activeSelf) {
            gameObject.SetActive(true);
        }
    }

    public void OnClose() {
        if (gameObject.activeSelf) {
            gameObject.SetActive(false);
        }
    }

    public void OnShareFriend() {

    }

    public void OnShareSocial() {

    }

}
