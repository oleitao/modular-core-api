namespace WebApi.Models.Users;

using System;
using System.ComponentModel.DataAnnotations;
using WebApi.Entities;

public class UpdateRequest
{
    public string FullName { get; set; }

    [Required]
    public char Sex { get; set; }

    [Required]
    public int Age { get; set; }

    public string Hobby { get; set; }

    [EmailAddress]
    public string Email { get; set; }


    private string replaceEmptyWithNull(string value)
    {
        return string.IsNullOrEmpty(value) ? null : value;
    }
}