using crudDapperMicroOrm.Models;
using crudDapperMicroOrm.Repositories.Interfaces;
using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Win32;
using System.Data;

namespace crudDapperMicroOrm.Repositories.Implementations
{
    public class EnrollmentRepository : IEnrollmentRepository
    {
        //Injeta Conexão do Sql Server
        private readonly SqlConnection _connection;
        public EnrollmentRepository(SqlConnection connection)
        {
            _connection = connection;
        }

        //O método AddAsync insere um novo registro na tabela Enrollments.
        //A query SQL insere os dados e retorna o ID gerado (SCOPE_IDENTITY()).
        //Utilizamos DynamicParameters para passar os parâmetros de forma segura.
        //A conexão é verificada e aberta se necessário.
        //ExecuteScalarAsync é utilizado para executar a consulta e obter o ID gerado.
        //O ID gerado é atribuído de volta à entidade.
        public async Task<Enrollment> AddAsync(Enrollment entity)
        {
            var query = @"INSERT
	                            INTO
	                            Enrollments (EnrollmentNumber,
	                            EnrollmentDate)
                            VALUES (@EnrollmentNumber,
                            @EnrollmentDate);

                            SELECT
	                            CAST(SCOPE_IDENTITY() as int)";

            var parameters = new DynamicParameters();
            parameters.Add("@EnrollmentNumber", entity.EnrollmentNumber, DbType.Int32);
            parameters.Add("@EnrollmentDate", entity.EnrollmentDate, DbType.DateTime);

            if (_connection.State != ConnectionState.Open)
            {
                _connection.Open();
            }

            // Executando a inserção e obtendo o ID gerado
            int newId = await _connection.ExecuteScalarAsync<int>(query, parameters);

            // Atualizando a entidade com o ID gerado
            entity.Id = newId;

            // Retornando a entidade atualizada
            return entity;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var query = @"DELETE
                            FROM
	                            Enrollments
                            WHERE
	                            Id = @Id";

            var parameters = new DynamicParameters();
            parameters.Add("@Id", id, DbType.Int32);

            if (_connection.State != ConnectionState.Open)
            {
                _connection.Open();
            }

            // Executando a consulta de exclusão
            var result = await _connection.ExecuteAsync(query, parameters);

            // Retorna true se uma linha foi afetada, caso contrário false
            return result > 0;
        }

        public async Task<IEnumerable<Enrollment>> GetAllAsync()
        {
            var query = @"SELECT
	                            Id,
	                            EnrollmentNumber,
	                            EnrollmentDate
                            FROM
	                            Enrollments";

            if (_connection.State != ConnectionState.Open)
            {
                _connection.Open();
            }

            // Executando a consulta e retornando os resultados
            var enrollments = await _connection.QueryAsync<Enrollment>(query);

            return enrollments;
        }

        public async Task<Enrollment?> GetAsync(int id)
        {
            var query = @"SELECT
	                            Id,
	                            EnrollmentNumber,
	                            EnrollmentDate
                            FROM
	                            Enrollments
                            WHERE
	                            Id = @Id";

            var parameters = new DynamicParameters();
            parameters.Add("@Id", id, DbType.Int32);

            if (_connection.State != ConnectionState.Open)
            {
                _connection.Open();
            }

            // Executando a consulta e retornando o resultado
            var enrollment = await _connection.QuerySingleOrDefaultAsync<Enrollment>(query, parameters);

            return enrollment;
        }

        public async Task<bool> UpdateAsync(Enrollment entity)
        {
            var query = @"UPDATE
	                            Enrollments
                            SET
	                            EnrollmentNumber = @EnrollmentNumber,
	                            EnrollmentDate = @EnrollmentDate
                            WHERE
	                            Id = @Id";

            var parameters = new DynamicParameters();
            parameters.Add("@Id", entity.Id, DbType.Int32);
            parameters.Add("@EnrollmentNumber", entity.EnrollmentNumber, DbType.Int32);
            parameters.Add("@EnrollmentDate", entity.EnrollmentDate, DbType.DateTime);

            if (_connection.State != ConnectionState.Open)
            {
                _connection.Open();
            }

            // Executando a consulta de atualização
            var result = await _connection.ExecuteAsync(query, parameters);

            // Retorna true se uma linha foi afetada, caso contrário false
            return result > 0;
        }
    }
}
