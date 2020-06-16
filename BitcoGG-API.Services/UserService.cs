using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using BitcoGG_API.DataAccess.Data;
using BitcoGG_API.Models;
using BitcoGG_API.Services.Helpers;
using BitcoGG_API.Services.Interfaces;
using Microsoft.IdentityModel.Tokens;

namespace BitcoGG_API.Services
{
    public class UserService : IUserService
    {
        private readonly ApplicationDbContext _dbContext;
        public UserService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        //Service to create a user
        public void Create(User user)
        {
            var dbUser = _dbContext.Users.FirstOrDefault(x => x.UserName == user.UserName);

            if (dbUser == null)
            {
                _dbContext.Users.Add(user);
                _dbContext.SaveChanges();
            }
            else
            {
                throw new AlreadyExistsException("User already exists");
            }
            
        }

        //Service to authenticate a user
        public JwtUser Authenticate(string username, string password)
        {
            //TODO: Change hardcoded JWTKey
            var jwtKey = "1234567890123456";
            var user = _dbContext.Users.FirstOrDefault(u => u.UserName == username);

            if (user == null)
            {
                return null;
            }

            if (password != user.Password)
            {
                return null;
            }
            
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                //Making claims for the Jwt token. So if I decode the token I could find these data
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim("Id", user.Id.ToString()),
                    new Claim("IsAdmin", user.IsAdmin.ToString())
                }),
                //how long the token is valid
                Expires = DateTime.UtcNow.AddDays(1),
                //Creating a securityToken with the "HmacSha256" algorithm
                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtKey)),
                    SecurityAlgorithms.HmacSha256)
            };
            var tokenHandler = new JwtSecurityTokenHandler();
            var securityToken = tokenHandler.CreateToken(tokenDescriptor);
            var token = tokenHandler.WriteToken(securityToken);

            var jwtUser = new JwtUser();
            jwtUser.Token = token;
            jwtUser.User = user;
            return jwtUser;
        }
        //Service to get a specific user
        public User Get(int id)
        {
            if (id != 0)
            {
                //Query to get the specific user
                var user = _dbContext.Users.Find(id);
                return user;
            } 
            return null;
        }

        //Service to get all users
        public List<User> GetAll(int id)
        {
            if (id != 0)
            {
                var user = _dbContext.Users.Find(id);
                if (user != null && user.IsAdmin == 1)
                {
                    //Query to get all the users
                    var users = _dbContext.Users.ToList();
                    return users;
                }
            }
            return null;
        }

        //Service to delete a user
        public void Delete(int selectedId, int id)
        {
            if (selectedId != 0 && id != 0)
            {
                var user = _dbContext.Users.Find(id);
                if (user != null && user.IsAdmin == 1)
                {
                    var userToBeDeleted = _dbContext.Users.Find(selectedId);
                    if (userToBeDeleted != null)
                    {
                        _dbContext.Users.Remove(userToBeDeleted);
                        _dbContext.SaveChanges();
                    }
                }
            }
        }

        public void DeleteWallet(Wallet wallet, int id)
        {
            if (id != 0)
            {
                var userWithWallet = _dbContext.Wallet.Find(id);
                if (userWithWallet != null)
                {
                    _dbContext.Wallet.Remove(wallet);
                    _dbContext.SaveChanges();
                }
            }
        }

        public void CreateWallet(Wallet wallet, int id)
        {
            var dbUser = _dbContext.Wallet.FirstOrDefault(x => x.UserId == id);

            if (dbUser == null)
            {
                _dbContext.Wallet.Add(wallet);
                _dbContext.SaveChanges();
            }
            else
            {
                throw new AlreadyExistsException("Wallet already exists already exists");
            }
        }

        public void PurchaseCoin(PurchasedCoin purchaseCoin, int id)
        {
            var checkWallet = _dbContext.Wallet.FirstOrDefault(x => x.UserId == id);
            if (checkWallet == null)
            {
                throw new AlreadyExistsException("You have no wallet");
            }
            purchaseCoin.WalletId = checkWallet.WalletId;
            purchaseCoin.TotalValue = Convert.ToInt32(purchaseCoin.Quantity * purchaseCoin.Price);
            _dbContext.PurchasedCoin.Add(purchaseCoin);
            _dbContext.SaveChanges();
        }

        public List<PurchasedCoin> GetPurchasedCoin(int id)
        {
            List<PurchasedCoin> purchased = new List<PurchasedCoin>();
            var checkWallet = _dbContext.Wallet.FirstOrDefault(x => x.UserId == id);
            var checkCoin = _dbContext.PurchasedCoin.Where(x => x.WalletId == checkWallet.WalletId);
            purchased.AddRange(checkCoin);
            return purchased;
        }

        public void UpdatePurchasedCoin(int selectedId, int id, int quantity)
        {
            if (selectedId != 0 && id != 0)
            {
                var user = _dbContext.Users.Find(id);
                if (user != null)
                {
                    var userToBeDeleted = _dbContext.PurchasedCoin.Find(selectedId);
                    if (userToBeDeleted != null)
                    {
                        
                        if (userToBeDeleted.Quantity == 0)
                        {
                            _dbContext.Remove(userToBeDeleted);
                            _dbContext.SaveChanges();
                        }
                        else
                        {
                            _dbContext.PurchasedCoin.Update(userToBeDeleted);
                            userToBeDeleted.TotalValue = Convert.ToInt32(userToBeDeleted.Price) * userToBeDeleted.Quantity;
                            _dbContext.SaveChanges();
                        }
                    }
                }
            }
        }
    }
}
