using UnityEngine;
using UnityEngine.UI;
using MySql.Data.MySqlClient;
using System;
using System.Threading;

public class Write : MonoBehaviour
{
    public Text name;
    public Text Surnames;
    public Text ID;
    public Text IDmessage;
    public Text nameError;
    public Text surnameError;
    public Text successfulMsg;
    public Canvas signUpCanvas;
    public Canvas loginCanvas;
    private string connectionString;
    private MySqlConnection MS_Connection;
    private MySqlCommand MS_Command;
    string query;
    public Button exitbutton;

    void Start()
    {
        exitbutton.gameObject.SetActive(false);
    }

    public void sendInfo()
    {
        connection();

        if(name.text.ToString() == "" || name.text == null)
        {
            nameError.text = "Name cannot be null!";
            exitbutton.gameObject.SetActive(false);
            return;
        }

        else
        {
            nameError.text = "";
        }
        if (Surnames.text.ToString() == "")
        {
            surnameError.text = "Surname cannot be null!";
            return;
        }
        else
        {
            surnameError.text = "";
        }
        if (ID.text.ToString() == "")
        {
            IDmessage.text = "ID cannot be empty!";
            return ;
        }

        else
        {
            IDmessage.text = "";
        }

        if (!(isNumber(ID.text.ToString())))
        {
            IDmessage.text = "not a number!";
            return ;
        }
        else IDmessage.text = "";
        if (long.Parse(ID.text) % 2 != 0 || ID.text.ToString().Length != 11)
        {
            IDmessage.text = "not a valid ID!";
            return ;
        }
        
        query = "insert into MyTable(Name, Surname, ID) values('" + name.text + "' , '" + Surnames.text + "', '" + ID.text + "');";

        MS_Command = new MySqlCommand(query, MS_Connection);

        if (sendMessage()) {
            exitbutton.gameObject.SetActive(true);
        }
        else
        {
            exitbutton.gameObject.SetActive(false);
        }
       



    }
    public bool sendMessage()
    {
        try
        {
            int a = MS_Command.ExecuteNonQuery();
            if(a != -1)
            {
                Debug.Log("hello");
                successfulMsg.text = "Successfully signed up!";
                MS_Connection.Close();
                Invoke("changeCanvas", 5);
                
                return true;
            }
            return false;
        }
        catch (Exception e)
        {
            successfulMsg.text = "ID already used!";
            return false;
        }
        return false;
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

    public void connection()
    {
        connectionString = "Server = 127.0.0.1 ; Database = hopedb ; User = Hope; Password = QTxdhGkPGLO5eRUW; Charset = utf8;";
        MS_Connection = new MySqlConnection(connectionString);
        MS_Connection.Open();
    }

    public void changeCanvas()
    {

        signUpCanvas.gameObject.SetActive(false);
        loginCanvas.gameObject.SetActive(true);

    }
}
