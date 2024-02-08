using System.ComponentModel.DataAnnotations;
using System;

namespace ModularCoreApi.Models
{
    public class Touch
    {
        [Key]
        public Guid Id { get; set; }
        public Guid UserId { get; set; }

        public int Index { get; set; }

        public string Type { get; set; }

        public double DeltaX { get; set; }

        public double DeltaY { get; set; }

        public bool IsTap { get; set; }
    }
}
