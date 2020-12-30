using DomainLayer;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GeoService.Controllers
{
    [Route("api/[controller]")]
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

        #endregion
        #region Country
        #endregion
    }
}
