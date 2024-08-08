﻿namespace EmployeeAdminPortal.Models.Entities
{
    public class Employee
    {
        public Guid id { get; set; }
        public required String Name { get; set; } 
        public required string Email { get; set; }
        public string? Phone { get; set; }
        public decimal Salary { get; set; }
    }
}
