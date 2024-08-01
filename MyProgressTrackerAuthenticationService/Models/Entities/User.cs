﻿using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace MyProgressTrackerAuthenticationService.Models.Entities
{
    public class User
    {
        [Key]
        [Required]
        public long UserId { get; set; }
        [Required]
        public string FirstName { get; set; }
        public string LastName { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        public string? Phone { get; set; }
        public DateOnly? BirthDay { get; set; }
        public string? Institute { get; set; }
        public string? Course { get; set; }
        public string? EducationLvl { get; set; }

        public User()
        {

        }

        public User(long id, string fName, string lName, string email, string pwrd, string phoneNo, DateOnly bday, string institute, string course, string elevel)
        {
            UserId = id;
            FirstName = fName;
            LastName = lName;
            Email = email;
            Password = pwrd;
            Phone = phoneNo;
            BirthDay = bday;
            Institute = institute;
            Course = course;
            EducationLvl = elevel;
        }

        public User(long id, string fName, string lName, string email, string pwrd)
        {
            UserId = id;
            FirstName = fName;
            LastName = lName;
            Email = email;
            Password = pwrd;
            Phone = null;
            BirthDay = null;
            Institute = null;
            Course = null;
            EducationLvl = null;
        }
    }
}
