using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SuperZapatos_API.Models
{
    /// <summary>
    /// Represents the article entity
    /// </summary>
    public class Article
    {
        /// <summary>
        /// Identifier for the article entity
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Name of the article
        /// </summary>
        [Required]
        public String Name { get; set; }

        /// <summary>
        /// Description of the article
        /// </summary>
        [Required]
        public String Description { get; set; }

        /// <summary>
        /// Price of the article
        /// </summary>
        [Required]
        public double Price { get; set; }

        /// <summary>
        /// Total of articles left in shelf
        /// </summary>
        public int Total_in_shelf { get; set; }

        /// <summary>
        /// Total of articles left in vault
        /// </summary>
        public int Total_in_vault { get; set; }

        #region Foreign property (Store)

        /// <summary>
        /// Id of the store in which the article is
        /// </summary>
        public int StoreId { get; set; }

        /// <summary>
        /// Store in which the article is
        /// </summary>
        public Store Store { get; set; }

        #endregion
    }
}