using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using test_dynamic_api.Models;

namespace test_dynamic_api.Controllers
{
    [Authorize]
    public class CreateController : Controller
    {

        public readonly DataContext _context;
        public CreateController(DataContext context)
        {
            _context = context;
        }

        public async Task<string> CreateTable(CreateModel req)
        {
            try
            {
                _context.CreateTableData.Add(req);
                await _context.SaveChangesAsync();
                for (int i = 0; i < req.Fields.Count; i++)
                {
                    req.Fields[i].TableIdRef = req.Id;
                    _context.CreateTableField.Add(req.Fields[i]);
                    await _context.SaveChangesAsync();
                }
                return "Success";
            }
            catch (Exception ex)
            {
                return "Failed";
            }
           
        }
        

    }
}
