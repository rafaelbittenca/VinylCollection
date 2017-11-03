using System;

namespace Vinyl.Contracts
{
	public interface IEntity
    {
	  Nullable<long> ID { get; set; }
	  bool HasKey();
    }
}
