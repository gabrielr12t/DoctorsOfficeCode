using System;
using System.Diagnostics.CodeAnalysis;

namespace DoctorsOffice.Core.Models.Base
{
    public class ModelBase : IEquatable<ModelBase>
    {
        public ModelBase()
        {
            if (Created == DateTime.MinValue)
                Created = DateTime.UtcNow;
        }

        public int Id { get; set; }
        public DateTime Created { get; private set; }

        #region GetHashCode, IEquatable, Equals

        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as ModelBase);
        }

        public bool Equals([AllowNull] ModelBase other)
        {
            return other?.Id == Id;
        }

        #endregion
    }
}
