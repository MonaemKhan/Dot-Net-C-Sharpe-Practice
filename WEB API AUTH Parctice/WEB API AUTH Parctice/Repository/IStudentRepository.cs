using WEB_API_AUTH_Parctice.Model;
using WEB_API_AUTH_Parctice.Model.DTO;
using WEB_API_AUTH_Parctice.Repository.Base;

namespace WEB_API_AUTH_Parctice.Repository;

public interface IStudentRepository:IBaseRepository<Student,VmStudent,int>
{
}
