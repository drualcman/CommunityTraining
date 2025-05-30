﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommunityTraining.Interfaces
{
    public interface IGetContext<TEntity>
    {
        Task<TEntity> Get(string id);
    }
}
