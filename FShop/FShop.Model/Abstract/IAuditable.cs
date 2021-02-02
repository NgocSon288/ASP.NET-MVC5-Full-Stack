using System;

namespace FShop.Model.Abstract
{
    public interface IAuditable
    {
        DateTime? CreatedDate { get; set; }

        string CreatedBy { get; set; }

        DateTime? UpdatedDate { get; set; }

        string UpdateBy { get; set; }

        bool? Status { get; set; }

        string MetaKeyword { get; set; }

        string MetaDescription { get; set; }
    }
}