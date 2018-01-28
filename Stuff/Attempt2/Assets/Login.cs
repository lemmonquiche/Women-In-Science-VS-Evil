using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UI;

using Firebase;
using Firebase.Database;
using Firebase.Unity.Editor;

public class Login : MonoBehaviour {

	public GameObject username;
	public GameObject password;

	private string m_username;
	private string m_password;

	// Use this for initialization
	void Start () {	
		// Set up the Editor before calling into the realtime database.
		FirebaseApp.DefaultInstance.SetEditorDatabaseUrl("https://women-in-science-vs-evil.firebaseio.com/");

		// Get the root reference location of the database.
		DatabaseReference reference = FirebaseDatabase.DefaultInstance.RootReference;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Tab)) {
			if (username.GetComponent<InputField> ().isFocused) {
				password.GetComponent<InputField> ().Select ();
			}
		}

		m_username = username.GetComponent<InputField>().text;
		m_password = password.GetComponent<InputField>().text;

		if (Input.GetKeyDown (KeyCode.Return)) {
			if (m_username != "" && m_password != "") {
				LoginButton ();
			} else {
				// TODO
				print("Error occurred.");
			}
		}
	}

	public void LoginButton() {
		FirebaseDatabase.DefaultInstance
			.GetReference ("rest/users")
			.GetValueAsync ().ContinueWith (task => {
				if (task.IsFaulted) {
					// Handle the error...
				} else if (task.IsCompleted) {
					DataSnapshot snapshot = task.Result;
					// Do something with snapshot...
					print (snapshot.GetRawJsonValue());
					if (snapshot.HasChildren) {
						foreach (DataSnapshot user in snapshot.Children) {
							if (user.HasChild("username") && m_username.Equals(user.Child("username").Value)) {
								if (user.HasChild("password") && m_password.Equals(user.Child("password").Value)) {
									print("Successful login!");
									int currLevel = 0;
									if (user.HasChild("level")) {
										currLevel = (int)user.Child("level").Value;
										// TODO: go to level
									}
									print("currLevel = " + currLevel);
								} else {
									print("Incorrect password");
								}
							} else {
								print("User does not exist");
							}
						}
					}
				}
			});
	}
}
