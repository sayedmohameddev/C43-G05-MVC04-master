﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IKEA.DAL.Models.Departments
{
    public class Department:ModelBase
    {

        public string Name { get; set; } = null!;
        public string? Description { get; set; } 


        public string code { get; set; }=null!;


        public DateOnly CreationDate { get; set; }


    }
}
