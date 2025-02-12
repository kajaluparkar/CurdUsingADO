﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.AccessControl;
using System.Web;

namespace CurdUsingADO.Models
{
    public class Employee
    {

        //Properties
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }

        [Required]
        public int Age { get; set; }

        [Required]
        public decimal Salary { get; set; }

        [Required]
        public string City {  get; set; }

        [Required]
        public string Gender { get; set; }


       
    }
    
}