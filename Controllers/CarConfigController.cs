using System.Collections.Generic;
using System.Threading.Tasks;
using car_webapi.db.context;
using car_webapi.db.models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Linq;
using car_webapi.request;
using car_webapi.response;
using System;

namespace car_webapi.controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarConfigController : ControllerBase
    {
        private readonly CarContext context;
        private readonly ILogger logger;

        public CarConfigController(CarContext context)
        {
            this.context = context;
        }

        // Get alle Motoren
        [HttpGet("motor")]
        [ProducesResponseType(200)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public ActionResult<List<Motor>> GetAllMotor()
        {
            return this.context.Motor.ToList();
        }

        [HttpGet("motor/{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public ActionResult<Motor> GetMotor(int id)
        {
            return this.context.Motor.Where(x => x.Id == id).FirstOrDefault();
        }

        // Get alle Lackierungen
        [HttpGet("lackierung")]
        [ProducesResponseType(200)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public ActionResult<List<Lackierung>> GetAllLackierung()
        {
            return this.context.Lackierung.ToList();
        }

        [HttpGet("lackierung/{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(204)]
        public ActionResult<Lackierung> GetLackierung(int id)
        {
            return this.context.Lackierung.Where(x => x.Id == id).FirstOrDefault();
        }

        // Get alle Felgen
        [HttpGet("felgen")]
        [ProducesResponseType(200)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public ActionResult<List<Felgen>> GetAllFelgen()
        {
            return this.context.Felgen.ToList();
        }

        [HttpGet("felgen/{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(204)]
        public ActionResult<Felgen> GetFelgen(int id)
        {
            return this.context.Felgen.Where(x => x.Id == id).FirstOrDefault();
        }

        // Get alle Sonderausstrattungen
        [HttpGet("sonderausstattung")]
        [ProducesResponseType(200)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public ActionResult<List<Sonderausstattung>> GetAllSonderausstattung()
        {
            return this.context.Sonderausstattung.ToList();
        }

        [HttpGet("sonderausstattung/{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(204)]
        public ActionResult<Sonderausstattung> GetSonderausstattung(int id)
        {
            return this.context.Sonderausstattung.Where(x => x.Id == id).FirstOrDefault();
        }

        // Get alle Exceptions
        [HttpGet("exclusion")]
        [ProducesResponseType(200)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public ActionResult<List<Exclusion>> GetAllExclusion()
        {
            return this.context.Exclusion.ToList();
        }

        [HttpGet("exclusion/{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(204)]
        public ActionResult<List<Exclusion>> GetExclusion(int id)
        {
            return this.context.Exclusion.Where(x => x.Sonderausstattung == id)?.ToList();
        }

        // Get alle Auftraege
        [HttpGet("auftrag")]
        [ProducesResponseType(200)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public ActionResult<List<Auftrag>> GetAllAuftrag()
        {
            return this.context.Auftrag.ToList();
        }

        // Get Auftrag nach Guid
        [HttpPost("auftrag")]
        [ProducesResponseType(200)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public ActionResult<AuftragGetByGuidResponse> GetAuftragByGuid(AuftragByGuidRequest request)
        {
            var auftrag = this.context.Auftrag.Where(x => x.Guid == request.Guid).FirstOrDefault();
            var ausstattung = this.context.Ausstattung.Where(x => x.Auftrag == auftrag.Id)?.ToList();
            return new AuftragGetByGuidResponse() { Auftrag = auftrag, Ausstattung = ausstattung };
        }

        // Post Auftrag (und Ausstattung)
        [HttpPost("auftrag/create")]
        [ProducesResponseType(201)]
        [ProducesResponseType(500)]
        public async Task<ActionResult<AuftragCreateResponse>> CreateAuftrag(AuftragCreateRequest request)
        {
            try
            {
                var guid = Guid.NewGuid();
                decimal totalPrice = 0;
                foreach (var ausstattung in request.Sonderausstattung)
                {
                    totalPrice += ausstattung.Price;
                }

                var newAuftrag = this.context.Auftrag.Add(
                                    new Auftrag()
                                    {
                                        Felgen = request.Felgen.Id,
                                        Motor = request.Motor.Id,
                                        Lackierung = request.Lackierung.Id,
                                        Guid = guid.ToString(),
                                        OrderDate = DateTime.Now,
                                        TotalPrice = totalPrice +
                                                        request.Felgen.Price +
                                                        request.Motor.Price +
                                                        request.Lackierung.Price
                                    }
                );

                await this.context.SaveChangesAsync();
                foreach (var ausstattung in request.Sonderausstattung)
                {
                    this.context.Ausstattung.Add(new Ausstattung() { Auftrag = newAuftrag.Entity.Id, Sonderausstattung = ausstattung.Id });
                }
                await this.context.SaveChangesAsync();
                return Ok(new AuftragCreateResponse() { Guid = guid.ToString() });
            }
            catch (System.Exception ex)
            {
                return StatusCode(500, ex.InnerException.Message);
            }
        }
    }
}