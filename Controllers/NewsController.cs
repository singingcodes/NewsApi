using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Mvc;
using NewsApi.Data;
using NewsApi.Models;

namespace NewsApi.Controllers {
    [Route ("api/[controller]")]
    [ApiController]
    public class NewsController : ControllerBase {

        private readonly ApplicationDbContext dbContext;
        public NewsController (ApplicationDbContext _dbContext) {
            dbContext = _dbContext;
        }

        [HttpGet]
        public ActionResult<IEnumerable<News>> GetNews () {
            var News = dbContext.News;
            return News;
        }

        [HttpGet ("{id}")]
        public ActionResult<News> GetNews (int id) {
            var News = dbContext.News.FirstOrDefault (option => option.ID == id);
            if (News != null)
                return News;
            else
                return NotFound ();
        }

        [HttpPost]
        public ActionResult<News> CreateNews ([FromBody] AddNews addNews) {
            var NewsToCreate = new News () {
                HeadLine = addNews.HeadLine,
                Author = addNews.Author,
                Content = addNews.Content,
                PublishedDate = DateTime.Now
            };
            var CreatedNews = dbContext.News.Add (NewsToCreate).Entity;
            dbContext.SaveChanges ();
            return CreatedNews;
        }

        [HttpPut ("{id}")]
        public ActionResult<News> EditNews (int id, [FromBody] EditNews editNews) {
            var NewsToEdit = dbContext.News.FirstOrDefault (option => option.ID == id);
            if (NewsToEdit == null)
                return NotFound ();
            NewsToEdit.HeadLine = editNews.HeadLine;
            NewsToEdit.Author = editNews.Author;
            NewsToEdit.Content = editNews.Content;
            dbContext.SaveChanges ();
            return NewsToEdit;
        }

        [HttpDelete ("{id}")]
        public IActionResult DeleteNews (int id) {
            var NewsToDelete = dbContext.News.FirstOrDefault (option => option.ID == id);
            if (NewsToDelete == null)
                return BadRequest ();
            dbContext.News.Remove (NewsToDelete);
            dbContext.SaveChanges ();
            return NoContent ();
        }

    }
}