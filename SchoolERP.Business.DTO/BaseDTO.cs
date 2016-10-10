//-----------------------------------------------------------------------
// <copyright file="BaseDTO.cs" company="OTIS">
//     Copyright (c) Sachin LLC. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace SchoolERP.Business.DTO
{
    using System;
    using System.Globalization;

    /// <summary>
    /// The Base Data Transfer Object Class.
    /// </summary>
    public class BaseDTO
    {
        /// <summary>
        /// Gets the modified date time string.
        /// </summary>
        /// <value>
        /// The modified date time string.
        /// </value>
        public string ModifiedDateTimeStr
        {
            get
            {
                return this.ModifiedDateTime.ToString("yyyy MM dd HH mm ss", CultureInfo.InvariantCulture);
            }
        }

        /// <summary>
        /// Gets the created date time string.
        /// </summary>
        /// <value>
        /// The created date time string.
        /// </value>
        public string CreatedDateTimeStr
        {
            get
            {
                return this.CreatedDateTime.ToString("yyyy MM dd HH mm ss", CultureInfo.InvariantCulture);
            }
        }

        /// <summary>
        /// Gets or sets the modified date time.
        /// </summary>
        /// <value>
        /// The modified date time.
        /// </value>
        public DateTime ModifiedDateTime { get; set; }

        /// <summary>
        /// Gets or sets the created date time.
        /// </summary>
        /// <value>
        /// The created date time.
        /// </value>
        public DateTime CreatedDateTime { get; set; }
    }
}
