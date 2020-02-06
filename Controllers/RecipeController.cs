
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
        public ActionResult<Recipe> GetTest(string id)
        {
            //Recipe recipe = new Recipe();


            //recipe.Id = id;
            //recipe.RecipeDescription = "Test " + id;

            //if (recipe == null)
            //{
            //    return NotFound();
            //}
            List<Recept> recepts = new List<Recept>();
            

            for (int i = 0; i < 10; i++ )
            {
                Recept r = new Recept();
                r.id = i.ToString();
                r.recipeDescription = i.ToString();
                recepts.Add(r);
            }

            //return Ok(recipe);

            string json = JsonConvert.SerializeObject(new { recipe = recepts });
            return Ok(json);

        }

        [HttpGet]
        public async Task<ActionResult<Recipe>> Get()
        {
            //var recipe = await _contentRepository.GetAll();
            IEnumerable<Recipe> r = await _contentRepository.GetAll();
            if (r == null)
            {
                return NotFound();
            }
            


            //JsonResult json = recipe;
            string json = JsonConvert.SerializeObject(new { recipe = r });
            return Ok(json);

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
            public string id { get; set; }
            public string recipeDescription { get; set; }
        }
    }
}
