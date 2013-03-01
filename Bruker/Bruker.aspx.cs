using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;

using System.Data.SqlClient;
using System.Configuration;

public partial class Default2 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        
        string userIDstring = Membership.GetUser().ProviderUserKey.ToString();

        SqlConnection MyConnection;
        SqlCommand MyCommand;

        MyConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);
        string query = @"
            SELECT [Sport].Sport, [Users].UserName 
            FROM [UserInSport],[Users],[Sport]
            WHERE [Users].UserId = [UserInSport].UserID AND [Sport].Id = [UserInSport].SportID
            ORDER BY [Sport].Sport, [Users].UserName";

        MyCommand = new SqlCommand(query, MyConnection);
        MyCommand.Parameters.Add(new SqlParameter("@userid", userIDstring));

        MyConnection.Open();

        //Funker ikke nå 

        SqlDataReader reader = MyCommand.ExecuteReader();

        string sportOutString;
        string sportName;
        string memberName;
        string previousSport = null;
        lblOutput.Text = "";

        while (reader.Read())
        {
            sportName = (string)reader["Sport"];
            memberName = (string)reader["UserName"];
            sportOutString = (sportName == previousSport)? "": "<br /><h3>" + sportName + "</h3>";

            lblOutput.Text += sportOutString + " - " + memberName + "<br />";

            previousSport = sportName;
        }


        MyConnection.Close();

        MyCommand.Dispose();
        MyConnection.Dispose();  
    }
}