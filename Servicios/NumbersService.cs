using Dapper;
using Microsoft.Data.Sqlite;
using Parcial_p4_LuisEnmanuel.Modelos;


namespace Parcial_p4_LuisEnmanuel.Servicios;

    public class NumbersService
    {
        private readonly string _connectionString;

        public NumbersService(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection")!;
        }

        public async Task InitializeAsync()
        {
            using var connection = new SqliteConnection(_connectionString);
            await connection.ExecuteAsync(@"
                CREATE TABLE IF NOT EXISTS NumberRecords (
                    Id INTEGER PRIMARY KEY AUTOINCREMENT,
                    Fecha TEXT NOT NULL,
                    Numero INTEGER NOT NULL,
                    Resultado INTEGER NOT NULL
                );");
        }


        public async Task<int> SaveAsync(NumberRecord record)
        {
            using var connection = new SqliteConnection(_connectionString);

            var sql = @"
        INSERT INTO NumberRecords (Fecha, Numero, Resultado)
        VALUES (@Fecha, @Numero, @Resultado);
        SELECT last_insert_rowid();";

            return await connection.ExecuteScalarAsync<int>(sql, record);
        }


        public async Task<NumberRecord?> GetByIdAsync(int id)
        {
            using var connection = new SqliteConnection(_connectionString);

            var sql = "SELECT Id, Fecha, Numero, Resultado FROM NumberRecords WHERE Id = @Id;";

            return await connection.QueryFirstOrDefaultAsync<NumberRecord>(sql, new { Id = id });
        }


        public async Task<IEnumerable<NumberRecord>> GetListAsync()
        {
            using var connection = new SqliteConnection(_connectionString);

            var sql = "SELECT Id, Fecha, Numero, Resultado FROM NumberRecords ORDER BY Id DESC;";

            return await connection.QueryAsync<NumberRecord>(sql);
        }

    }

