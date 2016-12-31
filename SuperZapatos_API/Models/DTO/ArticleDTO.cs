using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SuperZapatos_API.Models.DTO
{
    public class ArticleDTO
    {
        /// <summary>
        /// Identifier for the article 
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Name of the article
        /// </summary>
        public String Name { get; set; }

        /// <summary>
        /// Description of the article
        /// </summary>
        public String Description { get; set; }

        /// <summary>
        /// Price of the article
        /// </summary>
        public double Price { get; set; }

        /// <summary>
        /// Total of articles left in shelf
        /// </summary>
        public int Total_in_shelf { get; set; }

        /// <summary>
        /// Total of articles left in vault
        /// </summary>
        public int Total_in_vault { get; set; }

        /// <summary>
        /// Store name where the article is
        /// </summary>
        public String Store_name { get; set; }
    }
}