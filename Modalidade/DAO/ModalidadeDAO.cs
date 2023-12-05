using AutoMapper;
using Modalidade.DTO;
using System.Data;
using System.Data.SqlClient;

namespace Modalidade.DAO
{
    public class ModalidadeDAO
    {
        String conexao = @"Server=DESKTOP-BJNTUCI\MSSQLSERVER01;Database=Cliente;Trusted_Connection=True";
        public ModalidadeDTO retornaModalidade(String nome)
        {
            ModalidadeDTO modalidadeDTO = new ModalidadeDTO();
            Model.Modalidade modalidade = new Model.Modalidade();

            string sql = "select id_modalidade, nome_modalidade, tipo_modalidade from Modalidade where nome_modalidade =" + "'" + nome + "'";

            SqlConnection con = new SqlConnection(conexao);
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.CommandType = CommandType.Text;
            SqlDataReader reader;
            con.Open();

            try
            {
                reader = cmd.ExecuteReader();
                if (reader.Read())
                {

                    modalidade.idModalidade = Convert.ToInt32(reader["id_modalidade"]);
                    modalidade.nomeDaModalidade = reader["nome_modalidade"].ToString();
                    modalidade.tipoModalidade = reader["tipo_modalidade"].ToString();
         

                    var configuration = new MapperConfiguration(cfg =>
                    {
                        cfg.CreateMap<Model.Modalidade, ModalidadeDTO>();
                    });
                    var mapper = configuration.CreateMapper();
                    modalidadeDTO = mapper.Map<ModalidadeDTO>(modalidade);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

            }
            finally
            {
                con.Close();
            }

            return modalidadeDTO;
        }


        public int deletaModalidade(String nome)
        {
            String retorno = "";
            string sql = "delete from dbo.Modalidade where nome_modalidade = " + "'" + nome + "'";

            SqlConnection con = new SqlConnection(conexao);
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.CommandType = CommandType.Text;

            con.Open();

            int i = cmd.ExecuteNonQuery();
            return i;

        }


        public int insereModalidade(ModalidadeDTO modalidadeDTO)
        {

            String retorno = "";
            string sql = "INSERT INTO dbo.Modalidade (nome_modalidade, tipo_modalidade ) VALUES (" + "'" + modalidadeDTO.nomeDaModalidade + "'" + "," + "'" + modalidadeDTO.tipoModalidade + "'" + ")";
            SqlConnection con = new SqlConnection(conexao);
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.CommandType = CommandType.Text;
            SqlDataReader reader;
            con.Open();

            int i = cmd.ExecuteNonQuery();

            return i;
        }
        public int alteraModalidade(ModalidadeDTO modalidadeDTO,String nome)
        {

            String retorno = "";
            string sql = "UPDATE dbo.Modalidade SET  nome_modalidade=" + "'" + modalidadeDTO.nomeDaModalidade + "'" + "," + "tipo_modalidade=" + "'" + modalidadeDTO.tipoModalidade + "'" + "   where nome_modalidade=" + "'" + nome + "'";
            SqlConnection con = new SqlConnection(conexao);
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.CommandType = CommandType.Text;
            SqlDataReader reader;
            con.Open();

            int i = cmd.ExecuteNonQuery();

            return i;
        }
    }
}
