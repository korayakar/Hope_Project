using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using MySql.Data.MySqlClient;
using System;
using System.Threading;
using System.Collections;
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
    private const string url = "http://localhost:8080/api/v1/login";

    void Start()
    {
        exitbutton.gameObject.SetActive(false);
       
    }

    public void sendInfo()
    {
        StartCoroutine(Signup());
        if (name.text.ToString() == "" || name.text == null)
        {
            nameError.text = "Name cannot be empty!";
            exitbutton.gameObject.SetActive(false);
            return;
        }

        if (ID.text.ToString() == "")
        {
            IDmessage.text = "ID cannot be empty!";
            return;
        }

        if (!(isNumber(ID.text.ToString())))
        {
            IDmessage.text = "not a number!";
            return;
        }

        if (long.Parse(ID.text) % 2 != 0 || ID.text.ToString().Length != 11)
        {
            IDmessage.text = "not a valid ID!";
            return;
        }

        if (password.text.ToString() == "")
        {
            passwordError.text = "Please fill password field!";
            return;
        }

        if (password.text.ToString().Length < 6)
        {
            passwordError.text = "Password length must be bigger than 6!";
            return;
        }

 
        nameError.text = "";
        IDmessage.text = "";
        passwordError.text = "";
        // successfull login

        
        /*
        if (sendMessage()) {
            exitbutton.gameObject.SetActive(true);
        }
        else
        {
            exitbutton.gameObject.SetActive(false);
        }*/
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

    public IEnumerator Signup()
    {
        Debug.Log("here!");
        WWWForm form = new WWWForm();
        form.AddField("username", "22222222222");
        form.AddField("password", "123456789");
        //form.AddField("name", name);
        //form.AddField("role", "PATIENT");

        using (UnityWebRequest webRequest = UnityWebRequest.Post(url, form))
        {
            yield return webRequest.SendWebRequest();
            Debug.Log(webRequest.result);
            if (webRequest.result != UnityWebRequest.Result.Success)
            {
                Debug.LogError("Error sending request: " + webRequest.error);
            }
            else
            {
                string response = webRequest.downloadHandler.text;
                Debug.Log("Response: " + response);
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
