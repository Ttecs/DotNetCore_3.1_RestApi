using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dotnet_rpg.Dtos.Character;
using dotnet_rpg.Models;
using dotnet_rpg.Services.CharacterService;
using Microsoft.AspNetCore.Mvc;

namespace dotnet_rpg.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CharacterController : ControllerBase
    {
       
        private readonly ICharacterService _characterService;

        public CharacterController(ICharacterService characterService)
        {
            this._characterService = characterService;

        }

        [HttpGet("getall")]
        public async Task <IActionResult> Get()
        {

            return Ok(await _characterService.GetAllCharacter());
        }
        [HttpGet("{id}")]
        public async Task <IActionResult> GetSingle(int id)
        {
            return Ok(await _characterService.GetCharacterById(id));
        }
        [HttpPost]
        public async Task<IActionResult> AddCharacter(Character newCharacter)
        {
           
            return Ok( await _characterService.AddCharacterto(newCharacter));
        }
        [HttpPut]
        public async Task<IActionResult> UpdateCharacter(UpdateCharacterDto updatedCharacter)
        {
           ServiceResponse<GetCharacterDto> response = await _characterService.UpdateCharacter(updatedCharacter);
           if (response.Data==null){
               return NotFound(response);
           }
            return Ok(response);
        }

          [HttpDelete("{id}")]
        public async Task <IActionResult> Delete(int id)
        {
              ServiceResponse<List<GetCharacterDto>> response = await _characterService.DeleteCharacter(id);
           if (response.Data==null){
               return NotFound(response);
           }
            return Ok(response);
        }
    }
}