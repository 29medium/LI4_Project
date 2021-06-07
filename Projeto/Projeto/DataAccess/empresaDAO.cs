using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Projeto.Models;
using Projeto.DataAccess;
using Microsoft.Data.SqlClient;
using System.Data;

namespace Projeto.DataAccess
{
    public class EmpresaDAO
    {
        public bool Insert(Empresa e)
        {
            // create sql connection object.  Be sure to put a valid connection Text
            SqlConnection Con = new SqlConnection("Server=.;Database=LI4_Project;Trusted_Connection=True;");
            // create command object with SQL query and link to connection object
            SqlCommand Cmd = new SqlCommand("INSERT INTO Empresa " +
                "(EmpresaID,Nome,Categoria,Website,CoordX,CoordY,MercadoID) " +
                "VALUES(@EmpresaID, @Nome, @Categoria,@Website, @CoordX, @CoordY, @MercadoID)", Con);

            // create your parameters
            Cmd.Parameters.Add("@EmpresaID", System.Data.SqlDbType.Int);
            Cmd.Parameters.Add("@Nome", System.Data.SqlDbType.Text);
            Cmd.Parameters.Add("@Categoria", System.Data.SqlDbType.Text);
            Cmd.Parameters.Add("@Website", System.Data.SqlDbType.Text);
            Cmd.Parameters.Add("@CoordX", System.Data.SqlDbType.Float);
            Cmd.Parameters.Add("@CoordY", System.Data.SqlDbType.Float);
            Cmd.Parameters.Add("@MercadoID", System.Data.SqlDbType.Int);


            // set values to parameters from textboxes
            Cmd.Parameters["@EmpresaID"].Value = e.empresaID;
            Cmd.Parameters["@Nome"].Value = e.nome;
            Cmd.Parameters["@Categoria"].Value = e.categoria;
            Cmd.Parameters["@Website"].Value = e.categoria;
            Cmd.Parameters["@CoordX"].Value = e.coordX;
            Cmd.Parameters["@CoordY"].Value = e.coordY;
            Cmd.Parameters["@MercadoID"].Value = e.mercadoID;

            Con.Open();

            //execute the query and return number of rows affected, should be one
            int RowsAffected = Cmd.ExecuteNonQuery();

            Con.Close();

            return Convert.ToBoolean(RowsAffected);
        }

        public Empresa get(int empresaID)
        {
            SqlConnection Con = new SqlConnection("Server=.;Database=LI4_Project;Trusted_Connection=True;");
            // create command object with SQL query and link to connection object
            SqlCommand Cmd = new SqlCommand("SELECT * FROM Empresa WHERE EmpresaID = @EmpresaID", Con);

            Con.Open();
            Cmd.Parameters.Add("@EmpresaID", System.Data.SqlDbType.Int);
            Cmd.Parameters["@EmpresaID"].Value = empresaID;

            Empresa e = new Empresa();

            SqlDataReader reader = Cmd.ExecuteReader();
            if (reader.Read())
            {
                e.empresaID = empresaID;
                e.nome = reader["Nome"].ToString();
                e.categoria = reader["Categoria"].ToString();
                e.coordX = reader.GetFloat("CoordX");
                e.coordY = reader.GetFloat("CoordY");
                e.mercadoID = reader.GetInt32("MercadoID");
                e.website = reader["Website"].ToString();
            }
            else
            {
                e = null;
            }
            Con.Close();

            return e;
        }

        public List<String> listaEmpresas()
        {
            List<String> empresas = new List<String>();
            SqlConnection Con = new SqlConnection("Server=.;Database=LI4_Project;Trusted_Connection=True;");
            // create command object with SQL query and link to connection object
            SqlCommand Cmd = new SqlCommand("SELECT Nome FROM Empresa", Con);

            Con.Open();

            SqlDataReader reader = Cmd.ExecuteReader();
            while (reader.Read())
            {
                empresas.Add(reader["Nome"].ToString());
            }

            Con.Close();

            return empresas;
        }

        public List<String> listaEmpresasMercado(int mercado)
        {
            List<String> empresas = new List<String>();
            SqlConnection Con = new SqlConnection("MyConnectionString");
            // create command object with SQL query and link to connection object
            SqlCommand Cmd = new SqlCommand("SELECT Nome FROM Empresa WHERE mercadoID = @mercadoID", Con);

            Cmd.Parameters.Add("@MercadoID", System.Data.SqlDbType.Int);
            Cmd.Parameters["@MercadoID"].Value = mercado;

            Con.Open();

            SqlDataReader reader = Cmd.ExecuteReader();
            while (reader.Read())
            {
                empresas.Add(reader["Nome"].ToString());
            }

            Con.Close();

            return empresas;
        }

        public List<String> listaEmpresasMercado(string cat)
        {
            List<String> empresas = new List<String>();
            SqlConnection Con = new SqlConnection("MyConnectionString");
            // create command object with SQL query and link to connection object
            SqlCommand Cmd = new SqlCommand("SELECT Nome FROM Empresa WHERE categoria = @categoria", Con);

            Cmd.Parameters.Add("@Categoria", System.Data.SqlDbType.Text);
            Cmd.Parameters["@Categoria"].Value = cat;

            Con.Open();

            SqlDataReader reader = Cmd.ExecuteReader();
            while (reader.Read())
            {
                empresas.Add(reader["Nome"].ToString());
            }

            Con.Close();

            return empresas;
        }
    }
}
