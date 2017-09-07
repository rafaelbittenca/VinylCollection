using System;
using Vinyl.Contracts;

namespace Vinyl.Models
{
    public abstract class Entity : IEntity
    {
        #region "BaseModel_Fields"
        private Nullable<long> iD;
        #endregion

        #region Properties
        public Nullable<long> ID
        {
            get { return iD; }
            set
            {
                iD = value;
            }
        }
        #endregion

        public bool HasKey()
        {
            return this.ID.HasValue && this.ID.Value > 0;
        }
    }

    public static class BaseModelExtension
    {
        public static bool IsPersisted<T>(this T model) where T : Entity
        {
            return model != null && model.HasKey();
        }
    }
}
