﻿using System;
namespace Management.API.RequestModels
{
    public class CreateUserRequestModel
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public int Acceslevel { get; set; }
        public float Wage { get; set; }
    }
}
