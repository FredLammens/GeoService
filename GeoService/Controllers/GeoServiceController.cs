using DataLayer;
using DomainLayer;
using DomainLayer.BaseClasses;
using GeoService.BaseClasses;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GeoService.Controllers
{
    [Route("api/Continent")]
    [ApiController]
    public class GeoServiceController : ControllerBase
    {
        /// <summary>
        /// represents a type used for storage and methods of repository
        /// </summary>
        private IDomainController dc;

        public GeoServiceController(IDomainController dc)
        {
            this.dc = dc;
        }
        #region Continent
        [HttpGet("{id}")]
        public ActionResult<RContinentOut> GetContinent(int id) 
        {
            try
            {
                return Ok(Mapper.FromContinentToRContinentOut(dc.GetContinent(id)));
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }
        [HttpPost]
        public ActionResult<RContinentOut> PostContinent([FromBody] RContinentIn rContinentIn) 
        {
            try
            {
                Continent toAdd = Mapper.FromRContinentInToContinent(rContinentIn);
                Continent toReturn = dc.AddContinent(toAdd);
                return CreatedAtAction(nameof(GetContinent),new { id = toReturn.Id }, Mapper.FromContinentToRContinentOut(toReturn));
            }
            catch (Exception ex) 
            {
                return NotFound(ex.Message);
            }
        }
        [HttpPut("{id}")]
        public ActionResult<RContinentOut> PutContinent(int id, [FromBody] RContinentIn rContinentIn) 
        {
            try
            {    
                if (dc.IsInContinents(id))
                {
                    Continent updatedContinent = dc.UpdateContinent(id, Mapper.FromRContinentInToContinent(rContinentIn));
                    return Ok(updatedContinent);
                }
                    Continent addedContinent = dc.AddContinent(Mapper.FromRContinentInToContinent(rContinentIn));
                    return CreatedAtAction(nameof(GetContinent), new { id = id }, Mapper.FromContinentToRContinentOut(addedContinent));
            }
            catch (Exception ex) 
            {
                return NotFound(ex.Message);
            }
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteClient(int id) 
        {
            try
            {
                dc.DeleteContinent(id);
                return NoContent();
            }
            catch (Exception ex) 
            {
                return NotFound(ex.Message);
            }
        }
        #endregion
        #region Country
        #endregion
    }
}
