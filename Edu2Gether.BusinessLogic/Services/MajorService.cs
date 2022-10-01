using Edu2Gether.DataAccess.Repositories;

namespace Edu2Gether.BusinessLogic.Services 
{

    public interface IMajorService {
    
    }

    public class MajorService : IMajorService {

      private readonly IMajorRepository _majorRepository;

        public MajorService(IMajorRepository majorRepository)
        {
            _majorRepository = majorRepository;
        }

    }

}
