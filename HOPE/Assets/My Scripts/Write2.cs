using UnityEngine;
using UnityEngine.UI;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class Write2 : MonoBehaviour
{
  
    public Text ID;
    public Text IDmessage;
    public Canvas loginCanvas;
    public Canvas signUpCanvas;
    private string connectionString;
    public MySqlConnection MS_Connection;
    public MySqlCommand MS_Command;
    string query;
    public Button signUpButton;
    public bool isLogin = false;

 public void start()
    {
        signUpButton = GetComponent<Button>();
        signUpButton.onClick.AddListener(changeCanvas);
    }

    public void sendInfo()
    {
 
        connection();

       
        if (ID.text.ToString() == "" )
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
        else { IDmessage.text = ""; }
        if (long.Parse(ID.text) % 2 != 0 || ID.text.ToString().Length != 11)
        {
            IDmessage.text = "not a valid ID!";
            return;
        }

        query = "SELECT ID FROM MyTable";

        MS_Command  = new MySqlCommand(query, MS_Connection);
      

        if (takeID())
        {
            IDmessage.text = "";
            loginCanvas.gameObject.SetActive(false);
        }
        else
        {
            loginCanvas.gameObject.SetActive(true);
        }




    }
    public bool takeID()
    {
        try
        {
            MySqlDataReader reader = MS_Command.ExecuteReader();
            List<long> ids = new List<long>();
            while (reader.Read())
            {
                long id = reader.GetInt64(0);
                ids.Add(id); 
            }
            reader.Close();   
            MS_Connection.Close();
            long kidID = long.Parse(ID.text.ToString());
            foreach(long id in ids)
            {
                if (kidID == id)
                {
                    SceneManager.LoadScene(1);
                    return true;
                    
                }
                  
            }
            IDmessage.text = "Please sign up!";
            return false; 
        }
        catch (Exception e)
        {
            IDmessage.text = "Cannot connect to server!";
            return false;
        }
        return false;
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

    public void connection()
    {
        connectionString = "Server = 127.0.0.1 ; Database = hopedb ; User = Hope; Password = QTxdhGkPGLO5eRUW; Charset = utf8;";
        MS_Connection = new MySqlConnection(connectionString);
        MS_Connection.Open();
    }
}
