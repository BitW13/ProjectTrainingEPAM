using FileSharing.Business.Interfaces;
using FileSharing.Entities.Core;

namespace FileSharing.Services
{
    public class BusinessLogic : IBusinessLogic
    {
        public BusinessLogic(IService<Category> categories,
                            IService<File> files,
                            IService<UserRole> userRoles,
                            IService<User> users,
                            IService<Benefits> benefits,
                            IService<FileAccess> fileAccesses,
                            IService<FileUrl> fileUrls,
                            IService<UserClaims> userClaims,
                            IService<UserFriends> userFriends,
                            IService<UsersBenefits> usersBenefits)
        {
            Categories = categories;
            Files = files;
            UserRoles = userRoles;
            Users = users;
            Benefits = benefits;
            FileAccesses = fileAccesses;
            FileUrls = fileUrls;
            UserClaims = userClaims;
            UserFriends = userFriends;
            UserBenefits = usersBenefits;
        }

        public IService<Category> Categories { get; set; }
        public IService<File> Files { get; set; }
        public IService<UserRole> UserRoles { get; set; }
        public IService<User> Users { get; set; }
        public IService<Benefits> Benefits { get; set; }
        public IService<FileAccess> FileAccesses { get; set; }
        public IService<FileUrl> FileUrls { get; set; }
        public IService<UserClaims> UserClaims { get; set; }
        public IService<UserFriends> UserFriends { get; set; }
        public IService<UsersBenefits> UserBenefits { get; set; }
    }
}
