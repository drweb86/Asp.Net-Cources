using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using SK.CW.Dal;
using SK.CW.ViewModels;

namespace SK.CW.BL
{
    public class UsersService : IUsersService
    {
        private static readonly IMapper _mapper;

        static UsersService()
        {
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<Detail, DetailViewModel>();
                cfg.CreateMap<DetailViewModel, Detail>();

                cfg.CreateMap<User, UserViewModel>();
                cfg.CreateMap<UserViewModel, User>();
            });
            _mapper = config.CreateMapper();
        }

        public IEnumerable<UserViewModel> GetUsers()
        {
            using (var dbContext = new UsersDatabaseEntities())
            {
                return dbContext.Users
                    .ToArray() // finalize query
                    .Select(dbUser=>_mapper.Map(dbUser, new UserViewModel()))
                    .ToArray();
            }
        }

        public DetailViewModel GetDetail(int id)
        {
            using (var dbContext = new UsersDatabaseEntities())
            {
                return _mapper.Map(
                    dbContext.Details.First(dbDetail => dbDetail.Details_UID == id),
                    new DetailViewModel());
            }
        }

        public void AddUser(UserViewModel user, DetailViewModel detail)
        {
            using (var dbContext = new UsersDatabaseEntities())
            {
                var dbDetail = dbContext.Details.Add(_mapper.Map(detail, new Detail()));
                user.Details_UID = dbDetail.Details_UID;

                dbContext.Users.Add(_mapper.Map(user, new User()));

                dbContext.SaveChanges();
            }
        }

        public void DeleteUser(int id)
        {
            using (var dbContext = new UsersDatabaseEntities())
            {
                dbContext.Users.Remove(dbContext.Users.First(dbUser => dbUser.User_UID == id));

                dbContext.SaveChanges();
            }
        }
    }
}
