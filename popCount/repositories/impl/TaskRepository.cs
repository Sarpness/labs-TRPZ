﻿using Microsoft.EntityFrameworkCore;
using popCount.EF;
using popCount.entities;
using popCount.repositories.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace popCount.repositories.impl
{
    internal class TaskRepository
        : BaseRepository<task>, ITaskRepository
    {
        public TaskRepository(DbContext context) : base(context)
        {
        }

        internal TaskRepository(taskContext context) : base(context)
        {

        }
    }
}
