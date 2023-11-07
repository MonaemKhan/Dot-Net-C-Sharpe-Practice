using AutoMapper;
using WEB_API_AUTH_Parctice.DBCon;
using WEB_API_AUTH_Parctice.Model;
using WEB_API_AUTH_Parctice.Model.DTO;
using WEB_API_AUTH_Parctice.Repository.Base;

namespace WEB_API_AUTH_Parctice.Repository;

public class StudentRepository : BaseRepository<Student, VmStudent,int>, IStudentRepository
{
    public StudentRepository(IMapper mapper, PracticeDbContext context) : base(mapper, context)
    {
    }
}
