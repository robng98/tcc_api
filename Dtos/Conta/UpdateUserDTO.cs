using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace tcc1_api.Dtos.Conta
{
    public class UpdateUserDTO
    {
        public string? Email { get; set; }
        public string? FullName { get; set; }
        public string? CurrentPassword { get; set; }
        public string? NewPassword { get; set; }
    }
}
