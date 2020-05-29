using System;
using System.Collections.Generic;
using System.Text;

namespace BitcoGG_API.Services.Interfaces
{
    public interface IFileService
    {
        void Upload(int id, byte[] picture);
    }
}
