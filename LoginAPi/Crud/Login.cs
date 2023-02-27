using System.Collections.Generic;
using System.Data;
using System;
using System.Data.SqlClient;
using LoginAPi.Models;
using Microsoft.Win32;
using System.Reflection;

namespace LoginAPi.Crud
{
    public class Login
    {
        SqlConnection connection;
        SqlCommand command;
        string connectionstring = @"Data Source=WIN-PFGV5N8DK24;Initial Catalog=Mekteb;Integrated Security=True";
        public Login()
        {
            connection = new SqlConnection(connectionstring);
        }
        private List<LoginModel> Back_Get()
        {
            List<LoginModel> back_register = new List<LoginModel>();
            string commandstring = "Select * From Login";
            command = new SqlCommand(commandstring, connection);

            if (connection.State != ConnectionState.Open)
            {
                connection.Open();
            }

            SqlDataReader dr = command.ExecuteReader();


            while (dr.Read())
            {
                back_register.Add(new LoginModel
                {
                    E_mail = dr["E_Mail"].ToString(),
                    Password = dr["Password"].ToString()
                });
            }

            if (connection.State == ConnectionState.Open)
            {
                connection.Close();
            }
            return back_register;

        }

        public string CheckLogin(LoginModel model)
        {
            List<LoginModel> Check_Email = new List<LoginModel>();

            Check_Email = Back_Get();

            string reposttext= "";
            if (model.E_mail != null && model.Password != null)
            {
                foreach (var item in Check_Email)
                {
                    if (item.E_mail != model.E_mail)
                    {
                        reposttext = "This email is no longer registered";
                    }
                    else
                    {
                        if (item.Password != model.Password)
                        {
                            reposttext = "Password is not entered correctly";
                        }
                        else
                        {
                            reposttext = "Succesful";  
                            return reposttext;
                        }
                    }
                }
            }
            else
            {
                reposttext = "fill in all the boxes";
            }
            return reposttext;
        }

    }
}
