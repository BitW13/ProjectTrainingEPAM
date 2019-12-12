using FileSharing.Entities.Core;

namespace FileSharing.Business.Interfaces
{
    public interface IBusinessLogic
    {
        IService<Benefits> Benefits { get; set; }

        IService<FileAccess> FileAccesses { get; set; }

        IService<FileUrl> FileUrls { get; set; }

        IService<Category> Categories { get; set; }

        IService<File> Files { get; set; }

        IService<UserClaims> UserClaims { get; set; }

        IService<UserFriends> UserFriends { get; set; }

        IService<UsersBenefits> UserBenefits { get; set; }

        IService<UserRole> UserRoles { get; set; }

        IService<User> Users { get; set; }
    }
}
