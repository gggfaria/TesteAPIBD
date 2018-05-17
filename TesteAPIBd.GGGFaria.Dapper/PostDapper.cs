using Dapper;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using TesteAPIBd.GGGFaria.Domain;

namespace TesteAPIBd.GGGFaria.Dapper
{
    public class PostDapper
    {
        protected string _strConexao = ConfigurationManager.ConnectionStrings["TesteAPIDbGGGFaria"].ConnectionString;

        public int Insert(Post post)
        {
            var sql = "EXEC SP_INSERT_POST @ID, @USER_ID, @TITLE, @BODY";

            using (IDbConnection conexao = new SqlConnection(_strConexao))
            {
                var retorno = conexao.Execute(sql, new{
                    @ID =  post.Id, 
                    @USER_ID = post.UserId,
                    @TITLE = post.Title, 
                    @BODY = post.Body
                } , commandType:CommandType.StoredProcedure);

                return retorno;
            }
        }
    }
}
