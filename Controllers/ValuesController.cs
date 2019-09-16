﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace API_APENKOOI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get( int id)
        {
            return Ok(new Value { Id=id, Text = "value" + id});
        }

        // POST api/values
        [HttpPost]
        public ActionResult Post([FromBody] Value value)
        {
            if(!ModelState.IsValid) 
            {
                return BadRequest(ModelState);
            }

            return CreatedAtAction("Get", new { id = value.Id}, value);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }

        public class Value
        {
            public int Id { get; set; }
            [MinLength(3)]
            public string Text { get; set; }
        }
    }
}
