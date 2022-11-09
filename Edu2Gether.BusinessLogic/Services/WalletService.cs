using AutoMapper;
using Edu2Gether.BusinessLogic.ViewModels;
using Edu2Gether.DataAccess.Repositories;
using System.Linq;

namespace Edu2Gether.BusinessLogic.Services 
{

    public interface IWalletService {
        UserResponseModel GetUserByWallet(int id);
        WalletResponseModel GetWalletByUser(string userId);
    }

    public class WalletService : IWalletService {

        private readonly IWalletRepository _walletRepository;
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public WalletService(IWalletRepository walletRepository, IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _walletRepository = walletRepository;
            _mapper = mapper;
        }

        public UserResponseModel GetUserByWallet(int id)
        {
            var wallet = _walletRepository.Get().Where(x => x.Id == id).FirstOrDefault();

            if (wallet != null)
            {
                var user = _userRepository.Get().Where(x => x.Id.Equals(wallet.UserId)).FirstOrDefault();
                return _mapper.Map<UserResponseModel>(user);
            }

            return null;
        }

        public WalletResponseModel GetWalletByUser(string userId)
        {
            var wallet = _walletRepository.Get().Where(x => x.UserId.Equals(userId)).FirstOrDefault();

            if (wallet != null)
            {
                return _mapper.Map<WalletResponseModel>(wallet);
            }

            return null;
        }
    }

}
