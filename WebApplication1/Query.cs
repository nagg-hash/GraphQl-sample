using Microsoft.EntityFrameworkCore;

namespace WebApplication1
{
    public class Query
    {
        [GraphQLName("getStudent")]
        [UseProjection]
        [UseFiltering]
        public IQueryable<Student> GetStudent([Service] StudentDbContext dbContext)
        {
            return dbContext.StudentData.AsNoTracking();
        }

        [GraphQLName("getData")]
        [UseProjection]
        public IQueryable<Student> GetData(string id, [Service] IStudentRepository dbContext)
        {
            var ids = id.Split(',', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries).Distinct();
            return dbContext.GetStudents(ids);
        }
    }
}
