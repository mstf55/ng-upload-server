using System;
using System.Collections.Generic;
using System.Text;

namespace FileServer.Core.Entities.Base
{
    public interface IEntityBase<TId>
    {
        TId Id { get; }
    }
}
