using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using DevelopersDirectory.DAL;
using DevelopersDirectory.Models;

namespace DevelopersDirectory.Controllers
{
    public class DevelopersController : ApiController
    {
        private DirectoryContext db = new DirectoryContext();

        //Create Developer
        //Get Specific Developer
        //Update Specific Developer
        //Delete Specific Developer
        // DELETE: api/Developers/5
       
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool DeveloperExists(int id)
        {
            return db.Developers.Count(e => e.DeveloperId == id) > 0;
        }
    }
}