//-----------------------------------------------------------------------
// <copyright file="OperationResult.cs" company="OTIS">
//     Copyright (c) Sachin LLC. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace SchoolERP.DTO
{
    /// <summary>
    /// 
    /// </summary>
    public class OperationResult
    {
        /// <summary>
        /// Gets or sets a value indicating whether the item is true or not.
        /// </summary>
        /// <value>
        ///   <c>true</c> if success; otherwise, <c>false</c>.
        /// </value>
        public bool Success { get; set; }

        /// <summary>
        /// Gets or sets the name of the MCode
        /// </summary>
        /// <value>
        /// The m code.
        /// </value>
        public MessageCode MCode { get; set; }

        /// <summary>
        /// Gets or sets the name of the Message, it return message string
        /// </summary>
        /// <value>
        /// The message.
        /// </value>
        public string Message { get; set; }

        /// <summary>
        /// Gets or sets the name of the Data, it return data object value.
        /// </summary>
        /// <value>
        /// The data.
        /// </value>
        public object Data { get; set; }
    }
}
