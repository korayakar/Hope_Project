using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using MySql.Data.MySqlClient;
using System;
using System.Text;
using System.Threading;
using System.Collections;
using System.Collections.Generic;
using TMPro;

public class Write : MonoBehaviour
{
    public TMP_InputField name;
    public TMP_InputField password;
    public TMP_InputField ID;
    //public TMPro.TMP_Text name;
    //public TMPro.TMP_Text Surnames;
    //public TMPro.TMP_Text ID;
    public Text IDmessage;
    public Text nameError;
    public Text passwordError;
    public Text successfulMsg;
    public Canvas signUpCanvas;
    public Canvas loginCanvas;
    private string connectionString;
    private MySqlConnection MS_Connection;
    private MySqlCommand MS_Command;
    string query;
    public Button exitbutton;
    public Button signUpButton;
    private const string signupUrl = "http://localhost:8080/api/v1/signup";

    [System.Serializable]
    class UserData
    {
        public string status;
        public string message;
        public User data;
    }

    [System.Serializable]
    class User
    {
        public int id;
        public string username;
        public string password;
        public string name;
        public Role[] roles;
    }

    [System.Serializable]
    class Role
    {
        public int id;
        public string name;
    }

    void Start()
    {
        exitbutton.gameObject.SetActive(false);
       
    }

    public void sendInfo()
    {
        if (name.text.ToString() == "" || name.text == null)
        {
            nameError.text = "Name cannot be empty!";
            exitbutton.gameObject.SetActive(false);
            return;
        }
        else
        {
            nameError.text = "";
        }
        if (ID.text.ToString() == "")
        {
            IDmessage.text = "ID cannot be empty!";
            return;
        }
        else
        {
            IDmessage.text = "";
        }

        if (!(isNumber(ID.text.ToString())))
        {
            IDmessage.text = "not a number!";
            return;
        }
        else
        {
            IDmessage.text = "";
        }


        if (long.Parse(ID.text) % 2 != 0 || ID.text.ToString().Length != 11)
        {
            IDmessage.text = "not a valid ID!";
            return;
        }
        else
        {
            IDmessage.text = "";
        }


        if (password.text.ToString() == "")
        {
            passwordError.text = "Please fill password field!";
            return;
        }
        else
        {
            passwordError.text = "";
        }

        if (password.text.ToString().Length < 6)
        {
            passwordError.text = "Password length must be bigger than 6!";
            return;
        }
        else
        {
            passwordError.text = "";
        }

        StartCoroutine(Signup(ID.text.ToString(), password.text.ToString(), name.text.ToString()));
    }
   
    public bool isNumber(string str)
    {
        try
        {
            long.Parse(str);
            return true;
        }
        catch (Exception e)
        {
            return false;
        }
    }

    public IEnumerator Signup(string idNumber, string password, string name)
    {
        WWWForm form = new WWWForm();
        form.AddField("username", idNumber);
        form.AddField("password", password);
        form.AddField("name", name);
        form.AddField("role", "PATIENT");

        using (UnityWebRequest webRequest = UnityWebRequest.Post(signupUrl, form))
        {
            yield return webRequest.SendWebRequest();

            if (webRequest.result != UnityWebRequest.Result.Success)
            {
                Debug.LogError("Error sending request: " + webRequest.error);
                successfulMsg.text = "Error while signing up";
            }
            else
            {
                string response = webRequest.downloadHandler.text;
                UserData responseJson = JsonUtility.FromJson<UserData>(response);

                if (responseJson.status.Equals("success"))
                {
                    exitbutton.gameObject.SetActive(true);
                    successfulMsg.text = "Successfully Signup!";
                } else
                {
                    successfulMsg.text = responseJson.message;
                }
                Debug.Log(responseJson.status);
            }
        }
    }

    public void changeCanvas()
    {
        successfulMsg.text = "";
        nameError.text = "";
        passwordError.text = "";
        IDmessage.text = "";
        signUpCanvas.gameObject.SetActive(false);
    }
}
