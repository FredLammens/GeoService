using System;
using System.Collections.Generic;
using System.Text;

namespace DataLayer
{
    public class GeoServiceTestContext : GeoServiceContext
    {
        /// <summary>
        /// uses the base constructor of context and sets connectionstring to TestDB
        /// </summary>
        public GeoServiceTestContext() : base("TestDB") { }
        /// <summary>
        /// creates testcontext and keepsexisting DB depending on parameter
        /// </summary>
        /// <param name="keepExistingDB">clears DB if false</param>
        public GeoServiceTestContext(bool keepExistingDB = false) : base("TestDB")
        {
            if (keepExistingDB)
                Database.EnsureCreated();
            else 
            {
                Database.EnsureDeleted();
                Database.EnsureCreated();
            }
        }
    }
}
