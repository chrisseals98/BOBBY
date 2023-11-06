using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;
using System.ComponentModel.DataAnnotations;

/*
 * This file contains the User class, which holds necessary information
 * about the User. Used in AccountController.cs
 */

namespace BucStop.Models
{
    public class User
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;
    }
}
