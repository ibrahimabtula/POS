using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace POS
{
    public static class POSExtensions
    {
        public static IEnumerable<T> Do<T>(this IEnumerable<T> collection, Action<T> action)
        {
            foreach (T item in collection)
            {
                action(item);
                yield return item;
            }
        }

        public static void SetIdentity<T>(this IDbConnection connection, Action<T> setId)
        {
            dynamic identity = connection.Query("SELECT last_insert_rowid() AS Id").Single();
            T newId = (T)identity.Id;
            setId(newId);
        }
    }
}
