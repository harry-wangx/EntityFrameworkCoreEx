using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Harry.Extensions.EntityFrameworkCore
{
    public interface IGetDbContext
    {
        DbContext GetDbContext();
    }
}
