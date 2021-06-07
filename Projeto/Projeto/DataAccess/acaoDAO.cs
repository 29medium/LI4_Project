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
    public class AcaoDAO
    {
        public bool Insert(Acao a)
        {
            // create sql connection object.  Be sure to put a valid connection string
            SqlConnection Con = new SqlConnection("Server=.;Database=LI4_Project;Trusted_Connection=True;");
            // create command object with SQL query and link to connection object
            SqlCommand Cmd = new SqlCommand("INSERT INTO Acao " +
                "(codigo,hora,low,high,avg,empresa_id) " +
                "VALUES(@codigo, @hora, @low,@high,@avg,@empresa_id)", Con);

            // create your parameters
            Cmd.Parameters.Add("@codigo", System.Data.SqlDbType.VarChar);
            Cmd.Parameters.Add("@hora", System.Data.SqlDbType.DateTime);
            Cmd.Parameters.Add("@low", System.Data.SqlDbType.Float);
            Cmd.Parameters.Add("@high", System.Data.SqlDbType.Float);
            Cmd.Parameters.Add("@avg", System.Data.SqlDbType.Float);
            Cmd.Parameters.Add("@empreda_id", System.Data.SqlDbType.VarChar);

            // set values to parameters from textboxes
            Cmd.Parameters["@codigo"].Value = a.acaoID;
            Cmd.Parameters["@hora"].Value = a.hora;
            Cmd.Parameters["@low"].Value = a.low;
            Cmd.Parameters["@high"].Value = a.high;
            Cmd.Parameters["@avg"].Value = a.avg;
            Cmd.Parameters["@empresa_id"].Value = a.empresaID;

            Con.Open();

            // execute the query and return number of rows affected, should be one
            int RowsAffected = Cmd.ExecuteNonQuery();

            Con.Close();

            return Convert.ToBoolean(RowsAffected);
        }

        public Acao get(string acaoID)
        {
            SqlConnection Con = new SqlConnection("Server=.;Database=LI4_Project;Trusted_Connection=True;");
            // create command object with SQL query and link to connection object
            SqlCommand Cmd = new SqlCommand("SELECT * FROM Acao WHERE codigo = @codigo", Con);

            Con.Open();
            Cmd.Parameters.Add("@codigo", System.Data.SqlDbType.VarChar);
            Cmd.Parameters["@codigo"].Value = acaoID;

            Acao a = new Acao();

            SqlDataReader reader = Cmd.ExecuteReader();
            if (reader.Read())
            {
                a.acaoID = acaoID;
                a.hora = DateTime.Parse(reader["hora"].ToString());
                a.low = reader.GetFloat("low");
                a.high = reader.GetFloat("high");
                a.avg = reader.GetFloat("avg");
                a.empresaID = reader.GetFloat("empresaID");
            }
            else
            {
                a = null;
            }
            Con.Close();

            return a;
        }

        public List<Acao> listaAcao()
        {
            List<Acao> acoes = new List<Acao>();
            SqlConnection Con = new SqlConnection("Server=.;Database=LI4_Project;Trusted_Connection=True;");
            // create command object with SQL query and link to connection object
            SqlCommand Cmd = new SqlCommand("SELECT * FROM Acao", Con);

            Con.Open();

            SqlDataReader reader = Cmd.ExecuteReader();
            while (reader.Read())
            {
                Acao a = new Acao();

                a.acaoID = reader["codigo"].ToString();
                a.hora = reader.GetDateTime("hora");
                a.high = reader.GetFloat("high");
                a.low = reader.GetFloat("low");
                a.avg = reader.GetFloat("avg");
                a.empresaID = reader["empresa_id"].ToString();

                acoes.Add(a);
            }

            Con.Close();

            return acoes;
        }
    }
}


