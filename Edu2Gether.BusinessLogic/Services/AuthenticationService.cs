using Edu2Gether.DataAccess.Models;
using Edu2Gether.DataAccess.Repositories;
using FirebaseAdmin.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Edu2Gether.BusinessLogic.Commons;
using Microsoft.Extensions.Configuration;
using NTQ.Sdk.Core.CustomModel;
using Edu2Gether.BusinessLogic.ServiceModels.ViewModels;

namespace Edu2Gether.BusinessLogic.Services
{
    public interface IAuthenticationService
    {
        Task<UserRecord> GetUserByTokenId(string tokenId);
        Task<dynamic> LoginByEmail(string token, string firebaseToken);
    }

    public class AuthenticationService : IAuthenticationService
    {

        private readonly IUserRepository _userRepository;
        private readonly IRoleRepository _roleRepository;
        private readonly IConfiguration _configuration;
        private readonly IMenteeRepository _menteeRepository;
        private readonly IMentorRepository _mentorRepository;

        public AuthenticationService(IConfiguration configuration, IUserRepository userRepository, IRoleRepository roleRepository, IMenteeRepository menteeRepository, IMentorRepository mentorRepository)
        {
            _configuration = configuration;
            _userRepository = userRepository;
            _roleRepository = roleRepository;
            _menteeRepository = menteeRepository;
            _mentorRepository = mentorRepository;
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

        public async Task<dynamic> LoginByEmail(string token, string firebaseToken)
        {
            UserRecord userRecord = null;

            try
            {
                userRecord = await GetUserByTokenId(token);
            }
            catch (Exception ex)
            {   
                return new
                {
                    response = new
                    {
                        success = false,
                        message = ex.Message,
                        status = 400
                    }
                };
            }

            // check user exist in database

            var user = _userRepository.Get(x => x.Email.Equals(userRecord.Email)).FirstOrDefault();

            try
            {
                if (user == null)
                {
                    User newUser = new User()
                    {
                        Id = userRecord.Uid,
                        UserName = userRecord.DisplayName,
                        Email = userRecord.Email,
                        IsActived = "Active",
                        RoleId = (int)UserRole.Mentee,
                        IsSystemAdmin = false
                    };

                    var userAdded = _userRepository.Create(newUser);
                    _userRepository.Save();

                    if (userAdded != null)
                    {
                        userAdded.Role = _roleRepository.Get().Where(x => x.Id == userAdded.RoleId).FirstOrDefault();

                        bool checkConfirm = false;

                        if (userAdded.RoleId == (int) UserRole.Mentee) 
                        {
                            checkConfirm = _menteeRepository.Get().Where(x => x.Id.Equals(userAdded.Id)).FirstOrDefault() != null;
                        }
                        else if (userAdded.RoleId == (int)UserRole.Mentor)
                        {
                            checkConfirm = _mentorRepository.Get().Where(x => x.Id.Equals(userAdded.Id)).FirstOrDefault() != null;
                        }
                        else
                        {
                            checkConfirm = true;
                        }

                            var tokenLogin =
                            TokenManager.GenerateJwtToken(string.IsNullOrEmpty(userAdded.UserName)
                                ? ""
                                : userAdded.UserName, userAdded.Role.RoleName, userAdded.Id, _configuration);

                        var responseSuccess = new LoginViewModel()
                        {
                            AccessToken = tokenLogin,
                            Id = userAdded.Id,
                            IsConfirmedInfo = checkConfirm,
                            Email = userAdded.Email,
                            Name = userAdded.UserName,
                            IsFirstLogin = true,
                            Role = userAdded.Role.RoleName
                        };
                        return responseSuccess;
                    }
                }
                else
                {
                    user.Role = _roleRepository.Get().Where(x => x.Id == user.RoleId).FirstOrDefault();

                    bool checkConfirm = false;

                    if (user.RoleId == (int)UserRole.Mentee)
                    {
                        checkConfirm = _menteeRepository.Get().Where(x => x.Id.Equals(user.Id)).FirstOrDefault() != null;
                    }
                    else if (user.RoleId == (int)UserRole.Mentor)
                    {
                        checkConfirm = _mentorRepository.Get().Where(x => x.Id.Equals(user.Id)).FirstOrDefault() != null;
                    }
                    else
                    {
                        checkConfirm = true;
                    }

                    var tokenLogin =
                            TokenManager.GenerateJwtToken(string.IsNullOrEmpty(user.UserName)
                                ? ""
                                : user.UserName, user.Role.RoleName, user.Id, _configuration);

                    var responseSuccess = new LoginViewModel()
                    {
                        AccessToken = tokenLogin,
                        Id = user.Id,
                        IsConfirmedInfo = checkConfirm,
                        Email = user.Email,
                        Name = user.UserName,
                        IsFirstLogin = false,
                        Role = user.Role.RoleName
                    };
                    return responseSuccess;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return null;

        }

    }
}
