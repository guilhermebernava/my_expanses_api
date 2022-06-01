using Database.Data;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    public class ApiController : ControllerBase
    {
        protected readonly ExpanseContext Db;
        public ApiController(ExpanseContext db)
        {
            Db = db;
        }

    }
}

