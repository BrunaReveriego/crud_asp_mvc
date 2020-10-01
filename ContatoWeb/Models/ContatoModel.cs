using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ContatoWeb.Models
{

    //IDisposable -> Interface com apenas um método publico 'Disponse'
    public class ContatoModel : IDisposable
    {

        private SqlConnection connection;

        public ContatoModel()
        {
            string strConn = "Data Source=localhost;Initial Catalog=BDContato;Integrated Security=true";
            connection = new SqlConnection(strConn);
            connection.Open();
        }


        public void Dispose()
        {
            //Método executado sempre que a classe é finalizada
            connection.Close();
        }

        public List<Contato> Read()
        {
            //pegar todos campos da tabela Contato e armazenar na Collection
            List<Contato> lista = new List<Contato>();

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = connection;
            cmd.CommandText = @"SELECT * FROM Contato";

            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {

                Contato contato = new Contato();
                contato.IdContato = (int)reader["IdContato"];
                contato.Nome = (string)reader["Nome"];
                contato.Email = (string)reader["Email"];

                lista.Add(contato);
            }

            return lista;
        }

        //Método criação de registros 
        public void Create(Contato contato)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = connection;
            cmd.CommandText = @"INSERT INTO Contato VALUES (@nome,@email)";

            cmd.Parameters.AddWithValue("@nome", contato.Nome);
            cmd.Parameters.AddWithValue("@email", contato.Email);

            cmd.ExecuteNonQuery();

        }

        public void Update(Contato contato)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = connection;
            cmd.CommandText = @"UPDATE Contato SET Nome=@nome, Email =@email WHERE IdContato=@id";

            cmd.Parameters.AddWithValue("@nome", contato.Nome);
            cmd.Parameters.AddWithValue("@email", contato.Email);
            cmd.Parameters.AddWithValue("@id", contato.IdContato);

            cmd.ExecuteNonQuery();

        }


    }
}