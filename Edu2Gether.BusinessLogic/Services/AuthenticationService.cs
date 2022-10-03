using Edu2Gether.DataAccess.Models;
using Edu2Gether.DataAccess.Repositories;
using FirebaseAdmin.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Edu2Gether.BusinessLogic.Commons;

namespace Edu2Gether.BusinessLogic.Services
{
    public interface IAuthenticationService
    {
        Task<UserRecord> GetUserByTokenId(string tokenId);
    }

    public class AuthenticationService : IAuthenticationService
    {

        private readonly IAuthenticationService _authenticationRepository;
        private readonly IUserRepository _userRepository;

        public AuthenticationService(IAuthenticationService authenticationRepository)
        {
            _authenticationRepository = authenticationRepository;
        }

        public async Task<UserRecord> GetUserByTokenId(string tokenId)
        {
            try
            {
                var auth = FirebaseAuth.DefaultInstance;
                FirebaseToken tokenDecoded = await auth.VerifyIdTokenAsync(tokenId);
                UserRecord userRecord = await auth.GetUserAsync(tokenDecoded.Uid);
                return userRecord;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }

        //public async Task<dynamic> LoginByEmail(string token, string firebaseToken)
        //{
        //    UserRecord userRecord = null;

        //    try
        //    {
        //        userRecord = await GetUserByTokenId(token);
        //    }
        //    catch (Exception ex)
        //    {
        //        return new
        //        {
        //            response = new
        //            {
        //                success = false,
        //                message = ex.Message,
        //                status = 400
        //            }
        //        };
        //    }

        //    // check user exist in database

        //    var user = _userRepository.Get(x => x.Email.Equals(userRecord.Email)).FirstOrDefault();

        //    try
        //    {
        //        if (user == null)
        //        {
        //            User newUser = new User()
        //            {
        //                Id = userRecord.Uid,
        //                UserName = userRecord.DisplayName,
        //                Email = userRecord.Email,
        //                IsActived = "Active",
        //                RoleId = (int)UserRole.Mentee,
        //                IsSystemAdmin = false
        //            };

        //            var userAdded = _userRepository.Create(newUser);
        //        }
        //    }
        //    catch (Exception ex)
        //    {

        //    }

        //}
    
    }
}
