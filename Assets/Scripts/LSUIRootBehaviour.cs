﻿using UnityEngine;
using System.Collections;
using Maria;
using Maria.App;

public class LSUIRootBehaviour : MonoBehaviour {

    public GameObject _signupPanel;
    public GameObject _loginPanel;

    private App _app = null;
    private string _username = null;
    private string _password = null;

    // Use this for initialization
    void Start () {
        _loginPanel.SetActive(true);
        _signupPanel.SetActive(false);
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    public void OnSignupPanelClick()
    {
        _loginPanel.SetActive(false);
        _signupPanel.SetActive(true);
    }

    public void OnLoginCommit()
    {
        var com = _loginPanel.GetComponent<LoginPanelBehaviour>();
        string username = com.GetUsername();
        string password = com.GetPassword();
        if (username.Length < 4)
        {
            Debug.Log("you should have more lenth.");
            return;
        }
        if (password.Length < 3)
        {
            return;
        }
        string server = "sample";
        InitApp();
        Context ctx = _app.AppContext;
        LoginController ctr = ctx.GetController<LoginController>("login");
        ctr.Auth(server, username, password);
    }

    public void OnSignupBtnClick()
    {
        //startPanel.SetActive(false);
        //loginPanel.SetActive(false);
    }

    public void OnSignupCommit()
    {
        //var g = GameObject.Find("AccountIFText");
        //var c = g.GetComponent<Text>();
        //account = c.text;
        //password = GameObject.Find("PwdIFText").GetComponent<Text>().text;
        //var cfmPassword = GameObject.Find("CfmPwdIFText").GetComponent<Text>().text;
        //if (password != cfmPassword)
        //{
        //    account = null;
        //    password = null;
        //}
        //else
        //{
        //    if (login != null)
        //    {
        //        login = GameObject.Find("Login").GetComponent<ClientLogin>();
        //    }
        //    string ip = "192.168.1.239";
        //    int port = 3001;
        //    login.Auth(ip, port, "sample", account, password, null, OnSignupCallback);
        //}
    }

    public void OnSignupCallback(bool ok, object ud, byte[] secret, string dummy)
    {
        if (ok)
        {
            //startPanel.SetActive(true);
            //loginPanel.SetActive(true);
        }
        else
        {
            Debug.Log("please enter your username.");
            //GameObject.Find("AccountIF").GetComponent<InputField>().text = string.Empty;
            //GameObject.Find("PwdIF").GetComponent<InputField>().text = string.Empty;
            //GameObject.Find("CfmPwdIF").GetComponent<InputField>().text = string.Empty;
        }
    }

    private void InitApp()
    {
        if (_app == null)
        {
            _app = GameObject.Find("App").GetComponent<App>();
            Debug.Assert(_app != null);
        }
    }
}