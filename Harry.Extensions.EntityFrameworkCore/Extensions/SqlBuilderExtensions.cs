using Harry.Extensions.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Harry.SqlBuilder
{
    public static class SqlBuilderExtensions
    {
        public static int Exec(this IUpdateBuilder builder)
        {
            return exec(builder);
        }

        public static int Exec(this IDeleteBuilder builder)
        {
            return exec(builder);
        }

        private static int exec(IToCommand builder)
        {
            IGetDbContext db = builder as IGetDbContext ?? throw new ArgumentNullException(nameof(builder));

            var cmd = builder.ToCommand();

            try
            {
                if (cmd.Parameters != null && cmd.Parameters.Length > 0)
                {
                    return db.GetDbContext().Database.ExecuteSqlCommand(cmd.Sql, cmd.Parameters);
                }
                else
                {
                    return db.GetDbContext().Database.ExecuteSqlCommand(cmd.Sql);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message + "  sql:" + cmd.Sql, ex);
            }
        }
    }
}
