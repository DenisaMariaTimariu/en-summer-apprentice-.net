using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TicketManagementSystem.Models.DTO;
using TicketManagementSystem.Repositories;

namespace TicketManagementSystem.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IMapper _mapper;

        public OrderController(IOrderRepository orderRepository, IMapper mapper) { 
        
            _orderRepository = orderRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult<OrderDto> getAllOrders()
        {
            var order = _orderRepository.GetAll().AsQueryable();

            
            var orderDto = _mapper.ProjectTo<OrderDto>(order);
           

            return Ok(orderDto);
        }

      [HttpGet("id")]
        public async Task<ActionResult<OrderDto>> getOrdersById(int id) {

            var @order = await _orderRepository.GetById(id);

            if (@order == null)
            {
                return NotFound();
            }

            var orderDto = _mapper.Map<OrderDto>(@order);

            return Ok(orderDto);
        }



        [HttpPatch]
        public async Task<ActionResult<OrderPatchDto>>Patch(OrderPatchDto orderPatch)
        {
            var orderEntity =await _orderRepository.GetById(orderPatch.OrderId);

            if (orderEntity == null)
            {
                return NotFound();
            }

            _mapper.Map(orderPatch, orderEntity);
            _orderRepository.Update(orderEntity);
            return Ok(orderEntity);
        }

        [HttpDelete]
        public async Task<ActionResult> Delete(int id)
        {
            var eventEntity =await _orderRepository.GetById(id);

            if (eventEntity == null)
            {
                return NotFound();
            }
            _orderRepository.Delete(eventEntity);
            return NoContent();
        }
    }
}
