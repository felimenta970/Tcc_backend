﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tcc_backend.DataBaseConfig;
using Tcc_backend.Entities;

namespace Tcc_backend.Dao {
    public class ProjectManagerDao {

        DatabaseContext _databaseContext = new DatabaseContext();

        public int Add(ProjectManager pm) {

            _databaseContext.ProjectManager.Add(pm);
            _databaseContext.SaveChanges();
            return pm.ProjectManagerID;
        }

    }
}
