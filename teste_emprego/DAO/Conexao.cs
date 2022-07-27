namespace teste_emprego.DAO

{
using System.Data;
using System.Data.SqlClient;

    public class Conexao
    {
        private readonly string url = "Data Source=dbdemo.cmyxxu3ceill.sa-east-1.rds.amazonaws.com;Initial Catalog=ERI.SOU; User ID=admin; Password=movisis1";
        protected string sql { get; set; }

        public SqlConnection? conexao;

        public bool conectar()
        {
            conexao = new SqlConnection(url);

            try
            {
                conexao.Open();
                return true;
            }
            catch (SqlException erro)
            {
                throw erro;
            }
        }

        public bool desconectar()
        {
            if (conexao.State != ConnectionState.Closed)
            {

                conexao.Close();
                conexao.Dispose();
                return true;

            }
            else
            {
                conexao.Dispose();
                return false;
            }

        }

        public string testeConexao() {
            try
            {
                if (conectar())
                {
                    return "Conectado";
                }
                else {
                    return "Não conectado";
                }
            }
            catch (Exception erro)
            {
                throw erro;
            }
        }
    }
}
