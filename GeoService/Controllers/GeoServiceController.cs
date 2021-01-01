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
        [HttpGet("{continentId}/Country/{countryId}")]
        public ActionResult<RCountryOut> GetCountry(int continentId, int countryId) 
        {
            try
            {
                return Ok(dc.GetCountry(continentId, countryId));
            }
            catch (Exception ex) 
            {
                return NotFound(ex.Message);
            }
        }

        [HttpPost("{continentId}/Country")]
        public ActionResult<RCountryOut> PostCountry(int continentId, [FromBody] RCountryIn rCountryIn) 
        {
            try
            {
                Continent continent = dc.GetContinent(continentId);
                Country added = dc.AddCountry(continentId,Mapper.FromRCountryInToCountry(rCountryIn,continent));
                int countryId = (int)added.Id;
                return CreatedAtAction(nameof(GetCountry), new { continentId, countryId },Mapper.FromCountryToRCountryOut(added));
            }
            catch (Exception ex) 
            {
                return NotFound(ex.Message);
            }
        }
        [HttpPut("{continentId}/Country/{countryId}")]
        public ActionResult<RCountryOut> PutCountry(int continentId, int countryId, [FromBody] RCountryIn rCountryIn) 
        {
            try
            {
                if (dc.IsInCountry(continentId, countryId))
                {
                    Country updated = dc.UpdateCountry(continentId, countryId, Mapper.FromRCountryInToCountry(rCountryIn, dc.GetContinent(continentId)));
                    return Ok(Mapper.FromCountryToRCountryOut(updated));
                }
                Continent continent = dc.GetContinent(continentId);
                Country added = dc.AddCountry(continentId, Mapper.FromRCountryInToCountry(rCountryIn, continent));
                return CreatedAtAction(nameof(GetCountry), new { continentId, id = added.Id },Mapper.FromCountryToRCountryOut(added));
            }
            catch (Exception ex) 
            {
                return NotFound(ex.Message);
            }
        }
        [HttpDelete("{continentId}/Country/{countryId}")]
        public IActionResult DeleteCountry(int continentId, int countryId) 
        {
            try
            {
                dc.DeleteCountry(continentId, countryId);
                return NoContent();
            }
            catch (Exception ex) 
            {
                return NotFound(ex);
            }
        }
        #endregion
    }
}
