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
                "(empresa_id,nome,categoria,website,localizacao,mercado_codigo) " +
                "VALUES(@empresa_id, @nome, @categoria,@website, @localizacao, @mercado_codigo)", Con);

            // create your parameters
            Cmd.Parameters.Add("@empresa_id", System.Data.SqlDbType.VarChar);
            Cmd.Parameters.Add("@nome", System.Data.SqlDbType.VarChar);
            Cmd.Parameters.Add("@categoria", System.Data.SqlDbType.VarChar);
            Cmd.Parameters.Add("@website", System.Data.SqlDbType.VarChar);
            Cmd.Parameters.Add("@localizacao", System.Data.SqlDbType.VarChar);
            Cmd.Parameters.Add("@mercado_codigo", System.Data.SqlDbType.VarChar);

            // set values to parameters from textboxes
            Cmd.Parameters["@empresa_id"].Value = e.empresaID;
            Cmd.Parameters["@nome"].Value = e.nome;
            Cmd.Parameters["@categoria"].Value = e.categoria;
            Cmd.Parameters["@website"].Value = e.categoria;
            Cmd.Parameters["@localizacao"].Value = e.localizacao;
            Cmd.Parameters["@mercado_codigo"].Value = e.mercadoID;

            Con.Open();

            //execute the query and return number of rows affected, should be one
            int RowsAffected = Cmd.ExecuteNonQuery();

            Con.Close();

            return Convert.ToBoolean(RowsAffected);
        }

        public Empresa get(string empresaID)
        {
            SqlConnection Con = new SqlConnection("Server=.;Database=LI4_Project;Trusted_Connection=True;");
            // create command object with SQL query and link to connection object
            SqlCommand Cmd = new SqlCommand("SELECT * FROM Empresa WHERE empresa_id = @empresa_id", Con);

            Con.Open();
            Cmd.Parameters.Add("@empresa_id", System.Data.SqlDbType.VarChar);
            Cmd.Parameters["@empresa_id"].Value = empresaID;

            Empresa e = new Empresa();

            SqlDataReader reader = Cmd.ExecuteReader();
            if (reader.Read())
            {
                e.empresaID = empresaID;
                e.nome = reader["nome"].ToString();
                e.categoria = reader["categoria"].ToString();
                e.localizacao = reader["localizacao"].ToString();
                e.mercadoID = reader["mercado_codigo"].ToString();
                e.website = reader["website"].ToString();
            }
            else
            {
                e = null;
            }
            Con.Close();

            return e;
        }

        public List<Empresa> listaEmpresas()
        {
            List<Empresa> empresas = new List<Empresa>();
            SqlConnection Con = new SqlConnection("Server=.;Database=LI4_Project;Trusted_Connection=True;");
            // create command object with SQL query and link to connection object
            SqlCommand Cmd = new SqlCommand("SELECT * FROM Empresa", Con);

            Con.Open();

            SqlDataReader reader = Cmd.ExecuteReader();
            while (reader.Read())
            {
                Empresa e = new Empresa();
                e.empresaID = reader["empresaID"].ToString();

                e.nome = reader["nome"].ToString();
                e.categoria = reader["categoria"].ToString();
                e.localizacao = reader["localizacao"].ToString();
                e.mercadoID = reader["mercado_codigo"].ToString();
                e.website = reader["website"].ToString();

                empresas.Add(e);
            }

            Con.Close();

            return empresas;
        }

        public List<Empresa> listaEmpresasMercado(int mercado)
        {
            List<Empresa> empresas = new List<Empresa>();
            SqlConnection Con = new SqlConnection("MyConnectionString");
            // create command object with SQL query and link to connection object
            SqlCommand Cmd = new SqlCommand("SELECT * FROM Empresa WHERE mercado_codigo = @mercado_codigo", Con);

            Cmd.Parameters.Add("@mercado_codigo", System.Data.SqlDbType.VarChar);
            Cmd.Parameters["@mercado_codigo"].Value = mercado;

            Con.Open();

            SqlDataReader reader = Cmd.ExecuteReader();
            while (reader.Read())
            {
                Empresa e = new Empresa();
                e.empresaID = reader["empresaID"].ToString();
                e.nome = reader["nome"].ToString();
                e.categoria = reader["categoria"].ToString();
                e.localizacao = reader["localizacao"].ToString();
                e.mercadoID = reader["mercado_codigo"].ToString();
                e.website = reader["website"].ToString();

                empresas.Add(e);
            }

            Con.Close();

            return empresas;
        }

        public List<Empresa> listaEmpresasCategoria(string cat)
        {
            List<Empresa> empresas = new List<Empresa>();
            SqlConnection Con = new SqlConnection("MyConnectionString");
            // create command object with SQL query and link to connection object
            SqlCommand Cmd = new SqlCommand("SELECT * FROM Empresa WHERE categoria = @categoria", Con);

            Cmd.Parameters.Add("@categoria", System.Data.SqlDbType.Text);
            Cmd.Parameters["@categoria"].Value = cat;

            Con.Open();

            SqlDataReader reader = Cmd.ExecuteReader();
            while (reader.Read())
            {
                Empresa e = new Empresa();
                e.empresaID = reader["empresaID"].ToString();
                e.nome = reader["nome"].ToString();
                e.categoria = reader["categoria"].ToString();
                e.localizacao = reader["localizacao"].ToString();
                e.mercadoID = reader["mercado_codigo"].ToString();
                e.website = reader["website"].ToString();

                empresas.Add(e);
            }

            Con.Close();

            return empresas;
        }
    }
}
