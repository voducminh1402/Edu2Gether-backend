using Edu2Gether.DataAccess.Repositories;

namespace Edu2Gether.BusinessLogic.Services 
{

    public interface ICourseService {
    
    }

    public class CourseService : ICourseService {

      private readonly ICourseRepository _courseRepository;

        public CourseService(ICourseRepository courseRepository)
        {
            _courseRepository = courseRepository;
        }

    }

}