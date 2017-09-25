using System;

namespace Vinyl.Models
{
    public abstract class Person : AuditableEntity
    {
	  public string Name { get; set; }
        public DateTime BirthDate { get; set; }
    }
}
