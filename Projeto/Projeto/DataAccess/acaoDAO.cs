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
    public class acaoDAO
    {
    	public bool Insert(acao a) {
    		// create sql connection object.  Be sure to put a valid connection string
            SqlConnection Con = new SqlConnection("MyConnectionString");
            // create command object with SQL query and link to connection object
            SqlCommand Cmd = new SqlCommand("INSERT INTO Acao " +
				"(AcaoID,Hora,Low,High,Avg,EmpresaID) " +
                "VALUES(@AcaoID, @Hora, @Low,@High,@Avg,@EmpresaID)", Con);

            // create your parameters
            Cmd.Parameters.Add("@AcaoID", System.Data.SqlDbType.Int);
            Cmd.Parameters.Add("@Hora", System.Data.SqlDbType.DataTime);
            Cmd.Parameters.Add("@Low", System.Data.SqlDbType.Float);
            Cmd.Parameters.Add("@High", System.Data.SqlDbType.Float);
            Cmd.Parameters.Add("@Avg", System.Data.SqlDbType.Float);
            Cmd.Parameters.Add("@EmpresaID", System.Data.SqlDbType.Int);

            // set values to parameters from textboxes
            Cmd.Parameters["@AcaoID"].Value = a.acaoID;
            Cmd.Parameters["@Hora"].Value = a.hora;
            Cmd.Parameters["@Low"].Value = a.low;
            Cmd.Parameters["@High"].Value = a.high;
            Cmd.Parameters["@Avg"].Value = a.avg;
            Cmd.Parameters["@EmpresaID"].Value = a.empresaID;

            Con.Open();

            // execute the query and return number of rows affected, should be one
            int RowsAffected = Cmd.ExecuteNonQuery();

            Con.Close();
    	}

        public Acao get(int acaoID) {
            SqlConnection Con = new SqlConnection("MyConnectionString");
            // create command object with SQL query and link to connection object
            SqlCommand Cmd = new SqlCommand("SELECT * FROM Acao WHERE AcaoID = @AcaoID", Con);

            Con.Open();
            Cmd.Parameters.Add("@AcaoID", System.Data.SqlDbType.Int);
            Cmd.Parameters["@AcaoID"].Value = acaoID;

            Acao a = new Acao();

            SqlDataReader reader = Cmd.ExecuteReader();
            if(reader.Read()){
                a.acaoID = acaoID;
                a.hora = DataTime.Parse(reader["Hora"]);
                a.low = reader["Low"].ToFloat();
                a.high = reader["Low"].ToFloat();
                a.avg = reader["Avg"].ToFloat();
            }
            else {
                a = null;
            }
            Con.Close();

            return a;
        }
    }



