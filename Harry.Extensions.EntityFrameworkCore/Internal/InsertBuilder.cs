using Harry.SqlBuilder;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Harry.Extensions.EntityFrameworkCore.Internal
{
    internal class InsertBuilder : IInsertBuilder, IGetDbContext
    {
        private readonly IInsertBuilder _builder;
        private readonly DbContext _db;
        public InsertBuilder(IInsertBuilder builder, DbContext db)
        {
            this._builder = builder ?? throw new ArgumentNullException(nameof(builder));
            this._db = db ?? throw new ArgumentNullException(nameof(db));
        }

        public IInsertBuilder Column(string name, object value)
        {
            _builder.Column(name, value);
            return this;
        }

        public DbContext GetDbContext()
        {
            return _db;
        }

        public Command ToCommand()
        {
            return _builder.ToCommand();
        }
    }
}
