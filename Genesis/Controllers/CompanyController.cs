using Genesis.Domain;
using Genesis.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Genesis.Controllers
{

    [RoutePrefix("Company")]
    public class CompanyController : ApiController
    {
        ICompanyDomain _companyDomain;
        public CompanyController(ICompanyDomain companyDomain)
        {
            _companyDomain = companyDomain;
        }

        [HttpGet]
        [Route("GetAll")]
        public IHttpActionResult GetAll()
        {
            IEnumerable<Company> result;
            try
            {
                result = _companyDomain.GetAll();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
                throw;
            }
        }

        [HttpGet]
        [Route("GetById")]
        public IHttpActionResult Get(Guid id)
        {
            Company result;
            try
            {
                result = _companyDomain.GetById(id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
                throw;
            }
        }

        [HttpPost]
        [Route("Save")]
        public IHttpActionResult Save([FromBody]  Company company)
        {
            Company result;
            try
            {
                result = _companyDomain.Save(company);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
                throw;
            }
        }

        [HttpPost]
        [Route("AddContact")]
        public IHttpActionResult AddContact([FromUri] Guid contactId, [FromUri]  Guid companyId)
        {
            Company result;
            try
            {
                result = _companyDomain.AddContact(companyId, contactId);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
                throw;
            }
        }

        [HttpPost]
        [Route("RemoveContact")]
        public IHttpActionResult RemoveContact([FromUri] Guid contactId, [FromUri]  Guid companyId)
        {
            Company result;
            try
            {
                result = _companyDomain.RemoveContact(companyId, contactId);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
                throw;
            }
        }


        [HttpDelete]
        [Route("Delete")]
        // DELETE: api/Company/5
        public IHttpActionResult Delete(Guid id)
        {
            try
            {
                _companyDomain.Delete(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
                throw;
            }
        }
    }
}
