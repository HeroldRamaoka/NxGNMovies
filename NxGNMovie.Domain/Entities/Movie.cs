using NxGNMovie.Domain.Common;
using NxGNMovie.Domain.ValueObjects;
using System.ComponentModel.DataAnnotations;

namespace NxGNMovie.Domain.Entities
{
    public class Movie : AuditableEntity
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public int Rating { get; set; }
        [Required]
        public string Category { get; set; }
        [Required]
        public Created Created { get; set; }
        public Modified Modified { get; set; }

        public void SetModifiedInfo(string username)
        {
            Modified = new Modified(username);
        }

    }
}
