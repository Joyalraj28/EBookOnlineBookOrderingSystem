using System;

namespace EBookOnlineBookOrderingSystem.SqlAttribute
{
    public class PrimaryKeyAttribute : Attribute
    {
        public bool IsPrimaryKey { get; }

        public PrimaryKeyAttribute(bool isPrimaryKey = true)
        {
            IsPrimaryKey = isPrimaryKey;
        }
    }
}
