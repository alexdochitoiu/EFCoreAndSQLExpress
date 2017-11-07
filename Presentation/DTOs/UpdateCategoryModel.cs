using System;

namespace Presentation.DTOs
{
    public class UpdateCategoryModel
    {
        public Guid Id { get; set; }

        public string Title { get; set; }
        
        public string DistributorName { get; set; }
    }
}
