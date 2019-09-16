
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using API_APENKOOI.Models;
using Microsoft.AspNetCore.Authorization;
using Newtonsoft.Json;

namespace API_APENKOOI.Controllers
{
    //[Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class RecipesController : ControllerBase
    {
        private readonly IRecipeRepository _contentRepository;

        public RecipesController(IRecipeRepository recipeRepository)
        {
            _contentRepository = recipeRepository;
        }

        [HttpGet("{id}")]
        public ActionResult<Recipe> Get(int id)
        {
            var recipe = _contentRepository.Get(id);

            if (recipe == null)
            {
                return NotFound();
            }

            return recipe;
        }

        [HttpGet("Test/{id}")]
        public ActionResult<Recipe> GetTest(int id)
        {
            //Recipe recipe = new Recipe();


            //recipe.Id = id;
            //recipe.RecipeDescription = "Test " + id;

            //if (recipe == null)
            //{
            //    return NotFound();
            //}

            //return Ok(recipe);
            List<Recept> recepts = new List<Recept>();
            Recept r = new Recept();
            r.id = id;
            r.recipeDescription = "test";

            recepts.Add(r);
            //string json = JsonConvert.SerializeObject(new { recipe = recepts });
            return Ok(recepts);

        }

        [HttpGet]
        public async Task<ActionResult<Recipe>> Get()
        {
            var recipe = await _contentRepository.GetAll();

            if (recipe == null)
            {
                return NotFound();
            }

            //JsonResult json = recipe;

            return Ok(recipe);
        }

        [HttpPost]
        public ActionResult<Recipe> Post(Recipe content)
        {
            return _contentRepository.Add(content);
        }

        [HttpDelete("{id}")]
        public ActionResult<Recipe> Delete(int id)
        {
            var content = _contentRepository.Get(id);

            if (content == null)
            {
                return NotFound();
            }
            else
            {
                _contentRepository.Delete(content.Id);
                return content;
            }
        }

        public class Recept
        {
            public int id { get; set; }
            public string recipeDescription { get; set; }
        }
    }
}
