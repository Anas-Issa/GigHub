﻿using System;

namespace GigHub.DTOs
{
    public class GigDto
    {
        public int ID { get; set; }
        public bool IsCanceled { get; set; }
        public UserDto Artist { get; set; }
       
        public DateTime DateTime { get; set; }
       
        public string Venue { get; set; }
        
        public GenreDto Genre { get; set; }
        
    }
}