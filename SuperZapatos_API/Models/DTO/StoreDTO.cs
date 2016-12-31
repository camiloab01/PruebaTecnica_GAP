using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SuperZapatos_API.Models.DTO
{
    /// <summary>
    /// Store Data Transfer Object
    /// </summary>
    public class StoreDTO
    {
        /// <summary>
        /// Identifier for the store
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Name of the store
        /// </summary>
        public String Name { get; set; }

        /// <summary>
        /// Address of the store
        /// </summary>
        public String Address { get; set; }
    }
}