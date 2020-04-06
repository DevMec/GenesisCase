using Genesis.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Genesis.Controllers
{
    [RoutePrefix("Contact")]
    public class ContactController : ApiController
    {
        IContactDomain _contactDomain;
        public ContactController(IContactDomain contactDomain)
        {
            _contactDomain = contactDomain;
        }

        [HttpGet]
        [Route("GetAll")]
        public IHttpActionResult GetAll()
        {
            IEnumerable<Contact> result;
            try
            {
                result = _contactDomain.GetAll();
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
            Contact result;
            try
            {
                result = _contactDomain.GetById(id);
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
        public IHttpActionResult Save([FromBody]  Contact contact)
        {
            Contact result;
            try
            {
                result = _contactDomain.Save(contact);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
                throw;
            }
        }

        [HttpPost]
        [Route("AddCompany")]
        public IHttpActionResult AddCompany([FromUri] Guid contactId, [FromUri]  Guid companyId)
        {
            Contact result;
            try
            {
                result = _contactDomain.AddCompany(contactId, companyId);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
                throw;
            }
        }

        [HttpPost]
        [Route("RemoveCompany")]
        public IHttpActionResult RemoveCompany([FromUri] Guid contactId, [FromUri]  Guid companyId)
        {
            Contact result;
            try
            {
                result = _contactDomain.RemoveCompany(contactId, companyId);
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
        // DELETE: api/Contact/5
        public IHttpActionResult Delete(Guid id)
        {
            try
            {
                _contactDomain.Delete(id);
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
