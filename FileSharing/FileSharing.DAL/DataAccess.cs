using FileSharing.DAL.Interfaces;
using FileSharing.Entities.Core;

namespace FileSharing.DAL
{
    public class DataAccess : IDataAccess
    {
        public DataAccess(IRepository<Category> categories,
                            IRepository<File> files,
                            IRepository<UserRole> userRoles,
                            IRepository<User> users,
                            IRepository<Benefits> benefits,
                            IRepository<FileAccess> fileAccesses,
                            IRepository<FileUrl> fileUrls,
                            IRepository<UserClaims> userClaims,
                            IRepository<UserFriends> userFriends,
                            IRepository<UsersBenefits> usersBenefits)
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

        public IRepository<Category> Categories { get; set; }

        public IRepository<File> Files { get; set; }

        public IRepository<UserRole> UserRoles { get; set; }

        public IRepository<User> Users { get; set; }

        public IRepository<Benefits> Benefits { get; set; }

        public IRepository<FileAccess> FileAccesses { get; set; }

        public IRepository<FileUrl> FileUrls { get; set; }

        public IRepository<UserClaims> UserClaims { get; set; }

        public IRepository<UserFriends> UserFriends { get; set; }

        public IRepository<UsersBenefits> UserBenefits { get; set; }
    }
}
