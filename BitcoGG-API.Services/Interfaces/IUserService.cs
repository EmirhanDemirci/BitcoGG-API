using System;
using System.Collections.Generic;
using System.Text;
using BitcoGG_API.Models;
using BitcoGG_API.Models.ViewModels;

namespace BitcoGG_API.Services.Interfaces
{
    public interface IUserService
    {
        void Create(User user);
        JwtUser Authenticate(string username, string password);
        User Get(int id);
        List<User> GetAll(int id);
        void Delete(int selectedId, int id);
        void DeleteWallet(Wallet wallet, int id);
        void CreateWallet(Wallet wallet, int id);
        void PurchaseCoin(PurchasedCoin purchaseCoin, int id);
        List<PurchasedCoin> GetPurchasedCoin(int walletId);
        void UpdatePurchasedCoin(int selectedId, int id, int quantity);
    }
}
