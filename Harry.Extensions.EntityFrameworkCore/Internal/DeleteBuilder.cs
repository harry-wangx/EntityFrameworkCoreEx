using Harry.SqlBuilder;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Harry.Extensions.EntityFrameworkCore.Internal
{
    internal class DeleteBuilder : IDeleteBuilder, IGetDbContext
    {
        private readonly IDeleteBuilder _builder;
        private readonly DbContext _db;
        public DeleteBuilder(IDeleteBuilder builder, DbContext db)
        {
            this._builder = builder ?? throw new ArgumentNullException(nameof(builder));
            this._db = db ?? throw new ArgumentNullException(nameof(db));
        }

        public DbContext GetDbContext()
        {
            return _db;
        }

        public IDeleteBuilder Where(string sql, Parameter param)
        {
            _builder.Where(sql, param);
            return this;
        }

        public IDeleteBuilder Where(string sql, params Parameter[] param)
        {
            _builder.Where(sql, param);
            return this;
        }

        public Command ToCommand()
        {
            return _builder.ToCommand();
        }
    }
}
