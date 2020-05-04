using System;
using System.Collections.Generic;
using System.Text;

namespace BitcoGG_API.DAL.Data.Interfaces
{
    public interface IContext<T>
    {
        void Create(T obj);
        void Read(int id);
        void Update(T obj);
        void Delete(int id);
    }
}
