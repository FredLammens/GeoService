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
        [HttpPost]
        public ActionResult<RContinentOut> PostContinent([FromBody] RContinentIn rContinentIn) 
        {
            try
            {
                Continent toAdd = Mapper.FromRContinentInToContinent(rContinentIn);
                int id = dc.AddContinent(toAdd);
                return Mapper.FromContinentToRContinentOut(dc.GetContinent(id));
            }
            catch (Exception ex) 
            {
                return NotFound(ex.Message); //TODO: change to 404 exception
            }
        }
        #endregion
        #region Country
        #endregion
    }
}
