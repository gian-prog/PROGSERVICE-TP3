using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.DotNet.Scaffolding.Shared.Messaging;
using Microsoft.EntityFrameworkCore;
using TP3__FlappyBirb.Data;
using TP3__FlappyBirb.Models;
using TP3__FlappyBirb.Services;

namespace TP3__FlappyBirb.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [Authorize]
    public class ScoresController : ControllerBase
    {
        private readonly ScoreTP3service _scoreTP3Service;
        readonly UserManager<User> _userManager;

        public ScoresController(ScoreTP3service scoreTP3Service, UserManager<User> userManager)
        {
            _scoreTP3Service = scoreTP3Service;
            _userManager = userManager;
        }
        // GET
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Scores>>> GetPublicScores()
        {
            var scores = await _scoreTP3Service.GetPublicScoresAsync();
            if (scores == null)
            {
                return NotFound( new { Message = "Aucun score public trouvé" });
            }

            return Ok(scores);
        }

        // GET
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Scores>>> GetMyScores()
        {
            //Trouver l'utilisateur via son token
            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            User? user = await _userManager.FindByIdAsync(userId);
            if (user == null) return Unauthorized(new {Message =""}); // Non authentifié ou token invalide
            if (!_scoreTP3Service.IsScoreValid()) return StatusCode(StatusCodes.Status500InternalServerError,
            new { Message = "Veuillez réessayer plus tard." }); // Problème avec la BD ?
            return user.scores;
        }

        // PUT
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> ChangeScoreVisibility(int id)
        {
            Scores? score = await _scoreTP3Service.GetScoreByIdAsync(id);
            if (score == null)
            {
                return NotFound();
            }

            try
            {
                //Modifie la visibilité du score
                await _scoreTP3Service.ScoreVisibiliteAsync(score);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_scoreTP3Service.ScoreExists(id))
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

        // POST
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Scores>> PostScore(Scores score)
        {
            // Trouver l'utilisateur via son token (Id de l'utilisateur)
            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            User? user = await _userManager.FindByIdAsync(userId);

            if (user == null)
            {
                return StatusCode(StatusCodes.Status400BadRequest,
                    new { Message = "Utilisateur non trouvé." });
            }

            // Associer l'utilisateur au score
            score.User = user;
            score.Date = DateTime.Now;
            // Ajouter le score à l'utilisateur
            user.scores.Add(score);


            // Utiliser le service pour enregistrer le score dans la base de données
             await _scoreTP3Service.CreateScoresAsync(score);

            return Ok(user.scores);
        }

    }
}
