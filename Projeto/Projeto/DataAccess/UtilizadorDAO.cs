using System;
using Projeto.Models;
using Projeto.DataAccess;
using System.Data.SqlClient;
using System.Data;
using System.Collections.Generic;
using System.Text;
using System.Linq;


namespace Projeto.DataAccess
{
    public class UtilizadorDAO
    {
    	public bool Insert(Utilizador u) {

            Utilizador flag = get(u.userID);

            if(flag == null)
                return false;

            // create sql connection object.  Be sure to put a valid connection string
            SqlConnection Con = new SqlConnection("Server=.;Database=LI4_Project;Trusted_Connection=True;"); 
            SqlCommand Cmd = new SqlCommand("INSERT INTO Utilizador " +
				"(primeiro_nome,ultimo_nome,user_name,password,email,experiencia,capacidade,localizacao) " +
                "VALUES(@primeiro_nome, @ultimo_nome, @user_name, @password, @email, @experiencia, @capacidade, @localizacao)", Con);

            Cmd.Parameters.Add("@primeiro_nome", System.Data.SqlDbType.VarChar);
            Cmd.Parameters.Add("@ultimo_nome", System.Data.SqlDbType.VarChar);
            Cmd.Parameters.Add("@user_name", System.Data.SqlDbType.VarChar);
            Cmd.Parameters.Add("@password", System.Data.SqlDbType.VarChar);
            Cmd.Parameters.Add("@email", System.Data.SqlDbType.VarChar);
            Cmd.Parameters.Add("@experiencia", System.Data.SqlDbType.Int);
            Cmd.Parameters.Add("@capacidade", System.Data.SqlDbType.Float);
            Cmd.Parameters.Add("@localizacao", System.Data.SqlDbType.VarChar);

            Cmd.Parameters["@primeiro_nome"].Value = u.primeiroNome;
            Cmd.Parameters["@ultimo_nome"].Value = u.ultimoNome;
            Cmd.Parameters["@user_name"].Value = u.username;
            Cmd.Parameters["@password"].Value = u.password;
            Cmd.Parameters["@email"].Value = u.email;
            Cmd.Parameters["@experiencia"].Value = u.experiencia;
            Cmd.Parameters["@capacidade"].Value = u.capacidadeMonetaria;
            Cmd.Parameters["@localizacao"].Value = u.localizacao;

            Console.WriteLine("Cheguei aqui");

            Con.Open();

            int RowsAffected = Cmd.ExecuteNonQuery();

            Con.Close();

            return Convert.ToBoolean(RowsAffected);
    	}

        public Utilizador get(int userID) {
            SqlConnection Con = new SqlConnection("Server=.;Database=LI4_Project;Trusted_Connection=True;");
            // create command object with SQL query and link to connection object
            SqlCommand Cmd = new SqlCommand("SELECT * FROM Utilizador WHERE user_name = @user_name", Con);

            Con.Open();
            Cmd.Parameters.Add("@user_name", System.Data.SqlDbType.Int);
            Cmd.Parameters["@user_name"].Value = userID;

            Utilizador u = new Utilizador();

            SqlDataReader reader = Cmd.ExecuteReader();
            if(reader.Read()){
                u.userID = reader.GetInt32("userID");
                u.primeiroNome = reader["primeiro_nome"].ToString();
                u.ultimoNome = reader["ultimo_nome"].ToString();
                u.username = reader["user_name"].ToString();
                u.password = reader["password"].ToString();
                u.email = reader["email"].ToString();
                u.experiencia = reader.GetInt32("experiencia");
                u.capacidadeMonetaria = reader.GetFloat("capacidade");
                u.localizacao = reader["localizacao"].ToString();
            }
            else {
                u = null;
            }
            Con.Close();

            return u;
        }

