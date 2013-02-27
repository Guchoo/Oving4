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
        string UserID = Request.QueryString["UID"];  // What is this? - Thomas

        string userIDstring = Membership.GetUser().ProviderUserKey.ToString();

        SqlConnection MyConnection;
        SqlCommand MyCommand;

        MyConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);
        string query = @"
            select Sport.Id,Sport from Sport 
            where Sport.Id = UserInSport.SportID AND UserInSport.UserID = @userid";

        MyCommand = new SqlCommand(query, MyConnection);
        MyCommand.Parameters.Add(new SqlParameter("@userid", userIDstring));

        MyConnection.Open();

        //Funker ikke nå 

        //SqlDataReader reader = MyCommand.ExecuteReader();



//        while (reader.Read())
//        {
//            int sportId = (int)reader["Id"];
//            string sportName = (string)reader["Sport"];

            
//        }


//        MyConnection.Close();

//        MyCommand.Dispose();
//        MyConnection.Dispose();  
    }
}