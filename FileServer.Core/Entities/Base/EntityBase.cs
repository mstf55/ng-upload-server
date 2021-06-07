﻿using System;
using System.Collections.Generic;
using System.Text;

namespace FileServer.Core.Entities.Base
{
    public abstract class EntityBase<TId> : IEntityBase<TId>
    {
        public virtual TId Id { get; protected set; }

    }
}
