using System;
using System.Collections.Generic;
using System.Text;

namespace Shopping.Data.Interfaces
{
    public interface IDatabaseTransaction : IDisposable
    {
        void Commit();

        void Rollback();
    }
}
