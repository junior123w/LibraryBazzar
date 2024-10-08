﻿namespace LibraryBazzar.Models
{
    public class MenuItem
    {

        public string Controller { get; set; }
        public string Action { get; set; }
        public string Label { get; set; }
        public List<MenuItem> DropDownItems { get; set; }
        public bool? Authorized { get; set; }
        public List<string>? AllowedRoles { get; set; }
    }
}