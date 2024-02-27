using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace Day_1.Models
{
    public class Department
    {
        
            public int id { get; set; }
            public string name { get; set; }
            public string Location { get; set; }
            [StringLength(20, MinimumLength = 2, ErrorMessage = "Name must be less than 20 and more than 2 characters")]
            public string Manager { get; set; }
        }

    }

