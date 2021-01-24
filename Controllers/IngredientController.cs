
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using API_APENKOOI.Models;
using API_APENKOOI.Models.Table;
using API_APENKOOI.Models.InterfaceRepository;

namespace API_APENKOOI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IngredientsController : ControllerBase
    {
        private readonly IIngredientRepository _contentRepository;

        public IngredientsController(IIngredientRepository IngredientRepository)
        {
            _contentRepository = IngredientRepository;
        }

        [HttpGet("{id}")]
        public ActionResult<Ingredient> Get(int id)
        {
            var Ingredient = _contentRepository.Get(id);

            if (Ingredient == null)
            {
                return NotFound();
            }

            return Ingredient;
        }

        [HttpGet]
        public ActionResult<Ingredient> GetAll()
        {
            var Ingredient = _contentRepository.GetAll();

            if (Ingredient == null)
            {
                return NotFound();
            }

            return Ok(new { Ingredient = Ingredient });
        }

        [HttpPost]
        public ActionResult<Ingredient> Post(Ingredient content)
        {
            return _contentRepository.Add(content);
        }

        [HttpDelete("{id}")]
        public ActionResult<Ingredient> Delete(int id)
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


    }
}
