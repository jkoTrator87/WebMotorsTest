using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using MVCWebMotors.Models;
using System.Data;

namespace MVCWebMotors.Service.DAO
{
    public class DAO
    {
        public readonly string connection = @"Server=NOTEII;Database=teste_webmotors;User Id=jkqueiroz;Password=manu271009;";

        public List<Anuncio> ListarAnuncios()
        {
            List<Anuncio> anuncios = new List<Anuncio>();
            try
            {
                using (SqlConnection conn = new SqlConnection(connection))
                {
                    string select = @"Select ID, marca, modelo, versao, ano, quilometragem, observacao 
                                    from tb_AnuncioWebmotors";
                    using (SqlCommand command = new SqlCommand(select))
                    {
                        command.Connection = conn;
                        command.Connection.Open();
                        SqlDataReader reader = command.ExecuteReader();
                        DataTable monster = new DataTable();
                        monster.Load(reader);
                        foreach (DataRow item in monster.Rows)
                        {
                            anuncios.Add(new Anuncio
                            {
                                ID = Convert.ToInt32(item["ID"]),
                                Make = item["marca"].ToString(),
                                Model = item["modelo"].ToString(),
                                Version = item["versao"].ToString(),
                                YearModel = Convert.ToInt32(item["ano"]),
                                KM = item["quilometragem"].ToString(),
                                Obs = item["observacao"].ToString(),
                            });
                        }


                        command.Connection.Close();
                    }
                }
            }
            catch(Exception e)
            {
                // Serviço de Log armazena Erro
            }
            return anuncios;
        }

        public bool InserirAnuncio(Anuncio anuncio)
        {
            bool result = false;
            try
            {
                using (SqlConnection conn = new SqlConnection(connection))
                {
                    string insert = @"INSERT INTO tb_AnuncioWebmotors (marca,	modelo,	versao,	ano, quilometragem,	observacao)
                                    VALUES (@marca, @modelo, @versao, @ano, @quilometragem, @observacao)";

                    using (SqlCommand command = new SqlCommand(insert))
                    {
                        command.Connection = conn;
                        command.Parameters.Add("@marca", System.Data.SqlDbType.VarChar, 200).Value = anuncio.Make;
                        command.Parameters.Add("@modelo", System.Data.SqlDbType.VarChar, 200).Value = anuncio.Model;
                        command.Parameters.Add("@versao", System.Data.SqlDbType.VarChar, 200).Value = anuncio.Version;
                        command.Parameters.Add("@ano", System.Data.SqlDbType.Int, 200).Value = anuncio.YearModel;
                        command.Parameters.Add("@quilometragem", System.Data.SqlDbType.Int, 200).Value = anuncio.KM;
                        command.Parameters.Add("@observacao", System.Data.SqlDbType.Text, 200).Value = anuncio.Obs;

                        conn.Open();

                        result = command.ExecuteNonQuery() > 0;

                        conn.Close();
                    }
                }
            }
            catch(Exception e)
            {
                // Serviço de Log armazena Erro
            }
            return result;
        }

        public bool EditarAnuncio(Anuncio anuncio)
        {
            bool result = false;
            try
            {
                using (SqlConnection conn = new SqlConnection(connection))
                {
                    string insert = @"Update 
                                        tb_AnuncioWebmotors
                                   Set 
                                        marca = @marca, 
                                        modelo = @modelo, 
                                        versao = @versao,
                                        ano = @ano, 
                                        quilometragem = @quilometragem, 
                                        observacao = @observacao
                                   Where
                                        ID = @Id";

                    using (SqlCommand command = new SqlCommand(insert))
                    {
                        command.Connection = conn;
                        command.Parameters.Add("@Id", System.Data.SqlDbType.Int, 200).Value = anuncio.ID;
                        command.Parameters.Add("@marca", System.Data.SqlDbType.VarChar, 200).Value = anuncio.Make;
                        command.Parameters.Add("@modelo", System.Data.SqlDbType.VarChar, 200).Value = anuncio.Model;
                        command.Parameters.Add("@versao", System.Data.SqlDbType.VarChar, 200).Value = anuncio.Version;
                        command.Parameters.Add("@ano", System.Data.SqlDbType.Int, 200).Value = anuncio.YearModel;
                        command.Parameters.Add("@quilometragem", System.Data.SqlDbType.Int, 200).Value = anuncio.KM;
                        command.Parameters.Add("@observacao", System.Data.SqlDbType.Text, 200).Value = anuncio.Obs;

                        conn.Open();

                        result = command.ExecuteNonQuery() > 0;

                        conn.Close();
                    }
                }
            }
            catch(Exception e)
            {
                // Serviço de Log armazena o erro
            }
            return result;
            
        }
        public bool RemoverAnuncio(Anuncio anuncio)
        {
            bool result = false;
            try
            {
                using (SqlConnection conn = new SqlConnection(connection))
                {
                    string insert = @"Delete
                                        tb_AnuncioWebmotors
                                   Where
                                        ID = @Id";

                    using (SqlCommand command = new SqlCommand(insert))
                    {
                        command.Connection = conn;
                        command.Parameters.Add("@Id", System.Data.SqlDbType.Int, 200).Value = anuncio.ID;

                        conn.Open();

                        result = command.ExecuteNonQuery() > 0;

                        conn.Close();
                    }
                }
            }
            catch (Exception e)
            {
                // Serviço de Log armazena o erro
            }
            return result;

        }
    }
}