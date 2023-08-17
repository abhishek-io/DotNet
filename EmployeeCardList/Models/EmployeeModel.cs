using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EmployeeCardList.Models
{
    public class EmployeeModel
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
        [Required]
        public string Designation { get; set; }
        [Required]
        [DisplayName("Department")]
        public string Department { get; set; }
        [Required]
        [DisplayName("Phone")]
        public string Phone { get; set; }

        public EmployeeModel()
        {
            Id = -1;
            Name = "";
            Designation = "";
            Department = "";
            Phone = "";

        }

        public EmployeeModel(int id, string name, string description, string appearsIn, string withThisActor)
        {
            Id = id;
            Name = name;
            Designation = description;
            Department = appearsIn;
            Phone = withThisActor;
        }

    }

    
}