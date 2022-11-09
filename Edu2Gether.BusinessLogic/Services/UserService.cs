
using AutoMapper;
using Edu2Gether.BusinessLogic.Commons;
using Edu2Gether.BusinessLogic.ViewModels;
using Edu2Gether.DataAccess.Repositories;
using System.Linq;

namespace Edu2Gether.BusinessLogic.Services 
{

    public interface IUserService {
        public UserResponseModel ChangeRoleToMentor(string menteeId);
    }

    public class UserService : IUserService {

        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        private readonly IMenteeRepository _menteeRepository;

        public UserService(IUserRepository userRepository, IMenteeRepository menteeRepository, IMapper mapper)
        {
            _menteeRepository = menteeRepository;
            _mapper = mapper;
            _userRepository = userRepository;
        }

        public UserResponseModel ChangeRoleToMentor(string menteeId)
        {
            var mentee = _menteeRepository.Get().Where(x => x.Id.Equals(menteeId)).FirstOrDefault();

            if (mentee != null)
            {
                var user = _userRepository.Get().Where(x => x.Id.Equals(menteeId)).FirstOrDefault();

                if (user.RoleId != (int) UserRole.Mentee)
                {
                    return null;
                }

                user.RoleId = (int)UserRole.Mentor;
                var userUpdated = _userRepository.Update(user);
                _userRepository.Save();

                if (userUpdated.RoleId == (int)UserRole.Mentor)
                {
                    _menteeRepository.Delete(mentee);
                    _menteeRepository.Save();
                }

                return _mapper.Map<UserResponseModel>(userUpdated);
            }
            return null;
        }
    }

}
