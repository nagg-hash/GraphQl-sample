using Microsoft.Azure.Cosmos;
using static WebApplication1.CosmosDbStore;

namespace WebApplication1
{
    public class StudentRepository: IStudentRepository
    {
        private readonly Container _container;

        public StudentRepository(ICosmosDBStore cosmosContainerStore)
        {
            _container = cosmosContainerStore.GetContainer("Student");
        }

        public IQueryable<Student> GetStudents(IEnumerable<string> ids)
        {
            return _container.GetItemLinqQueryable<Student>(true).Where(x => ids.Contains(x.Id));
        }
    }

    public interface IStudentRepository
    {
        IQueryable<Student> GetStudents(IEnumerable<string> imoNumbers);
    }
}
