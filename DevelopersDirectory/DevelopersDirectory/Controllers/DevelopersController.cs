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
using DevelopersDirectory.BindingModels;
using DevelopersDirectory.DAL;
using DevelopersDirectory.Interfaces;
using DevelopersDirectory.Models;
using Elmah;
using Microsoft.Ajax.Utilities;

namespace DevelopersDirectory.Controllers
{
    [RoutePrefix("api/developers")]
    public class DevelopersController : ApiController
    {
        private readonly IDevelopersRepository _developersRepository;

        public DevelopersController(IDevelopersRepository developersRepository)
        {
            _developersRepository = developersRepository;
        }

        //Get all developers directory etries
        [HttpGet, ActionName("developerdirectory")]
        public IHttpActionResult Developers()
        {
            var developersEntries = _developersRepository.ListOfDevelopers();
            return Ok(developersEntries);
        }

        //Create Developer
        [HttpPost, ActionName("developerdirectory")]
        public async Task<IHttpActionResult> Developers([FromBody]DeveloperDirectoryBindingModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest("Invalid Data entry");

            if (model.Name.IsNullOrWhiteSpace())
                return BadRequest("Specify Name of the Developer");

            if (model.CategoryId == 0)
                return BadRequest("Specify the Category Id");


            
            await _developersRepository.CreateDeveloperEntry(model);
            try
            {
                return StatusCode(HttpStatusCode.Created);
            }
            catch (Exception e)
            {
                ErrorSignal.FromCurrentContext().Raise(e);
                return StatusCode(HttpStatusCode.InternalServerError);
            }
        }

        //Get Specific Developer
        [HttpGet, Route("singleentry")]
        public async Task<IHttpActionResult> SingleEntry(int? id)
        {
            if (id == null)
                return BadRequest("Supply Id of Developer Entry");

            try
            {

                var developerEntry = await _developersRepository.SingleDeveloper(id);
                return Ok(developerEntry);
            }
            catch (Exception e)
            {
                ErrorSignal.FromCurrentContext().Raise(e);
                return NotFound();
            }
        }


        //Update Specific Developer
        [HttpPut, ActionName("developerdirectory")]
        public async Task<IHttpActionResult> UpdateDeveloper(int? id, [FromBody]DeveloperDirectoryBindingModel model)
        {
            if (id == null)
                return BadRequest("Supply Id Of developer");
            
            try
            {
                await _developersRepository.EditDeveloperEntry(id, model);
                return Ok("Updated Successfully");
            }
            catch (Exception e)
            {
                return StatusCode(HttpStatusCode.InternalServerError);
            }

        }

        //Delete Specific Developer
       [HttpDelete, ActionName("developerdirectory")]
        public async Task<IHttpActionResult> DeleteDeveloper(int? id)
        {
            if (id == null)
                return BadRequest("Supply Id of developer deleted");

            try
            {
                await _developersRepository.DeleteDeveloper(id);
                return Ok("Record Deleted Successfully");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

        }

        //Get categories as well as developers in the category
        [HttpGet, ActionName("category")]
        public async Task<IHttpActionResult> Category()
        {
            var category = await _developersRepository.DeveloperCategories();
            return Ok(category);

        }

        [HttpGet, ActionName("category")]
        public async Task<IHttpActionResult> Category(int? id)
        {
            if (id == null)
                return BadRequest("Supply Id Of the Category");


            var category = await _developersRepository.DeveloperCategories(id);
            return Ok(category);

        }

        [HttpGet, ActionName("category")]
        public async Task<IHttpActionResult> Category(string categoryName)
        {
            try
            {
                var category = await _developersRepository.DeveloperCategories(categoryName);
                return Ok(category);
            }
            catch (Exception e)
            {
                ErrorSignal.FromCurrentContext().Raise(e);
                return NotFound();
            }

        }

    }
}