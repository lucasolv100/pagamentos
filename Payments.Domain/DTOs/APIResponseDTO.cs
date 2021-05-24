using System.Collections.Generic;

namespace Payments.Domain.DTOs
{
    public class APIResponseDTO
    {
        public bool Success
        {
            get
            {
                return Errors == null || Errors.Count == 0;
            }
        }
        public List<string> Errors { get; set; }


    }
}