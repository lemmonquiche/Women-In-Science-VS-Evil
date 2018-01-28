using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

using Firebase;
using Firebase.Database;
using Firebase.Unity.Editor;

public class Register : MonoBehaviour {

	public DatabaseReference reference;

	public GameObject username;
	public GameObject password;
	public GameObject confirmPassword;
    public Button loginButton;
    public Button registerButton;

	private string m_username;
	private string m_password;
	private string m_confirmPassword;

	// Use this for initialization
	void Start () {
		// Set up the Editor before calling into the realtime database.
		FirebaseApp.DefaultInstance.SetEditorDatabaseUrl("https://women-in-science-vs-evil.firebaseio.com/");

		// Get the root reference location of the database.
		reference = FirebaseDatabase.DefaultInstance.RootReference;

        Button loginBtn = loginButton.GetComponent<Button>();
        loginBtn.onClick.AddListener(LoginButton);

        Button registerBtn = registerButton.GetComponent<Button>();
        registerBtn.onClick.AddListener(RegisterButton);
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
			RegisterButton ();
		}
	}

    public void LoginButton() {
        SceneManager.LoadScene("Login");
    }
		
	public void RegisterButton() {
        if (m_username != "" && m_password != "" && m_confirmPassword != "" && m_confirmPassword.Equals(m_password)) {
            FirebaseDatabase.DefaultInstance
                .GetReference("rest/users")
                .GetValueAsync().ContinueWith(task =>
                {
                    if (task.IsFaulted)
                    {
                        // Handle the error...
                    }
                    else if (task.IsCompleted)
                    {
                        DataSnapshot snapshot = task.Result;
                        // Do something with snapshot...
                        print(snapshot.GetRawJsonValue());
                        if (snapshot.HasChildren)
                        {
                            foreach (DataSnapshot user in snapshot.Children)
                            {
                                if (user.HasChild("username") && m_username.Equals(user.Child("username").Value))
                                {
                                    print("User already exists");
                                }
                                else
                                {
                                    User newUser = new User(m_username, m_password, 0);
                                    string json = JsonUtility.ToJson(newUser);
                                    //reference.Child("rest/users").Push();
                                }
                            }
                        }
                    }
                });
        } else {
            // TODO
            print("Error occurred.");
        }
    }

	private class User {

		public string username;
		public string password;
		public int level;

		public User(string username, string password, int level) {
			this.username = username;
			this.password = password;
			this.level = level;
		}
	}
}
