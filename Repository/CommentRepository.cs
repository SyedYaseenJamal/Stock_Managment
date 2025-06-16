using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using webapi.Data;
using webapi.Interfaces;
using webapi.models;

namespace webapi.Repository
{
    public class CommentRepository : ICommentRepository
    {
        private readonly ApplicationDBContext _context;
        public CommentRepository(ApplicationDBContext dBContext)
        {
            _context = dBContext;
        }

        public async Task<Comment> CreateAsync(Comment CommentModel)
        {
            Console.WriteLine("yaseeeen the kinguj");
            await _context.Comment.AddAsync(CommentModel);
            Console.WriteLine("jawzii the kinguu");
            await _context.SaveChangesAsync();
            return CommentModel;
        }

        public async Task<Comment?> DeleteAsync(int id)
        {
            var commentModel = await _context.Comment.FirstOrDefaultAsync(x => x.Id == id);
            if (commentModel == null)
            {
                return null;
            }
            _context.Comment.Remove(commentModel);
            await _context.SaveChangesAsync();
            return commentModel;
        }

        public async Task<List<Comment>> GetAllAsync()
        {
            return await _context.Comment.ToListAsync();
        }

        public async Task<Comment> GetByIdAsync(int id)
        {
            return await _context.Comment.FindAsync(id);

        }

        public async Task<Comment?> UpdateAsync(int id, Comment CommentModel)
        {
            var exist = await _context.Comment.FindAsync(id);
            if(exist == null)
            {
                return null;
            }
            exist.Title = CommentModel.Title;
            exist.Content = CommentModel.Content;
            await _context.SaveChangesAsync();
            return exist;
        }
    }
}