
namespace AdventureWorksApi.Repositories
{
    public interface IProcedureRepository
    {
        Task<IEnumerable<dynamic>> ExecuteProcedureAsync(string procedureName, IDictionary<string, object> parameters);
    }
}
