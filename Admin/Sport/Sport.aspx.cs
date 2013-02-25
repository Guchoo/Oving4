using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Default2 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string SportID = Request.QueryString["SID"];
        if (!IsPostBack)
        {
            try
            {
                SqlConnection MyConnection;
                SqlCommand MyCommand;
                SqlDataAdapter MyAdapter;
                DataTable MyTable;

                MyConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);
                string query =
        @"
SELECT 
    Users.UserName AS Navn, UserInSport.Id AS Id, Users.UserId AS SuperId
FROM 
    UserInSport, Users
WHERE 
    UserInSport.SportID = @SportID
AND
    UserInSport.UserID = Users.UserId";


                MyCommand = new SqlCommand(query, MyConnection);
                MyCommand.Parameters.Add(new SqlParameter("@SportID", SportID));

                MyConnection.Open();
                SqlDataReader reader = MyCommand.ExecuteReader();
                MyConnection.Close();
                MyTable = new DataTable();
                MyTable.Load(reader);


                MyAdapter = new SqlDataAdapter();
                MyAdapter.SelectCommand = MyCommand;
                MyAdapter.Fill(MyTable);

                BrukerListe.DataSource = MyTable.DefaultView;
                BrukerListe.DataBind();

                MyAdapter.Dispose();
                MyCommand.Dispose();
                MyConnection.Dispose();
            }
            catch { }
        }

    }
    protected void BrukerListe_SelectedIndexChanging(object sender, ListViewSelectEventArgs e)
    {
        int id = Convert.ToInt32(BrukerListe.DataKeys[e.NewSelectedIndex].Value);
        Error.Text = "TODO: skal slette id: "+id.ToString() + " i UserInSport tabellen";

        SqlConnection MyConnection;
        SqlCommand MyCommand;
        SqlDataAdapter MyAdapter;
        DataTable MyTable;

        MyConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);

        string query = @"
DELETE FROM UserInSport
 WHERE UserInSport.Id = @ID";


        MyCommand = new SqlCommand(query, MyConnection);
        MyCommand.Parameters.Add(new SqlParameter("@ID", id));

        MyConnection.Open();
        SqlDataReader reader = MyCommand.ExecuteReader();
        MyConnection.Close();
        MyTable = new DataTable();
        MyTable.Load(reader);


        MyAdapter = new SqlDataAdapter();
        MyAdapter.SelectCommand = MyCommand;
        MyAdapter.Fill(MyTable);

        BrukerListe.DataSource = MyTable.DefaultView;
        BrukerListe.DataBind();

        MyAdapter.Dispose();
        MyCommand.Dispose();
        MyConnection.Dispose();
    }
}