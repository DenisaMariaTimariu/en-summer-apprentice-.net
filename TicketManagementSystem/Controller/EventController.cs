using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using TicketManagementSystem.Models.DTO;
//using TMS.Api.Models;
//using TMS.Api.Models.Dto;
using TMS.Api.Repositories;

namespace TMS.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class EventController : ControllerBase
    {
        private readonly IEventRepository _eventRepository;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;




        public EventController(IEventRepository eventRepository, IMapper mapper, ILogger<EventController> logger)
        {
            _eventRepository = eventRepository;
            _mapper = mapper;
            _logger = logger;
        }



        [HttpGet]
        public ActionResult<List<EventDto>> GetAll()
        {
            var events = _eventRepository.GetAll().AsQueryable();

            var eventDto = _mapper.ProjectTo<EventDto>(events);

            return Ok(eventDto);
        }


        [HttpGet("id")]
        public async Task<ActionResult<EventDto>> GetById(int id)
        {
            try
            {

                var @event = await _eventRepository.GetById(id);

                if (@event == null)
                {
                    return NotFound();
                }


                var eventDto = _mapper.Map<EventDto>(@event);
            
                return Ok(eventDto);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return BadRequest(ex.Message);
            }
        }


       [HttpPatch]
        public async Task<ActionResult<EventPatchDto>> Patch(EventPatchDto eventPatch)
        {
            if (eventPatch == null)
            {
                throw new ArgumentNullException(nameof(eventPatch));
            }
          var eventEntity =  await _eventRepository.GetById(eventPatch.EventId);

            if (eventEntity == null)
            {
                return NotFound();
            }
            
            _mapper.Map(eventPatch, eventEntity);
            _eventRepository.Update(eventEntity);
            return Ok(eventEntity);
        }

        [HttpDelete]
        public async Task<ActionResult> Delete(int id)
        {
            var eventEntity = await _eventRepository.GetById(id);

            if (eventEntity == null)
            {
                return NotFound();
            }
            _eventRepository.Delete(eventEntity);
            return NoContent();
        }
    }
}