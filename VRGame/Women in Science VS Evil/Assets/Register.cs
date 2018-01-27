using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;

using UnityEngine;
using UnityEngine.UI;

public class Register : MonoBehaviour {

	public GameObject username;
	public GameObject password;
	public GameObject confirmPassword;

	private string m_username;
	private string m_password;
	private string m_confirmPassword;

	private string form;	// Contains all the form values

	// Use this for initialization
	void Start () {
		
	}

	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Tab)) {
			if (username.GetComponent<InputField> ().isFocused) {
				password.GetComponent<InputField> ().Select ();
			}
			if (password.GetComponent<InputField> ().isFocused) {
				confirmPassword.GetComponent<InputField> ().Select ();
			}
		}

		m_username = username.GetComponent<InputField>().text;
		m_password = password.GetComponent<InputField>().text;
		m_confirmPassword = confirmPassword.GetComponent<InputField>().text;
	
		if (Input.GetKeyDown (KeyCode.Return)) {
			if (m_username != "" && m_password != "" && m_confirmPassword != "") {
				RegisterButton ();
			}
		}
	}
		
	public void RegisterButton() {
		string url = "https://women-in-science-vs-evil.firebaseio.com/.json";

	}
}
