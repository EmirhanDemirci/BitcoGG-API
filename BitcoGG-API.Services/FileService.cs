using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;
using BitcoGG_API.DataAccess.Data;
using BitcoGG_API.Services.Helpers;
using BitcoGG_API.Services.Interfaces;

namespace BitcoGG_API.Services
{
    public class FileService : IFileService
    {
        private readonly ApplicationDbContext _dbContext;
        public FileService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        //Upload picture (not working)
        public void Upload(int id, byte[] picture)
        {
            if (id == 0)
                throw new InvalidProfileException("Invalid id given");
            //var profile = _unitOfWork.Profile.Get(id);
            var profile = _dbContext.Users.Find(id);
            if (profile == null)
                throw new InvalidProfileException("Profile does not exist");

            profile.ProfilePicture = picture;
            _dbContext.Users.Update(profile);
        }
    }
}
