using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Contexts;
using WebApplication1.Models;

namespace WebApplication1.Services
{
    public class UserService : IUserService
    {
        public DataContext Context { get; set; }
        public UserService(DataContext context)
        {
            this.Context = context;
        }

        public async Task<IEnumerable<User>> GetList()
        {
            return await Context.Users.ToArrayAsync();
        }

        public User Save(User user)
        {
            Context.Users.Add(user);
            return GetOne(user.Id);
        }

        public User GetOne(int id)
        {
            return Context.Users.Find(id);
        }

        public User DeleteOne(User user)
        {
            Context.Users.Remove(user);
            Context.SaveChanges();
            return GetOne(user.Id);
        }

        Task<User> IUserService.GetOne(int id)
        {
            return Context.Users.FindAsync(id);
        }

        public async Task<User> UpdateOne(User user)
        {
            Context.Entry(user).State = EntityState.Modified;
            await Context.SaveChangesAsync();
            return user;
        }

        public async Task<User> CreateOne(User user)
        {
            Context.Users.Add(user);
            await Context.SaveChangesAsync();
            return GetOne(user.Id);
        }

        public async Task<User> DeleteOne(int id)
        {
            var user = await Context.Users.FindAsync(id);
            Context.Users.Remove(user);
            await Context.SaveChangesAsync();
            return user;
        }
    }
}
