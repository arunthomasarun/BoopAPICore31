﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookAPICore31.DTOS
{
    public class BookDTO
    {
        public int Id { get; set; }

        public string Isbn { get; set; }

        public string Title { get; set; }

        public DateTime? PublishedDate { get; set; }
    }
}
