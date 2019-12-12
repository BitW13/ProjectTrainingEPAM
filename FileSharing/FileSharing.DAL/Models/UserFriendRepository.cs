using FileSharing.DAL.Interfaces;
using FileSharing.Entities.Core;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace FileSharing.DAL.Models
{
    public class UserFriendRepository : IRepository<UserFriends>
    {
        private readonly IContext _context;

        public UserFriendRepository(IContext context)
        {
            _context = context;
        }

        public void Create(UserFriends item)
        {
            var parameters = new List<SqlParameter>
            {
                _context.CreateParameter("@UserId", item.UserId, DbType.Int32),
                _context.CreateParameter("@FriendId", item.FriendId, DbType.Int32)
            };

            _context.Insert("CreateUserFriends", CommandType.StoredProcedure, parameters.ToArray());
        }

        public void Delete(int? id)
        {
            var parameters = new List<SqlParameter>
            {
                _context.CreateParameter("@Id", id, DbType.Int32)
            };

            _context.Delete("DeleteUserFriends", CommandType.StoredProcedure, parameters.ToArray());
        }

        public IEnumerable<UserFriends> GetAll()
        {
            var userFriendsDataTable = _context.GetDataTable("GetUserFriends", CommandType.StoredProcedure);
            var userFriends = new List<UserFriends>();
            foreach (DataRow row in userFriendsDataTable.Rows)
            {
                var userFriend = new UserFriends
                {
                    Id = Convert.ToInt32(row["Id"]),
                    UserId = Convert.ToInt32(row["UserId"]),
                    FriendId = Convert.ToInt32(row["FriendId"])
                };
                userFriends.Add(userFriend);
            }
            return userFriends;
        }

        public UserFriends GetElement(UserFriends item)
        {
            throw new NotImplementedException();
        }

        public UserFriends GetElementById(int? id)
        {
            var parameters = new List<SqlParameter>
            {
                _context.CreateParameter("@Id", id, DbType.Int32)
            };

            var userFriendsDataTable = _context.GetDataTable("GetUserFriendsById", CommandType.StoredProcedure, parameters.ToArray());

            var userFriends = new List<UserFriends>();
            foreach (DataRow row in userFriendsDataTable.Rows)
            {
                var userFriend = new UserFriends
                {
                    Id = Convert.ToInt32(row["Id"]),
                    FriendId = Convert.ToInt32(row["FriendId"]),
                    UserId = Convert.ToInt32(row["UserId"])
                };
                userFriends.Add(userFriend);
            }
            return userFriends[0];
        }

        public void Update(UserFriends item)
        {
            var parameters = new List<SqlParameter>
            {
                _context.CreateParameter("@Id", item.Id, DbType.Int32),
                _context.CreateParameter("@FriendId", item.FriendId, DbType.Int32),
                _context.CreateParameter("@UserId", item.UserId, DbType.Int32)
            };

            _context.Update("UpdateUserFriends", CommandType.StoredProcedure, parameters.ToArray());
        }
    }
}
