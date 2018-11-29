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
using DevelopersDirectory.Interfaces;
using DevelopersDirectory.Models;

namespace DevelopersDirectory.Controllers
{
    [RoutePrefix("api/developers")]
    public class DevelopersController : ApiController
    {
        private readonly IUnitOfWork _unitOfWork;

        public DevelopersController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        //Get all developers directory etries
        [HttpGet, ActionName("developerdirectory")]
        public async Task<IHttpActionResult> Developers()
        {
            var developersEntries = await _unitOfWork.DevelopersRepository.ListOfDevelopers();
            return Ok(developersEntries);
        }
        //Create Developer
        //Get Specific Developer
        //Update Specific Developer
        //Delete Specific Developer
        
       
        
    }
}