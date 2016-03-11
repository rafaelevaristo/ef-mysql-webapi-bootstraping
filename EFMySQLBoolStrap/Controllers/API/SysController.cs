using EFMySQLBoolStrap.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace EFMySQLBoolStrap.Controllers.API
{
    [RoutePrefix("api/sys")]
    public class SysController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        [Route("deletebd")]
        public string GetDeleteBD()
        {
            db.Database.Delete();
            return "OK";
        }
    }
}
