using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using webapi.models;

namespace webapi.Interfaces
{
    public interface ICommentRepository
    {
        Task<List<Comment>> GetAllAsync();

        Task<Comment> GetByIdAsync(int id);

        Task<Comment> CreateAsync(Comment CommentModel);

        Task<Comment?> UpdateAsync(int id, Comment CommentModel);

        Task<Comment?> DeleteAsync(int id);
    }
}