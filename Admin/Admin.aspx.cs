using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_Admin : System.Web.UI.Page
{
    
    protected void Page_Load(object sender, EventArgs e)
    {
       // check();
    }



    private void EventFunction_SetSportBoxes(object sender, EventArgs e)
    {
        check();
    }

    protected void CheckBoxList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        
    }
    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        check();
    }

    public void check()
    {

        // Les spørring som lister alle sport som SelectedUser er med i




        SqlConnection MyConnection;
        SqlCommand MyCommand;
        SqlDataAdapter MyAdapter;
        DataTable MyTable;

        MyConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);
        string query = @"
            select [Table].Id,Sport, case when UserInSport.UserID is null then '0' else '1' end as active from [Table] 
            full join UserInSport 
            on [Table].Id = UserInSport.SportID
            where UserInSport.UserID = @userid"; // Nice tips: @ på start

        MyCommand = new SqlCommand(query, MyConnection);
        MyCommand.Parameters.Add(new SqlParameter("@userid", DropDownList1.SelectedValue));

        MyConnection.Open();
        SqlDataReader reader = MyCommand.ExecuteReader();
        //MyTable = new DataTable();
        //MyTable.Load(reader);


        CheckBoxList1.ClearSelection();

        while (reader.Read())
        {
            // get the results of each column
            int sportId = (int)reader["Id"];
            string sportName = (string)reader["Sport"];

            CheckBoxList1.Items.FindByValue(sportId.ToString()).Selected = true;

            // print out the results
            // Ut.Text += sportId + sportName;
        }


        MyConnection.Close();

        MyAdapter = new SqlDataAdapter();
        MyAdapter.SelectCommand = MyCommand;
        //MyAdapter.Fill(MyTable);

        //GridView1.DataSource = MyTable.DefaultView;
        //GridView1.DataBind();

        MyAdapter.Dispose();
        MyCommand.Dispose();
        MyConnection.Dispose();  



        
    }


    protected void btnSaveSports_Click(object sender, EventArgs e)
    {
        Ut.Text = "";

        string userIdString = DropDownList1.SelectedValue;

        bool isLinked;
        int sportId;
        string sqlString;
        string sqlExciststInDB;
        SqlCommand command,excistCommand;
        SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);

        connection.Open();

        for (int i = 0; i < CheckBoxList1.Items.Count; i++)
        {
            Int32.TryParse(CheckBoxList1.Items[i].Value, out sportId);

            sqlExciststInDB = "SELECT * FROM [UserInSport] WHERE SportID=@sportID AND UserID=@userID";
            excistCommand = new SqlCommand(sqlExciststInDB, connection);
            excistCommand.Parameters.Add(new SqlParameter("@sportID", CheckBoxList1.Items[i].Value));
            excistCommand.Parameters.Add(new SqlParameter("@userID", userIdString));
            SqlDataReader excistsReader = excistCommand.ExecuteReader();
            isLinked = excistsReader.HasRows;
            excistsReader.Close();
            excistCommand.Dispose();


            if (CheckBoxList1.Items[i].Selected && !isLinked) // Sport is checked and is not in database
            {
                sqlString = @"
                        INSERT INTO [UserInSport] (SportID,UserID) 
                        VALUES (@sportID,@userID)";


                command = new SqlCommand(sqlString, connection);
                command.Parameters.Add(new SqlParameter("@sportID", CheckBoxList1.Items[i].Value));
                command.Parameters.Add(new SqlParameter("@userID", userIdString));
                command.ExecuteNonQuery();

                Ut.Text += command.CommandText + "// " + CheckBoxList1.Items[i].Text + " id:" + CheckBoxList1.Items[i].Value + ", " + userIdString + "<br \\>";
            }
            else if (!CheckBoxList1.Items[i].Selected && isLinked) // Sport is not checked but is in database
            {
                sqlString = @"
                        DELETE FROM [UserInSport] 
                        WHERE SportID=@sportID AND UserID=@userID";

                command = new SqlCommand(sqlString, connection);
                command.Parameters.Add(new SqlParameter("@sportID", CheckBoxList1.Items[i].Value));
                command.Parameters.Add(new SqlParameter("@userID", userIdString));
                command.ExecuteNonQuery();

                Ut.Text += command.CommandText + "// " + CheckBoxList1.Items[i].Text + " id:" + CheckBoxList1.Items[i].Value + "," + userIdString + "<br \\>";
            }

        }

        connection.Close();

    }

    private void InitializeComponent() // adds event functions
    {
        //this.SaveStateComplete += new System.EventHandler(this.EventFunction_SetSportBoxes); // Did not work

    }

}