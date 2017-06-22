using Harry.SqlBuilder;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Harry.Extensions.EntityFrameworkCore.Internal
{
    internal class UpdateBuilder : IUpdateBuilder, IGetDbContext
    {
        private readonly IUpdateBuilder _builder;
        private readonly DbContext _db;
        public UpdateBuilder(IUpdateBuilder builder, DbContext db)
        {
            this._builder = builder ?? throw new ArgumentNullException(nameof(builder));
            this._db = db ?? throw new ArgumentNullException(nameof(db));
        }

        public DbContext GetDbContext()
        {
            return _db;
        }
        public IUpdateBuilder Column(string sql)
        {
            _builder.Column(sql);
            return this;
        }

        public IUpdateBuilder Column(string name, object value)
        {
            _builder.Column(name, value);
            return this;
        }

        public IUpdateBuilder Where(string sql, Parameter param)
        {
            _builder.Where(sql, param);
            return this;
        }

        public IUpdateBuilder Where(string sql, params Parameter[] param)
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
