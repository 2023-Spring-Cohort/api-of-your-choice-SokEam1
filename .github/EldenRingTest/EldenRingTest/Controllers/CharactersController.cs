using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EldenRing.Models;
using EldenRingTutorial.Context;
using EldenRingTutorial.Repositories.Interfaces;

namespace EldenRingTutorial.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CharactersController : ControllerBase
    {
        private readonly ICharacterRepository _characterRepository;

        public CharactersController(ICharacterRepository characterRepository)
        {
            _characterRepository = characterRepository;
        }

        // GET: api/Characters
        [HttpGet]
        public ActionResult<IEnumerable<Character>> GetCharacters()
        {
            return _characterRepository.GetAll();
        }

        // GET: api/Characters/5
        [HttpGet("{id}")]
        public ActionResult<Character>? GetCharacter(int id)
        {
            var character = _characterRepository.GetById(id);

            if (character == null)
            {
                return NotFound();
            }

            return Ok(character);
        }

        // PUT: api/Characters/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public ActionResult<Character> PutCharacter(int id, Character character)
        {
            if (id != character.Id)
            {
                return BadRequest();
            }

            character = _characterRepository.Update(character);

            return Ok(character);

        }

        // POST: api/Characters
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Character>> PostCharacter(Character character)
        {

            character = _characterRepository.Add(character);
            return Ok(character);
        }

        // DELETE: api/Characters/5
        [HttpDelete("{id}")]
        public ActionResult DeleteCharacter(int id)
        {
            _characterRepository.DeleteById(id);
            return NoContent();
 
        }
    }
}
