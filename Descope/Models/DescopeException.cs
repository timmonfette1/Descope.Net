/* <copyright file="DescopeException" company="Solidus">
 * Copyright (c) 2023 All Rights Reserved
 * </copyright>
 * <author>Solidus</author>
 * <date>10/24/2023 21:02:34</date>
 */

using System.Runtime.Serialization;

namespace Descope.Models
{
    public class DescopeException : Exception
    {
        public DescopeException() { }
        public DescopeException(string message) : base(message) { }
        public DescopeException(SerializationInfo info, StreamingContext context) : base(info, context) { }
        public DescopeException(string message, Exception innerException) : base(message, innerException) { }

        public string ErrorCode { get; set; }
        public string ErrorDescription { get; set; }
        public string ErrorMessage { get; set; }
    }
}
