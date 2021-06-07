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
				"(codigo,pais,nome) " +
                "VALUES(@codigo, @pais, @nome)", Con);

            Cmd.Parameters.Add("@codigo", System.Data.SqlDbType.VarChar);
            Cmd.Parameters.Add("@pais", System.Data.SqlDbType.VarChar);
            Cmd.Parameters.Add("@nome", System.Data.SqlDbType.VarChar);

            Cmd.Parameters["@codigo"].Value = m.mercadoID;
            Cmd.Parameters["@pais"].Value = m.pais;
            Cmd.Parameters["@nome"].Value = m.nome;

            Con.Open();

            int RowsAffected = Cmd.ExecuteNonQuery();

            Con.Close();

            return Convert.ToBoolean(RowsAffected);
    	}

        public Mercado get(string mercadoID) {
            SqlConnection Con = new SqlConnection("Server=.;Database=LI4_Project;Trusted_Connection=True;");
            SqlCommand Cmd = new SqlCommand("SELECT * FROM Mercado WHERE codigo = @codigo", Con);

            Con.Open();
            Cmd.Parameters.Add("@codigo", System.Data.SqlDbType.VarChar);
            Cmd.Parameters["@codigo"].Value = mercadoID;

            Mercado m = new Mercado();

            SqlDataReader reader = Cmd.ExecuteReader();
            if(reader.Read()){
                m.mercadoID = mercadoID;
                m.nome = reader["nome"].ToString();
                m.pais = reader["pais"].ToString();
            }
            else {
                m = null;
            }
            Con.Close();

            return m;
        }

        public List<Mercado> listaMercado()
        {
            List<Mercado> mercados = new List<Mercado>();
            SqlConnection Con = new SqlConnection("Server=.;Database=LI4_Project;Trusted_Connection=True;");
            // create command object with SQL query and link to connection object
            SqlCommand Cmd = new SqlCommand("SELECT * FROM Mercado", Con);

            Con.Open();

            SqlDataReader reader = Cmd.ExecuteReader();
            while (reader.Read())
            {
                Mercado m = new Mercado();

                m.mercadoID = reader["codigo"].ToString();
                m.nome = reader["nome"].ToString();
                m.pais = reader["pais"].ToString();

                mercados.Add(m);
            }

            Con.Close();

            return mercados;
        }
    }
}