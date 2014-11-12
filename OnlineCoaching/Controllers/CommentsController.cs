using OnlineCoaching.Factories;
using OnlineCoaching.Models;
using OnlineCoaching.ViewModels.Comment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineCoaching.Controllers
{
    public class CommentsController : Controller
    {
         private CommentFactory factory;

         public CommentsController()
        {
            this.factory = new CommentFactory();
        }

         // GET: Comments
        public ActionResult Index()
        {
            var allComments = this.factory.GetAll();
            return View(allComments);
        }

        ////GET: Create comment
        //public ActionResult Create()
        //{
        //    return View();
        //}

        ////POST: Create comment
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Create(CommentViewModel comment)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        var newComment = new Comment()
        //        {
        //            Content = comment.Content,
        //        };

        //        this.factory.Add(newComment);
        //        TempData["Success"] = "A new comment '" + newComment.Content + "' was created";
        //        return RedirectToAction("Index");
        //    }

        //    return View(comment);
        //}

        //GET: Edit comment
        public ActionResult Edit(int id)
        {
            var existingComment = this.factory.GetByID(id);
            var commentModel = AutoMapper.Mapper.Map<CommentViewModel>(existingComment);
            return View(commentModel);
        }

        //POST: Edit comment
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(CommentViewModel comment)
        {
            if (ModelState.IsValid)
            {
                var existingComment = this.factory.GetByID(comment.ID);

                existingComment.Content = comment.Content;

                this.factory.Update(existingComment);
                TempData["Success"] = "A comment with ID'" + comment.ID + "' was edited";
                return RedirectToAction("Index");
            }

            return View(comment);
        }

        //GET: Delete comment
        public ActionResult Delete(int id)
        {
            var existingComment = this.factory.GetByID(id);
            var commentModel = AutoMapper.Mapper.Map<CommentViewModel>(existingComment);
            return View(commentModel);
        }

        //POST: Delete comment
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(CommentViewModel comment)
        {
            var existingComment = this.factory.GetByID(comment.ID);
            this.factory.Delete(existingComment);
            TempData["Success"] = "A comment with ID'" + existingComment.ID + "' was deleted";
            return RedirectToAction("Index");
        }
    }
}