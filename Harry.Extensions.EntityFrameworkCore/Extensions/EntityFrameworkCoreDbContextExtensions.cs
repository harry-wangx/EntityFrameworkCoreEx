using Harry.Extensions.EntityFrameworkCore.Internal;
using Harry.SqlBuilder;
using System;
using System.Collections.Generic;
using System.Text;

namespace Microsoft.EntityFrameworkCore
{
    public static class EntityFrameworkCoreDbContextExtensions
    {
        /// <summary>
        /// 获取表名称
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="db"></param>
        /// <returns></returns>
        public static string GetTableName<T>(this DbContext db) where T : class
        {
            if (db == null)
            {
                throw new ArgumentNullException(nameof(db));
            }
            return db.Model.FindEntityType(typeof(T))?.Relational()?.TableName;
        }

        //public static SelectBuilder Select(string field)
        //{
        //    return new SelectBuilder(field);
        //}

        //public static InsertBuilder Insert(string table)
        //{
        //    return new InsertBuilder(table);
        //}

        public static IUpdateBuilder UpdateBuilder(this DbContext db, string table)
        {
            if (db == null)
            {
                throw new ArgumentNullException(nameof(db));
            }
            if (string.IsNullOrEmpty(table))
            {
                throw new ArgumentNullException(nameof(table));
            }
            return new UpdateBuilder(SqlBuilderFactorySingleton.Instance.UpdateBuilder(table), db);
        }

        public static IUpdateBuilder UpdateBuilder<T>(this DbContext db) where T : class
        {
            if (db == null)
            {
                throw new ArgumentNullException(nameof(db));
            }
            return UpdateBuilder(db, db.GetTableName<T>());
        }

        public static IDeleteBuilder DeleteBuilder(this DbContext db, string table)
        {
            if (db == null)
            {
                throw new ArgumentNullException(nameof(db));
            }
            if (string.IsNullOrEmpty(table))
            {
                throw new ArgumentNullException(nameof(table));
            }
            return new DeleteBuilder(SqlBuilderFactorySingleton.Instance.DeleteBuilder(table), db);
        }

        public static IDeleteBuilder DeleteBuilder<T>(this DbContext db) where T : class
        {
            if (db == null)
            {
                throw new ArgumentNullException(nameof(db));
            }
            return DeleteBuilder(db, db.GetTableName<T>());
        }

        public static IInsertBuilder InsertBuilder(this DbContext db, string table)
        {
            if (db == null)
            {
                throw new ArgumentNullException(nameof(db));
            }
            if (string.IsNullOrEmpty(table))
            {
                throw new ArgumentNullException(nameof(table));
            }
            return new InsertBuilder(SqlBuilderFactorySingleton.Instance.InsertBuilder(table), db);
        }

        public static IInsertBuilder InsertBuilder<T>(this DbContext db) where T : class
        {
            if (db == null)
            {
                throw new ArgumentNullException(nameof(db));
            }
            return InsertBuilder(db, db.GetTableName<T>());
        }

        //public static RawBuilder Raw(string sql, dynamic param = null)
        //{
        //    return new RawBuilder(sql, param);
        //}
        //public static RawBuilder Raw(dynamic param)
        //{
        //    return new RawBuilder(null, param);
        //}
    }
}
