﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Target19_Relationship.Models;
using Target19_Relationship.Models.Tables;

namespace Target19_Relationship.Services.MasterDatas
{
    public class FinancialInstitutionBranchData
    {
        public List<FinancialInstitutionBranch> GetAll()
        {
            using (DefaultConnection db = new DefaultConnection())
            {
                var records = db.FinancialInstitutionBranches
                                .ToList();
                return records;
            }
        }
    }
}