using FileSharing.Entities.Core;

namespace FileSharing.DAL.Interfaces
{
    public interface IDataAccess
    {
        IRepository<Category> Categories { get; set; }

        IRepository<File> Files { get; set; }

        IRepository<UserRole> UserRoles { get; set; }

        IRepository<User> Users { get; set; }

        IRepository<Benefits> Benefits { get; set; }

        IRepository<FileAccess> FileAccesses { get; set; }

        IRepository<FileUrl> FileUrls { get; set; }

        IRepository<UserClaims> UserClaims { get; set; }

        IRepository<UserFriends> UserFriends { get; set; }

        IRepository<UsersBenefits> UserBenefits { get; set; }
    }
}
