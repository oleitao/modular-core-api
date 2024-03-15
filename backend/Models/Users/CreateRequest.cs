namespace WebApi.Models.Users;

using System;
using System.ComponentModel.DataAnnotations;
using WebApi.Entities;

public class CreateRequest
{

    [Required]
    public string FullName { get; set; }

    [Required]
    public char Sex { get; set; }

    [Required]
    public int Age { get; set; }

    public string Hobby { get; set; }

    [Required]
    [EmailAddress]
    public string Email { get; set; }

}