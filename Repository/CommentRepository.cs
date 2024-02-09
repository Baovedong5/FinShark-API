using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FinShark.Data;
using FinShark.Interfaces;
using FinShark.models;
using Microsoft.EntityFrameworkCore;

namespace FinShark.Repository
{
    public class CommentRepository : ICommentRepository
    {

        private readonly ApplicationDBContext _context;

        public CommentRepository(ApplicationDBContext context)
        {
            _context = context;
        }

        public async Task<List<Comment>> GetAllAsync()
        {
            return await _context.Comments.ToListAsync();
        }

        public async Task<Comment?> GetByIdAsync(int id)
        {
            return await _context.Comments.FindAsync(id);
        }

        public async Task<Comment> CreateAsync(Comment commentModel)
        {
            await _context.Comments.AddAsync(commentModel);

            await _context.SaveChangesAsync();

            return commentModel;
        }

        public async Task<Comment?> UpdateAsync(int id, Comment commentModel)
        {
            var commentExists = await _context.Comments.FindAsync(id);

            if (commentExists == null)
            {
                return null;
            }

            commentExists.Title = commentModel.Title;
            commentExists.Content = commentModel.Content;

            await _context.SaveChangesAsync();

            return commentExists;
        }

        public async Task<Comment?> DeleteAsync(int id)
        {
            var commentModel = await _context.Comments.FirstOrDefaultAsync(x => x.Id == id);

            if (commentModel == null)
            {
                return null;
            }

            _context.Comments.Remove(commentModel);

            await _context.SaveChangesAsync();

            return commentModel;
        }
    }
}