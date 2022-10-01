using Edu2Gether.DataAccess.Repositories;

namespace Edu2Gether.BusinessLogic.Services 
{

    public interface IMenteeService {
    
    }

    public class MenteeService : IMenteeService {

      private readonly IMenteeRepository _menteeRepository;

        public MenteeService(IMenteeRepository menteeRepository)
        {
            _menteeRepository = menteeRepository;
        }

    }

}
