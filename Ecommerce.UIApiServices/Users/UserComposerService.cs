using AutoMapper;
using Ecommerce.Core.Users;
using Ecommerce.Core.Users.Models;
using Ecommerce.UIApiServices.Users.Models;
using Ecommerce.UIApiServices.Users.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.UIApiServices.Users
{
    public class UserComposerService: IUserComposerService
    {
        private readonly IUserManager _userManager;
        private readonly IMapper _mapper;
        private readonly IUserContext _userContext;

        public UserComposerService(IUserManager userManager, IMapper mapper, IUserContext userContext)
        {
            _userManager = userManager;
            _mapper = mapper;
            _userContext = userContext;
        }

        public async Task<UserInfoViewModel> GetUseInfoAsync(Guid userId)
        {
            var user = await _userManager.GetUseInfoAsync(userId);
            var viewModel = _mapper.Map<UserInfoViewModel>(user);

            return viewModel;
        }

        public UserContextViewModel GetUserContext()
        {
            var viewModel = _mapper.Map<UserContextViewModel>(_userContext);
            return viewModel;
        }

        public async Task UpadateUserAsync(SaveUserModel model, Guid userId)
        {
            var updateModel = new UpdateUserModel
            {
                Id = userId,
                Address = model.Address,
                DisplayName = model.DisplayName,
                FirstName = model.FirstName,
                LastName = model.LastName
            };

            await _userManager.UpdateUserAsync(updateModel);
        }
    }

    public interface IUserComposerService
    {
        Task<UserInfoViewModel> GetUseInfoAsync(Guid userId);

        UserContextViewModel GetUserContext();

        Task UpadateUserAsync(SaveUserModel model, Guid userId);
    }
}
