using Edu2Gether.DataAccess.Repositories;

namespace Edu2Gether.BusinessLogic.Services 
{

    public interface IMarkService {
    
    }

    public class MarkService : IMarkService {

      private readonly IMarkRepository _markRepository;

        public MarkService(IMarkRepository markRepository)
        {
            _markRepository = markRepository;
        }

    }

}
