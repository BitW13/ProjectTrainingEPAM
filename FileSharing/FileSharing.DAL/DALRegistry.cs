using FileSharing.DAL.Context;
using FileSharing.DAL.Interfaces;
using FileSharing.DAL.Models;
using FileSharing.Entities.Core;
using StructureMap;

namespace FileSharing.DAL
{
    public class DALRegistry : Registry
    {
        public DALRegistry()
        {
            For<IDataAccess>().Use<DataAccess>();
            For<Interfaces.IContext>().Use<FileSharingContext>();
            For<IRepository<Category>>().Use<CategoryRepository>();
            For<IRepository<File>>().Use<FileRepository>();
            For<IRepository<UserRole>>().Use<UserRoleRepository>();
            For<IRepository<User>>().Use<UserRepository>();
            For<IRepository<Benefits>>().Use<BenefitsRepository>();
            For<IRepository<FileAccess>>().Use<FileAccessRepository>();
            For<IRepository<FileUrl>>().Use<FileUrlRepository>();
            For<IRepository<UserClaims>>().Use<UserClaimsRepository>();
            For<IRepository<UserFriends>>().Use<UserFriendRepository>();
            For<IRepository<UsersBenefits>>().Use<UserBenefitsRepository>();

            Forward<IDataAccess, DataAccess>();
            Forward<Interfaces.IContext, FileSharingContext>();
            Forward<IRepository<Category>, CategoryRepository>();
            Forward<IRepository<File>, FileRepository>();
            Forward<IRepository<UserRole>, UserRoleRepository>();
            Forward<IRepository<User>, UserRepository>();
            Forward<IRepository<Benefits>, BenefitsRepository>();
            Forward<IRepository<FileAccess>, FileAccessRepository>();
            Forward<IRepository<FileUrl>, FileUrlRepository>();
            Forward<IRepository<UserClaims>, UserClaimsRepository>();
            Forward<IRepository<UserFriends>, UserFriendRepository>();
            Forward<IRepository<UsersBenefits>, UserBenefitsRepository>();
        }
    }
}
