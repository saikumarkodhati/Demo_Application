﻿using System;
using System.Collections.Generic;

#nullable disable

namespace DigitalBook.Models
{
    public partial class LogIn
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
