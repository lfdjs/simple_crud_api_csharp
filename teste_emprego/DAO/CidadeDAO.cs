using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Data.SqlClient;
using teste_emprego.Model;

namespace teste_emprego.DAO
{
    public class CidadeDAO : Conexao
    {
        // Método de Listar as Cidades
        public List<Cidade>? GetCidades() {
            List<Cidade> cidades = new List<Cidade>();
            sql = "SELECT * FROM cidade";
            try
            {
                if (conectar())
                {

                    using (SqlCommand cmd = new(sql, conexao))
                    {
                        cmd.CommandType = CommandType.Text;
                        using (SqlDataReader rdr = cmd.ExecuteReader())
                        {
                            if (rdr != null)
                            {
                                while (rdr.Read())
                                {
                                    var cidade = new Cidade();
                                    cidade.id = (int)rdr["id"];
                                    cidade.nome = (string)rdr["nome"];
                                    cidade.uf = (string)rdr["uf"];
                                    cidades.Add(cidade);
                                }
                            }

                        }
                    }
                    return cidades;
                }
            }
            catch (Exception erro)
            {

                throw erro;
            }
            finally
            {
                desconectar();
            }
            return null;
        }

        //Método de inserir as cidades
        public void InserirCidade(Cidade cidade) {
            sql = "INSERT INTO cidade (nome, uf) VALUES (@nome, @uf)";
            try
            {
                if (conectar())
                {

                    using (SqlCommand cmd = new(sql, conexao))
                    {
                        cmd.CommandType = CommandType.Text;
                        cmd.Parameters.AddWithValue("@nome", cidade.nome);
                        cmd.Parameters.AddWithValue("@uf", cidade.uf);
                        cmd.ExecuteNonQuery();
                    }
                   
                }
            }
            catch (Exception erro)
            {
                throw erro;
            }
            finally
            {
                desconectar();
            }
           
        }

        public void AlterarCidade(Cidade cidade)
        {
            sql = "UPDATE cidade SET nome = @nome WHERE id = @id";
            try
            {
                if (conectar())
                {

                    using (SqlCommand cmd = new(sql, conexao))
                    {
                        cmd.CommandType = CommandType.Text;
                        cmd.Parameters.AddWithValue("@nome", cidade.nome);
                        cmd.Parameters.AddWithValue("@id", cidade.id);
                        cmd.ExecuteNonQuery();
                    }

                }
            }
            catch (Exception erro)
            {
                throw erro;
            }
            finally
            {
                desconectar();
            }
        }

        public void DeletarCidade(Cidade cidade)
        {
            sql = "DELETE FROM cidade WHERE id = @id";
            try
            {
                if (conectar())
                {

                    using (SqlCommand cmd = new(sql, conexao))
                    {
                        cmd.CommandType = CommandType.Text;
                        
                        cmd.Parameters.AddWithValue("@id", cidade.id);
                        cmd.ExecuteNonQuery();
                    }

                }
            }
            catch (Exception erro)
            {
                throw erro;
            }
            finally
            {
                desconectar();
            }
        }
    }
}
