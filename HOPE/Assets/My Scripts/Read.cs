using UnityEngine;
using UnityEngine.UI;
using MySql.Data.MySqlClient;

public class Read : MonoBehaviour
{

    private string connectionString;
    string query;
    private MySqlConnection MS_Connection;
    private MySqlCommand MS_Command;
    private MySqlDataReader MS_Reader;
    public Text textCanvas;

    public void viewInfo()
    {

        query = "SELECT * FROM MyTable";

        connectionString = "Server = 127.0.0.1 ; Database = hopedb ; User = Hope; Password = QTxdhGkPGLO5eRUW; Charset = utf8;";

        MS_Connection = new MySqlConnection(connectionString);
        MS_Connection.Open();

        MS_Command = new MySqlCommand(query, MS_Connection);

        MS_Reader = MS_Command.ExecuteReader();
        while (MS_Reader.Read())
        {
            textCanvas.text += "\n              " + MS_Reader[0] + "                            " + MS_Reader[1] + "                     " + MS_Reader[2] + "                    " + MS_Reader[3];
        }
        MS_Reader.Close();

    }

}