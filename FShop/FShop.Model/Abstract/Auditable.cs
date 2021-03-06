﻿using System;

namespace FShop.Model.Abstract
{
    public class Auditable : IAuditable
    {
        public DateTime? CreatedDate { get; set; }

        public string CreatedBy { get; set; }

        public DateTime? UpdatedDate { get; set; }

        public string UpdateBy { get; set; }

        public bool? Status { get; set; }

        public string MetaKeyword { get; set; }

        public string MetaDescription { get; set; }
    }
}