        public bool Login(string user,string pass) {
            SqlConnection Con = new SqlConnection("Server=.;Database=LI4_Project;Trusted_Connection=True;");
            // create command object with SQL query and link to connection object
            SqlCommand Cmd = new SqlCommand("SELECT user_name, password FROM[Utilizador] WHERE user_name = @user_name AND password = @password", Con);

            Con.Open();
            Cmd.Parameters.Add("@user_name", System.Data.SqlDbType.VarChar);
            Cmd.Parameters["@user_name"].Value = user;
            Cmd.Parameters.Add("@password", System.Data.SqlDbType.VarChar);
            Cmd.Parameters["@password"].Value = pass;

            SqlDataReader reader = Cmd.ExecuteReader();

            bool res = reader.Read();

            Con.Close();

            return res;     
        }
        /*
        public bool adicionaHistorico(int userID,string hist) {

            SqlConnection Con = new SqlConnection("Server=.;Database=LI4_Project;Trusted_Connection=True;");
            // create command object with SQL query and link to connection object
            SqlCommand Cmd = new SqlCommand("INSERT INTO Historico " +
                "(UserID,Pesquisa) " +
                "VALUES(@UserID, @Pesquisa)", Con);

            Cmd.Parameters.Add("@UserID", System.Data.SqlDbType.Int);
            Cmd.Parameters.Add("@Pesquisa", System.Data.SqlDbType.Text);
            Cmd.Parameters["@UserID"].Value = userID;
            Cmd.Parameters["@Pesquisa"].Value = hist;

            Con.Open();

            int RowsAffected = Cmd.ExecuteNonQuery();

            Con.Close();

            return Convert.ToBoolean(RowsAffected);
        }
        

        public bool adicionaPreferencia(int userID,string pref) {

            SqlConnection Con = new SqlConnection("Server=.;Database=LI4_Project;Trusted_Connection=True;");
            // create command object with SQL query and link to connection object
            SqlCommand Cmd = new SqlCommand("INSERT INTO Favoritos " +
                "(UserID,EmpresaID) " +
                "VALUES(@UserID, @EmpresaID)", Con);

            Cmd.Parameters.Add("@UserID", System.Data.SqlDbType.Int);
            Cmd.Parameters.Add("@EmpresaID", System.Data.SqlDbType.Text);
            Cmd.Parameters["@UserID"].Value = userID;
            Cmd.Parameters["@EmpresaID"].Value = pref;

            Con.Open();

            int RowsAffected = Cmd.ExecuteNonQuery();

            Con.Close();

            return Convert.ToBoolean(RowsAffected);
        }

        public List<String> Historico(int userID) {
            List<String> historico = new List<String>();
            SqlConnection Con = new SqlConnection("Server=.;Database=LI4_Project;Trusted_Connection=True;");
            // create command object with SQL query and link to connection object
            SqlCommand Cmd = new SqlCommand("SELECT Empresa.Nome FROM Historico WHERE UserID = @UserID" + 
                                            " INNER JOIN Empresa WHERE Empresa.EmpresaID = Historico.EmpresaID", Con);


            Cmd.Parameters.Add("@UserID", System.Data.SqlDbType.Int);
            Cmd.Parameters["@UserID"].Value = userID;
            Con.Open();

            SqlDataReader reader = Cmd.ExecuteReader();
            while(reader.Read()){
                historico.Add(reader["Nome"].ToString());
            }

            Con.Close();

            return historico;
        }

        public List<String> Favoritos(int userID) {
            List<String> favoritos = new List<String>();
            SqlConnection Con = new SqlConnection("Server=.;Database=LI4_Project;Trusted_Connection=True;");
            // create command object with SQL query and link to connection object
            SqlCommand Cmd = new SqlCommand("SELECT Empresa.Nome FROM Favoritos WHERE UserID = @UserID" + 
                                            " INNER JOIN Empresa WHERE Empresa.EmpresaID = Historico.EmpresaID", Con);

            Cmd.Parameters.Add("@UserID", System.Data.SqlDbType.Int);
            Cmd.Parameters["@UserID"].Value = userID;
            
            Con.Open();

            SqlDataReader reader = Cmd.ExecuteReader();
            while(reader.Read()){
                favoritos.Add(reader["Nome"].ToString());
            }

            Con.Close();

            return favoritos;
        }

        */
    }
}