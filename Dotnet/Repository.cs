using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using NdcPlanning.App_Start;                // State
using MisModel.Warehouse;                   // Reason
using Mis.Model.Warehouse;                  // Department


namespace NdcPlanning
{
    public class Repository : INdcPlanningRepository
    {
        public Department GetT85Department()
        {
            // TODO: Remove use / use real data from database
            return new Department { Id = 11, DepartmentCode = "T85", DepartmentName = "????", ApproxSinglesPerTrailer = 1000 };
        }

        public int GetUsersPickSiteId()
        {
            return 670; // Swindon
        }

        public int GetUsersCrossdockSiteId()
        {
            return 666; // Neasden
        }

        public decimal GetTrailerFillPerRpe()
        {
            return (1m / 99m);
        }

    }
}