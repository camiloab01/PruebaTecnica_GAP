using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SuperZapatos_API.Models
{
    /// <summary>
    /// Represents the store entity
    /// </summary>
    public class Store
    {
        /// <summary>
        /// Identifier for the store entity
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Name of the store
        /// </summary>
        [Required]
        public String Name { get; set; }

        /// <summary>
        /// Address of the store
        /// </summary>
        [Required]
        public String Address { get; set; }
    }
}