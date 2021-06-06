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

            if(flag == null) return false;
            // create sql connection object.  Be sure to put a valid connection string
            SqlConnection Con = new SqlConnection("Server=.;Database=LI4_Project;Trusted_Connection=True;"); 
            SqlCommand Cmd = new SqlCommand("INSERT INTO Utilizador " +
				"(UserID,PrimeiroNome,UltimoNome,Username,Password,Email,Experiencia,CapacidadeMonetaria,AreaInteresse,CoordX,CoordY) " +
                "VALUES(@UserID, @PrimeiroNome, @UltimoNome, @Username, @Password, @Email, @Experiencia, @CapacidadeMonetaria, @AreaInteresse,@CoordX,@CoordY)", Con);

            Cmd.Parameters.Add("@UserID", System.Data.SqlDbType.Int);
            Cmd.Parameters.Add("@PrimeiroNome", System.Data.SqlDbType.Text);
            Cmd.Parameters.Add("@UltimoNome", System.Data.SqlDbType.Text);
            Cmd.Parameters.Add("@Username", System.Data.SqlDbType.Text);
            Cmd.Parameters.Add("@Password", System.Data.SqlDbType.Text);
            Cmd.Parameters.Add("@Email", System.Data.SqlDbType.Text);
            Cmd.Parameters.Add("@Experiencia", System.Data.SqlDbType.Int);
            Cmd.Parameters.Add("@CapacidadeMonetaria", System.Data.SqlDbType.Float);
            Cmd.Parameters.Add("@AreaInteresse", System.Data.SqlDbType.Text);
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
            Cmd.Parameters["@AreaInteresse"].Value = u.areaInteresse;
            Cmd.Parameters["@CoordX"].Value = u.coordX;
            Cmd.Parameters["@CoordY"].Value = u.coordY;

            Con.Open();

            int RowsAffected = Cmd.ExecuteNonQuery();

            Con.Close();

            return Convert.ToBoolean(RowsAffected);
    	}

        public Utilizador get(int userID) {
            SqlConnection Con = new SqlConnection("Server=.;Database=LI4_Project;Trusted_Connection=True;");
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
                u.experiencia = reader.GetInt32("Experiencia");
                u.capacidadeMonetaria = reader.GetFloat("CapacidadeMonetaria");
                u.areaInteresse = reader["AreaInteresse"].ToString();
                u.coordX = reader.GetFloat("CoordX");
                u.coordY = reader.GetFloat("CoordY");
            }
            else {
                u = null;
            }
            Con.Close();

            return u;
        }

        public bool login(string user,string pass) {
            SqlConnection Con = new SqlConnection("Server=.;Database=LI4_Project;Trusted_Connection=True;");
            // create command object with SQL query and link to connection object
            SqlCommand Cmd = new SqlCommand("SELECT Username, Password FROM Utilizador WHERE Username = @Username AND Password = @Password", Con);

            Con.Open();
            Cmd.Parameters.Add("@Username", System.Data.SqlDbType.Text);
            Cmd.Parameters["@Username"].Value = user;
            Cmd.Parameters.Add("@Password", System.Data.SqlDbType.Text);
            Cmd.Parameters["@Password"].Value = pass;

            SqlDataReader reader = Cmd.ExecuteReader();

            Con.Close();

            return reader.Read();     
        }

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
                historico.add(reader["Nome"].ToString());
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
                favoritos.add(reader["Nome"].ToString());
            }

            Con.Close();

            return favoritos;
        }






    }
}