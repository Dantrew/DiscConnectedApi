﻿using DiscConnectedApi.DbContext;
using DiscConnectedApi.Models;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace DiscConnectedApi.DAL
{
    public class ForumManager

    {
        private readonly MyDbContext _context;
        public ForumManager(MyDbContext context)
        {
            _context = context;
        }

        //public static List<Models.Forum> Forums { get; set; }

        //internal static async Task CreateForum(Forum forum)
        //{
        //    if (Forums is null)
        //    {
        //        await ForumData.GetForums();
        //    }
        //    Forums.Add(forum);
        //}

        //internal static async Task DeleteForum(int id)
        //{
        //    if (Forums is null)
        //    {
        //        await ForumData.GetForums();
        //    }

        //    Forums.RemoveAt(id - 1);
        //}

        internal async Task<List<Forum>> GetAllForums()
        {
            return await _context.Forum.ToListAsync();
        }

        internal async Task<Forum> GetOneForum(int id)
        {
            var existingForum = _context.Forum.Where(p => p.Id == id).SingleOrDefault();

            if (existingForum != null)
            {
                return existingForum;
            }
            else
            {
                return null;
            }
        }

        internal async Task UpdateForum(Forum forum, int id)
        {
            var existingForum = await _context.Forum.FirstOrDefaultAsync(p => p.Id == id);
            if (existingForum != null)
            {
                existingForum.Name = forum.Name;

                var validationContext = new ValidationContext(existingForum, serviceProvider: null, items: null);
                var validationResults = new List<ValidationResult>();
                bool isValid = Validator.TryValidateObject(existingForum, validationContext, validationResults, validateAllProperties: true);

                if (!isValid)
                {
                    string validationErrors = string.Join(", ", validationResults.Select(v => v.ErrorMessage));
                    Console.WriteLine($"Validation errors: {validationErrors}");
                }
                else
                {
                    await _context.SaveChangesAsync();
                }
            }
        }
    }
}
