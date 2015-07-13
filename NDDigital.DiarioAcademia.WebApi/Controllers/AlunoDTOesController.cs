using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using NDDigital.DiarioAcademia.Aplicacao.DTOs;
using NDDigital.DiarioAcademia.WebApi.Models;

namespace NDDigital.DiarioAcademia.WebApi.Controllers
{
    public class AlunoDTOesController : ApiController
    {
        private NDDigitalDiarioAcademiaWebApi db = new NDDigitalDiarioAcademiaWebApi();

        // GET: api/AlunoDTOes
        public IQueryable<AlunoDTO> GetAlunoDTOes()
        {
            return db.AlunoDTOes;
        }

        // GET: api/AlunoDTOes/5
        [ResponseType(typeof(AlunoDTO))]
        public IHttpActionResult GetAlunoDTO(int id)
        {
            AlunoDTO alunoDTO = db.AlunoDTOes.Find(id);
            if (alunoDTO == null)
            {
                return NotFound();
            }

            return Ok(alunoDTO);
        }

        // PUT: api/AlunoDTOes/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutAlunoDTO(int id, AlunoDTO alunoDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != alunoDTO.Id)
            {
                return BadRequest();
            }

            db.Entry(alunoDTO).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AlunoDTOExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/AlunoDTOes
        [ResponseType(typeof(AlunoDTO))]
        public IHttpActionResult PostAlunoDTO(AlunoDTO alunoDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.AlunoDTOes.Add(alunoDTO);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = alunoDTO.Id }, alunoDTO);
        }

        // DELETE: api/AlunoDTOes/5
        [ResponseType(typeof(AlunoDTO))]
        public IHttpActionResult DeleteAlunoDTO(int id)
        {
            AlunoDTO alunoDTO = db.AlunoDTOes.Find(id);
            if (alunoDTO == null)
            {
                return NotFound();
            }

            db.AlunoDTOes.Remove(alunoDTO);
            db.SaveChanges();

            return Ok(alunoDTO);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool AlunoDTOExists(int id)
        {
            return db.AlunoDTOes.Count(e => e.Id == id) > 0;
        }
    }
}