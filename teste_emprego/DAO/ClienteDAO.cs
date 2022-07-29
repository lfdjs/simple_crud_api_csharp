using System.Data;
using System.Data.SqlClient;
using teste_emprego.Model;

namespace teste_emprego.DAO
{
    public class ClienteDAO : Conexao
    {
        // Método de Listar as Clientes
        public List<Cliente>? GetClientes()
        {
            List<Cliente> Clientes = new List<Cliente>();
            sql = "SELECT * FROM Cliente";
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
                                    var Cliente = new Cliente();
                                    Cliente.id = (int)rdr["id"];
                                    Cliente.nome = (string)rdr["nome"];
                                   // Cliente.uf = (string)rdr["uf"];
                                    Clientes.Add(Cliente);
                                }
                            }

                        }
                    }
                    return Clientes;
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

        public List<Cliente>? GetClientes(Cliente Cliente)
        {
            List<Cliente> Clientes = new List<Cliente>();
            sql = "SELECT * FROM cliente WHERE nome like @nome";
            try
            {
                if (conectar())
                {

                    using (SqlCommand cmd = new(sql, conexao))
                    {
                        cmd.CommandType = CommandType.Text;
                        cmd.Parameters.AddWithValue("@nome", "%" + Cliente.nome + "%");
                        cmd.ExecuteNonQuery();
                        using (SqlDataReader rdr = cmd.ExecuteReader())

                        {
                            if (rdr != null)
                            {
                                while (rdr.Read())
                                {
                                    var _Cliente = new Cliente();
                                    _Cliente.id = (int)rdr["id"];
                                    _Cliente.nome = (string)rdr["nome"];
                                    //_Cliente.uf = (string)rdr["uf"];
                                    Clientes.Add(_Cliente);
                                }
                            }

                        }
                    }
                    return Clientes;
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

        //Método de inserir as Clientes
        public void InserirCliente(Cliente Cliente)
        {
            sql = "INSERT INTO Cliente (nome, telefone, id_cidade, apelido, data_nascimento) VALUES (@nome, @telefone, @id_cidade, @apelido, @data_nascimento)";
            try
            {
                if (conectar())
                {

                    using (SqlCommand cmd = new(sql, conexao))
                    {
                        cmd.CommandType = CommandType.Text;
                        cmd.Parameters.AddWithValue("@nome", Cliente.nome);
                        cmd.Parameters.AddWithValue("@telefone", Cliente.telefone);
                        cmd.Parameters.AddWithValue("@id_cidade", Cliente.id_cidade);
                        cmd.Parameters.AddWithValue("@apelido", Cliente.apelido);
                        cmd.Parameters.AddWithValue("@data_nascimento", Cliente.data_nascimento);
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

        public void AlterarCliente(int id, string nome, string telefone)
        {


            sql = "UPDATE Cliente SET nome = @nome, telefone = @telefone WHERE id = @id";
            try
            {
                if (conectar())
                {

                    using (SqlCommand cmd = new(sql, conexao))
                    {
                        cmd.CommandType = CommandType.Text;
                        cmd.Parameters.AddWithValue("@nome", nome);
                         cmd.Parameters.AddWithValue("@telefone", telefone);
                        cmd.Parameters.AddWithValue("@id", id);
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

        public void DeletarCliente(Cliente Cliente)
        {
            sql = "DELETE FROM Cliente WHERE id = @id";
            try
            {
                if (conectar())
                {

                    using (SqlCommand cmd = new(sql, conexao))
                    {
                        cmd.CommandType = CommandType.Text;

                        cmd.Parameters.AddWithValue("@id", Cliente.id);
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
