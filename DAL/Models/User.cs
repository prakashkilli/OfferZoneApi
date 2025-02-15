﻿using System;
using System.Collections.Generic;

namespace DAL.Models
{
    public partial class User
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string UserName { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string PassWord { get; set; } = null!;
        public bool? IsAdmin { get; set; }
    }
}
