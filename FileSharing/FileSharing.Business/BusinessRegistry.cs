using FileSharing.Business.Interfaces;
using FileSharing.Business.Services;
using FileSharing.Entities.Core;
using StructureMap;

namespace FileSharing.Services
{
    public class BusinessRegistry : Registry
    {
        public BusinessRegistry()
        {
            For<IBusinessLogic>().Use<BusinessLogic>();
            For<IService<Category>>().Use<CategoryService>();
            For<IService<File>>().Use<FileService>();
            For<IService<UserRole>>().Use<UserRoleService>();
            For<IService<User>>().Use<UserService>();
            For<IService<Benefits>>().Use<BenefitsService>();
            For<IService<FileAccess>>().Use<FileAccessService>();
            For<IService<FileUrl>>().Use<FileUrlService>();
            For<IService<UserClaims>>().Use<UserClaimsService>();
            For<IService<UserFriends>>().Use<UserFriendsService>();
            For<IService<UsersBenefits>>().Use<UsersBenefitsService>();

            Forward<IBusinessLogic, BusinessLogic>();
            Forward<IService<Category>, CategoryService>();
            Forward<IService<File>, FileService>();
            Forward<IService<UserRole>, UserRoleService>();
            Forward<IService<User>, UserService>();
            Forward<IService<Benefits>, BenefitsService>();
            Forward<IService<FileAccess>, FileAccessService>();
            Forward<IService<FileUrl>, FileUrlService>();
            Forward<IService<UserClaims>, UserClaimsService>();
            Forward<IService<UserFriends>, UserFriendsService>();
            Forward<IService<UsersBenefits>, UsersBenefitsService>();
        }
    }
}
