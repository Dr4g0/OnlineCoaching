using OnlineCoaching.ViewModels.Comment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper.QueryableExtensions;
using OnlineCoaching.Models;

namespace OnlineCoaching.Factories
{
    public class CommentFactory : BaseFactory
    {
        public IQueryable<CommentViewModel> GetAll()
        {
            return this.db.Comments
                .All().OrderBy(c => c.CreatedOn)
                .Project().To<CommentViewModel>();
        }

        public Comment GetByID(int id)
        {
            return this.db.Comments.Find(id);
        }

        public void Update(Comment comment)
        {
            this.db.Comments.Update(comment);
            this.db.SaveChanges();
        }

        public void Add(Comment comment)
        {
            this.db.Comments.Add(comment);
            this.db.SaveChanges();
        }

        public void Delete(Comment comment)
        {
            this.db.Comments.Delete(comment);
            this.db.SaveChanges();
        }
    }
}