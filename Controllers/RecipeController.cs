
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using API_APENKOOI.Models;
using Microsoft.AspNetCore.Authorization;
using System.Text.Json;
using API_APENKOOI.Models.InterfaceRepository;
using API_APENKOOI.Models.Table;

namespace API_APENKOOI.Controllers
{
    //[Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class RecipesController : ControllerBase
    {
        private readonly IRecipeRepository _recipeRepository;
        private readonly IRecipeTypeRepository _recipeTypeRepository;

        public RecipesController(IRecipeRepository recipeRepository, IRecipeTypeRepository recipeTypeRepository)
        {
            _recipeRepository = recipeRepository;
            this._recipeTypeRepository = recipeTypeRepository;
        }

        [HttpGet("{id}")]
        public ActionResult<Recipe> Get(int id)
        {
            var r = _recipeRepository.Get(id);

            if (r == null)
            {
                return NotFound();
            }
            string json = JsonSerializer.Serialize(new { recipe = r });

            return Ok(json);
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

            //string json = JsonConvert.SerializeObject(new { recipe = recepts });
            return Ok(recepts);

        }

        [HttpGet]
        public async Task<ActionResult<Recipe>> Get()
        {
            //var recipe = await _contentRepository.GetAll();
            IEnumerable<Recipe> r = await _recipeRepository.GetAll();
            if (r == null)
            {
                return NotFound();
            }



            //JsonResult json = recipe;
            //string json = JsonConvert.SerializeObject(new { recipe = r });
            string json = JsonSerializer.Serialize(new { recipe = r });
            return Ok(json);

        }

        [HttpPost]
        public ActionResult<Recipe> Post(Recipe content)
        {
            return _recipeRepository.Add(content);
        }

        [HttpDelete("{id}")]
        public ActionResult<Recipe> Delete(int id)
        {
            var content = _recipeRepository.Get(id);

            if (content == null)
            {
                return NotFound();
            }
            else
            {
                _recipeRepository.Delete(content.Id);
                return content;
            }
        }

        [HttpGet]
        public async Task<ActionResult<RecipeType>> GetAllRecipeType()
        {
            //var recipe = await _contentRepository.GetAll();
            IEnumerable<RecipeType> r = await _recipeTypeRepository.GetAll();
            if (r == null)
            {
                return NotFound();
            }



            //JsonResult json = recipe;
            //string json = JsonConvert.SerializeObject(new { recipe = r });
            string json = JsonSerializer.Serialize(new { recipe = r });
            return Ok(json);

        }

        public class Recept
        {
            public string id { get; set; }
            public string recipeDescription { get; set; }
        }
    }
}
