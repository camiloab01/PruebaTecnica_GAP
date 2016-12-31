using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SuperZapatos_Client.Models
{
    public class StoreModel
    {
        /// <summary>
        /// Identifier for the store entity
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