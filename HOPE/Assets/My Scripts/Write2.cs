using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using MySql.Data.MySqlClient;
using System;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using TMPro;

public class Write2 : MonoBehaviour
{

    public TMP_InputField ID;
    public TMP_InputField password;
    //public TMPro.TMP_Text ID;
    public Text IDmessage;
    public Text passwordErrorMessage;
    public Canvas loginCanvas;
    public Canvas signUpCanvas;
    private string connectionString;
    public MySqlConnection MS_Connection;
    public MySqlCommand MS_Command;
    string query;
    public Button signUpButton;
    public bool isLogin = false;
    public static string accessToken = null;
    private const string loginUrl = "http://localhost:8080/api/v1/login";

    [System.Serializable]
    class Token
    {
        public string access_token;
    }

    public void start()
    {
        signUpButton = GetComponent<Button>();
        signUpButton.onClick.AddListener(changeCanvas);
    }

    public void sendInfo()
    {
        if (ID.text.ToString() == "" )
        {
            IDmessage.text = "ID cannot be empty!";
            return;
        }

        if (!(isNumber(ID.text.ToString())))
        {
            //inputField.GetComponent<TMP_InputField>().text;
            IDmessage.text = "not a number!";
            return;
        }

        if (long.Parse(ID.text) % 2 != 0 || ID.text.ToString().Length != 11)
        {
            IDmessage.text = "not a valid ID!";
            return;
        }

        if(password.text.ToString() == "")
        {
            passwordErrorMessage.text = "Please fill password field!";
            return;
        }

        if (password.ToString().Length < 6)
        {
            passwordErrorMessage.text = "Password length must be bigger than 6";
            return;
        }

        IDmessage.text = "";
        passwordErrorMessage.text = "";
        StartCoroutine(Login(ID.text.ToString(), password.text.ToString()));
    }

    public void changeCanvas()
    {
        loginCanvas.gameObject.SetActive(false);
        signUpCanvas.gameObject.SetActive(true);
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

    public IEnumerator Login(string idNumber, string password)
    {
        WWWForm form = new WWWForm();
        form.AddField("username", idNumber);
        form.AddField("password", password);

        using (UnityWebRequest webRequest = UnityWebRequest.Post(loginUrl, form))
        {
            yield return webRequest.SendWebRequest();

            if (webRequest.result != UnityWebRequest.Result.Success)
            {
                Debug.LogError("Error sending request: " + webRequest.error);
                passwordErrorMessage.text = "Error while loging in";
            }
            else
            {
                string response = webRequest.downloadHandler.text;
                Token responseJson = JsonUtility.FromJson<Token>(response);
                accessToken = responseJson.access_token;
                SceneManager.LoadScene(1);
                Debug.Log("Access token: " + accessToken);
            }
        }
    }
}
