using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Autorization.Domain.Entities
{
    internal interface IEntity
    {
        /// <summary>
        /// Идентификатор.
        /// </summary>
        Guid Id { get; set; }
    }
}
