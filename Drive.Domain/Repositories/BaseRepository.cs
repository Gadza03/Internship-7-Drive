﻿using Drive.Data.Entities;
using Drive.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Drive.Domain.Repositories
{
    public abstract class BaseRepository
    {
        protected readonly DriveDbContext DbContext;
        
        protected BaseRepository(DriveDbContext dbContext)
        {
            DbContext = dbContext;
        }
        protected ResponseResultType SaveChanges()
        {
            var hasChanges = DbContext.SaveChanges() > 0;
            if (hasChanges)
                return ResponseResultType.Success;

            return ResponseResultType.NoChanges;
        }
    }
}
