using System.ComponentModel.DataAnnotations;
using System;

namespace ModularCoreApi.Models
{
    public class User
    {
        [Key]
        public Guid Id { get; set; }

        public string Name { get; set; }
    }
}
