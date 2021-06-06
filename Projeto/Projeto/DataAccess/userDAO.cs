using System;
using SmartInvest.Models;
using SmartInvest.DataAccess;
using System.Data.SqlClient;
using System.Data;
using System.Collections.Generic;
using System.Text;
using System.Linq;


namespace SmartInvest.DataAccess
{
    public class UserDAO
    {
    	public bool Insert(Utilizador u) {

            Utilizador flag = get(u.userID);

            if(flag) return false;
    		// create sql connection object.  Be sure to put a valid connection string
            SqlConnection Con = new SqlConnection("MyConnectionString");
            SqlCommand Cmd = new SqlCommand("INSERT INTO Utilizador " +
				"(UserID,PrimeiroNome,UltimoNome,Username,Password,Email,Experiencia,CapacidadeMonetaria,AreaInteresse,CoordX,CoordY) " +
                "VALUES(@UserID, @PrimeiroNome, @UltimoNome, @Username, @Password, @Email, @Experiencia, @CapacidadeMonetaria, @AreaInteresse,@CoordX,@CoordY)", Con);

            Cmd.Parameters.Add("@UserID", System.Data.SqlDbType.Int);
            Cmd.Parameters.Add("@PrimeiroNome", System.Data.SqlDbType.String);
            Cmd.Parameters.Add("@UltimoNome", System.Data.SqlDbType.String);
            Cmd.Parameters.Add("@Username", System.Data.SqlDbType.String);
            Cmd.Parameters.Add("@Password", System.Data.SqlDbType.String);
            Cmd.Parameters.Add("@Email", System.Data.SqlDbType.String);
            Cmd.Parameters.Add("@Experiencia", System.Data.SqlDbType.Int);
            Cmd.Parameters.Add("@CapacidadeMonetaria", System.Data.SqlDbType.Float);
            Cmd.Parameters.Add("@AreaInteresse", System.Data.SqlDbType.String);
            Cmd.Parameters.Add("@CoordX", System.Data.SqlDbType.Float);
            Cmd.Parameters.Add("@CoordY", System.Data.SqlDbType.Float);

            Cmd.Parameters["@UserID"].Value = u.userID;
            Cmd.Parameters["@PrimeiroNome"].Value = u.primeiroNome;
            Cmd.Parameters["@UltimoNome"].Value = u.ultimoNome;
            Cmd.Parameters["@Username"].Value = u.username;
            Cmd.Parameters["@Password"].Value = u.password;
            Cmd.Parameters["@Email"].Value = u.email;
            Cmd.Parameters["@Experiencia"].Value = u.experiencia;
            Cmd.Parameters["@CapacidadeMonetaria"].Value = u.capacidadeMonetaria;
            Cmd.Parameters["@AreaInteresse"].Value = u.areasInteresse;
            Cmd.Parameters["@CoordX"].Value = u.coordX;
            Cmd.Parameters["@CoordY"].Value = u.coordY;

            Con.Open();

            int RowsAffected = Cmd.ExecuteNonQuery();

            Con.Close();

            return RowsAffected;
    	}

        public Utilizador get(int userID) {
            SqlConnection Con = new SqlConnection("MyConnectionString");
            // create command object with SQL query and link to connection object
            SqlCommand Cmd = new SqlCommand("SELECT * FROM Utilizador WHERE UserID = @UserID", Con);

            Con.Open();
            Cmd.Parameters.Add("@UserID", System.Data.SqlDbType.Int);
            Cmd.Parameters["@UserID"].Value = userID;

            Utilizador u = new Utilizador();

            SqlDataReader reader = Cmd.ExecuteReader();
            if(reader.Read()){
                u.userID = userID;
                u.primeiroNome = reader["PrimeiroNome"].ToString();
                u.ultimoNome = reader["UltimoNome"].ToString();
                u.username = reader["Username"].ToString();
                u.password = reader["Password"].ToString();
                u.email = reader["Email"].ToString();
                u.experiencia = reader["Experiencia"].ToInt();
                u.capacidadeMonetaria = reader["CapacidadeMonetaria"].ToFloat();
                u.areasInteresse = reader["AreaInteresse"].ToString();
                u.coordX = reader["CoordX"].ToFloat();
                u.coordY = reader["CoordY"].ToFloat();
            }
            else {
                u = null;
            }
            Con.Close();

            return u;
        }

        public bool login(string user,string pass) {
            SqlConnection Con = new SqlConnection("MyConnectionString");
            // create command object with SQL query and link to connection object
            SqlCommand Cmd = new SqlCommand("SELECT Username, Password FROM Utilizador WHERE Username = @Username AND Password = @Password", Con);

            Con.Open();
            Cmd.Parameters.Add("@Username", System.Data.SqlDbType.String);
            Cmd.Parameters["@Username"].Value = user;
            Cmd.Parameters.Add("@Password", System.Data.SqlDbType.String);
            Cmd.Parameters["@Password"].Value = pass;

            SqlDataReader reader = Cmd.ExecuteReader();

            Con.Close();

            return reader.Read();     
        }

        public bool adicionaHistorico(int userID,string hist) {

            SqlConnection Con = new SqlConnection("MyConnectionString");
            // create command object with SQL query and link to connection object
            SqlCommand Cmd = new SqlCommand("INSERT INTO Historico " +
                "(UserID,Pesquisa) " +
                "VALUES(@UserID, @Pesquisa)", Con);

            Cmd.Parameters.Add("@UserID", System.Data.SqlDbType.Int);
            Cmd.Parameters.Add("@Pesquisa", System.Data.SqlDbType.String);
            Cmd.Parameters["@UserID"].Value = userID;
            Cmd.Parameters["@Pesquisa"].Value = hist;

            Con.Open();

            int RowsAffected = Cmd.ExecuteNonQuery();

            Con.Close();

            return RowsAffected;
        }

        public bool adicionaPreferencia(int userID,string pref) {

            SqlConnection Con = new SqlConnection("MyConnectionString");
            // create command object with SQL query and link to connection object
            SqlCommand Cmd = new SqlCommand("INSERT INTO Favoritos " +
                "(UserID,EmpresaID) " +
                "VALUES(@UserID, @EmpresaID)", Con);

            Cmd.Parameters.Add("@UserID", System.Data.SqlDbType.Int);
            Cmd.Parameters.Add("@EmpresaID", System.Data.SqlDbType.String);
            Cmd.Parameters["@UserID"].Value = userID;
            Cmd.Parameters["@EmpresaID"].Value = hist;

            Con.Open();

            int RowsAffected = Cmd.ExecuteNonQuery();

            Con.Close();

            return RowsAffected;
        }

        






    }
}