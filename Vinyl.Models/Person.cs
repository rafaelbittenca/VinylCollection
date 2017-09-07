using System;

namespace Vinyl.Models
{
    public abstract class Person : AuditableEntity
    {
        public string LastName { get; set; }
        public string FirstMidName { get; set; }
        public DateTime BirthDate { get; set; }
        public string FullName
        {
            get
            {
                return LastName + ", " + FirstMidName;
            }
        }
    }
}
