using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using NewsApi.Data;
using NewsApi.Models;

namespace NewsApi.Controllers {
        [Route ("api/[controller]")]
        [ApiController]
        public class CategoryController : ControllerBase {

            private readonly ApplicationDbContext dbContext;
            public CategoryController (ApplicationDbContext _dbContext) {
                dbContext = _dbContext;
            }

            [HttpPost]
            public ActionResult<Category> CreateCategory ([FromBody] AddCategory addCategory) {
                var CategoryToCreate = new Category () {
                    Description = addCategory.Description,
                    
                };
                var CreatedCategory = dbContext.Category.Add (CategoryToCreate).Entity;
                dbContext.SaveChanges ();
                return CreatedCategory;
            }
                [HttpGet ("{id}")]
                public ActionResult<Category> GetCategory (int id) {
                    var Category = dbContext.Category.FirstOrDefault (option => option.ID == id);
                    if (Category != null)
                        return Category;
                    else
                        return NotFound ();
                }

            }
        }