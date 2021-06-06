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
    public class EmpresaDAO
    {
    	public bool Insert(Empresa e) {
    		// create sql connection object.  Be sure to put a valid connection string
            SqlConnection Con = new SqlConnection("MyConnectionString");
            // create command object with SQL query and link to connection object
            SqlCommand Cmd = new SqlCommand("INSERT INTO Empresa " +
				"(EmpresaID,Nome,Categoria,Website,CoordX,CoordY,MercadoID) " +
                "VALUES(@EmpresaID, @Nome, @Categoria,@Website, @CoordX, @CoordY, @MercadoID)", Con);

            // create your parameters
            Cmd.Parameters.Add("@EmpresaID", System.Data.SqlDbType.Int);
            Cmd.Parameters.Add("@Nome", System.Data.SqlDbType.String);
            Cmd.Parameters.Add("@Categoria", System.Data.SqlDbType.String);
            Cmd.Parameters.Add("@Website", System.Data.SqlDbType.String);
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
    	}

        public Empresa get(int empresaID) {
            SqlConnection Con = new SqlConnection("MyConnectionString");
            // create command object with SQL query and link to connection object
            SqlCommand Cmd = new SqlCommand("SELECT * FROM Empresa WHERE EmpresaID = @EmpresaID", Con);

            Con.Open();
            Cmd.Parameters.Add("@EmpresaID", System.Data.SqlDbType.Int);
            Cmd.Parameters["@EmpresaID"].Value = empresaID;

            Empresa e = new Empresa();

            SqlDataReader reader = Cmd.ExecuteReader();
            if(reader.Read()){
                e.empresaID = empresaID;
                e.nome = reader["Nome"].ToString();
                e.categoria = reader["Categoria"].ToString();
                e.coordX = reader["CoordX"].ToFloat();
                e.coordY = reader["CoordY"].ToFloat();
                e.mercadoID = reader["MercadoID"].ToInt();
                e.website = reader["Website"].ToString();
            }
            else {
                e = null;
            }
            Con.Close();

            return e;
        }

        public List<Empresa> listaEmpresas() {
            List<Empresa> empresas = new List<Empresa>();
            SqlConnection Con = new SqlConnection("MyConnectionString");
            // create command object with SQL query and link to connection object
            SqlCommand Cmd = new SqlCommand("SELECT * FROM Empresa", Con);

            Con.Open();

            SqlDataReader reader = Cmd.ExecuteReader();
            while(reader.Read()){
                Empresa e = new Empresa();
                e.empresaID = reader["EmpresaID"].ToInt();;
                e.nome = reader["Nome"].ToString();
                e.categoria = reader["Categoria"].ToString();
                e.coordX = reader["CoordX"].ToFloat();
                e.coordY = reader["CoordY"].ToFloat();
                e.mercadoID = reader["MercadoID"].ToInt();
                e.website = reader["Website"].ToString();

                empresas.add(e);
            }

            Con.Close();

            return empresas;
        }
    }
}