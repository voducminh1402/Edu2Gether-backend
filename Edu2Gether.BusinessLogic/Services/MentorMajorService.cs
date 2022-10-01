using Edu2Gether.DataAccess.Repositories;

namespace Edu2Gether.BusinessLogic.Services 
{

    public interface IMentorMajorService {
    
    }

    public class MentorMajorService : IMentorMajorService {

      private readonly IMentorMajorRepository _mentormajorRepository;

        public MentorMajorService(IMentorMajorRepository mentormajorRepository)
        {
            _mentormajorRepository = mentormajorRepository;
        }

    }

}
