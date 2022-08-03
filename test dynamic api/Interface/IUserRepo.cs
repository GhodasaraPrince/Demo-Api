using Microsoft.EntityFrameworkCore;
using test_dynamic_api.Models;

namespace test_dynamic_api.Interface
{
    public class IUserRepo : IDataContext
    {
        public readonly DataContext _con;
        public IUserRepo(DataContext con)
        {
            _con = con;
        }
        public async Task<List<User>> GetAllUser()
        {
            return await _con.User.ToListAsync();
        }

        public async Task<List<User>> AddUser(User user)
        {
            await _con.User.AddAsync(user);
            await _con.SaveChangesAsync();
            return await _con.User.ToListAsync();
        }

        public async Task<List<User>> UpdateUser(User user)
        {
            var data = await _con.User.FindAsync(user.Id);
            if (data != null)
            {
                data.FirstName = user.FirstName;
                data.LastName = user.LastName;
                data.Age = user.Age;
                data.City = user.City;
                await _con.SaveChangesAsync();
            }
            return await _con.User.ToListAsync();
        }

        public async Task<List<User>> GetById(int id)
        {
            var data = await _con.User.FindAsync(id);
            List<User> temp = new List<User>();
            temp.Add(data);
            return temp;
        }
    }
}
