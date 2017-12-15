using System;
using app.models.Entities;
using System.Linq;
namespace app.core
{
    public static class PersonExtensions
    {
        public static bool HasValidFullName(this Person entity)
        {
            if (!string.IsNullOrWhiteSpace(entity?.Fullname))
            {
                return entity.Fullname.All((c) => char.IsLetter(c) || char.IsWhiteSpace(c));
            }
            return false;
        }
    }
}
