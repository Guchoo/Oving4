﻿using System;
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

    }
    protected void CheckBoxList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        
    }
    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        string SelectedUser = DropDownList1.SelectedValue;
        Ut.Text = SelectedUser;
        check(SelectedUser);
    }
    public void check(string SelectedUser)
    {
        try
        {
            // Les spørring som lister alle sport som SelectedUser er med i




            SqlConnection MyConnection;
            SqlCommand MyCommand;
            SqlDataAdapter MyAdapter;
            DataTable MyTable;

            MyConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);
            string query = @"
            select Sport.Id,Sport, case when UserInSport.UserID is null then '0' else '1' end as active from Sport 
            full join UserInSport 
            on Sport.Id = UserInSport.SportID
            where UserInSport.UserID = @userid"; // Nice tips: @ på start

            MyCommand = new SqlCommand(query, MyConnection);
            MyCommand.Parameters.Add(new SqlParameter("@userid", DropDownList1.SelectedValue));

            MyConnection.Open();
            SqlDataReader reader = MyCommand.ExecuteReader();
            MyConnection.Close();
            MyTable = new DataTable();
            MyTable.Load(reader);


            MyAdapter = new SqlDataAdapter();
            MyAdapter.SelectCommand = MyCommand;
            MyAdapter.Fill(MyTable);

            //GridView1.DataSource = MyTable.DefaultView;
            //GridView1.DataBind();

            MyAdapter.Dispose();
            MyCommand.Dispose();
            MyConnection.Dispose();





            // Loop gjennom hver av dem og sett tilhørende checkbox checked=true

            // Ferdig
            if (true)
            {

            }
        }
        catch { }
    }
}