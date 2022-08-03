using test_dynamic_api.Models;


    public interface IDataContext
    {
        Task<List<User>> GetAllUser();

        Task<List<User>> AddUser(User User);

        Task<List<User>> UpdateUser(User User);

        Task<List<User>> GetById(int id);
    }
