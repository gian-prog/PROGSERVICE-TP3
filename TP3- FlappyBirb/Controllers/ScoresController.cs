using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TP3__FlappyBirb.Data;
using TP3__FlappyBirb.Models;

namespace TP3__FlappyBirb.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [Authorize]
    public class ScoresController : ControllerBase
    {
        private readonly TP3__FlappyBirbContext _context;

        public ScoresController(TP3__FlappyBirbContext context)
        {
            _context = context;
        }

        // GET: api/Scores
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Scores>>> GetScores()
        {
            return await _context.Scores.ToListAsync();
        }

        // GET: api/Scores/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Scores>> GetScores(int id)
        {
            var scores = await _context.Scores.FindAsync(id);

            if (scores == null)
            {
                return NotFound();
            }

            return scores;
        }

        // PUT: api/Scores/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutScores(int id, Scores scores)
        {
            if (id != scores.Id)
            {
                return BadRequest();
            }

            _context.Entry(scores).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ScoresExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Scores
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Scores>> PostScores(Scores scores)
        {
            if(_context.Scores == null)
            {
                return Problem("Entity set 'TP3__FlabbyBirbContext.Scores'is null.");
            }
            //Trouver l'utilisateur via son token
            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            User? user = await _context.Users.FindAsync(userId);

            if(user != null) 
            {
                //Remplit références de relation
                scores.User = user;
                user.scores.Add(scores);

                //Ajouter le score dans BD
                _context.Scores.Add(scores);
                await _context.SaveChangesAsync();

                return CreatedAtAction("GetScores", new { id = scores.Id }, scores);
            }
            return StatusCode(StatusCodes.Status400BadRequest, new { Message = "Utilisateur non trouvé." });
        }

        // DELETE: api/Scores/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteScores(int id)
        {
            var scores = await _context.Scores.FindAsync(id);
            if (scores == null)
            {
                return NotFound();
            }

            _context.Scores.Remove(scores);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ScoresExists(int id)
        {
            return _context.Scores.Any(e => e.Id == id);
        }
    }
}
