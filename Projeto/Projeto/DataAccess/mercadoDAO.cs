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
    public class MercadoDAO
    {
    	public bool Insert(Mercado m) {
    		// create sql connection object.  Be sure to put a valid connection string
            SqlConnection Con = new SqlConnection("Server=.;Database=LI4_Project;Trusted_Connection=True;");
            SqlCommand Cmd = new SqlCommand("INSERT INTO Mercado " +
				"(MercadoID,Pais,Nome) " +
                "VALUES(@MercadoID, @Pais, @Nome)", Con);

            Cmd.Parameters.Add("@MercadoID", System.Data.SqlDbType.Int);
            Cmd.Parameters.Add("@Pais", System.Data.SqlDbType.Text);
            Cmd.Parameters.Add("@Nome", System.Data.SqlDbType.Text);

            Cmd.Parameters["@MercadoID"].Value = m.mercadoID;
            Cmd.Parameters["@Pais"].Value = m.pais;
            Cmd.Parameters["@Nome"].Value = m.nome;

            Con.Open();

            int RowsAffected = Cmd.ExecuteNonQuery();

            Con.Close();

            return Convert.ToBoolean(RowsAffected);
    	}

        public Mercado get(int mercadoID) {
            SqlConnection Con = new SqlConnection("Server=.;Database=LI4_Project;Trusted_Connection=True;");
            SqlCommand Cmd = new SqlCommand("SELECT * FROM Mercado WHERE MercadoID = @MercadoID", Con);

            Con.Open();
            Cmd.Parameters.Add("@MercadoID", System.Data.SqlDbType.Int);
            Cmd.Parameters["@MercadoID"].Value = mercadoID;

            Mercado m = new Mercado();

            SqlDataReader reader = Cmd.ExecuteReader();
            if(reader.Read()){
                m.mercadoID = mercadoID;
                m.nome = reader["Nome"].ToString();
                m.pais = reader["Pais"].ToString();
            }
            else {
                m = null;
            }
            Con.Close();

            return m;
        }
    }
}