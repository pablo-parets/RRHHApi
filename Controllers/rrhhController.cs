using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using RRHHApi.Entities;
using RRHHApi.Interfases;

namespace RRHHApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class rrhhController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public rrhhController(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet]
        public IEnumerable<Candidato> GetAll()
        {
            return  _unitOfWork.candidatoRepository.GetAll();
        }




        [HttpPost]
        public async Task< ActionResult> AgregarCandidato(Candidato candidato)
        {
             _unitOfWork.candidatoRepository.AgregarCandidato(candidato);

           if  (await _unitOfWork.Complete() )return Ok("");

            return BadRequest("Error al agregar el candidato");
        }

        [HttpPut]
        public async Task<ActionResult> ModificarCandidato(Candidato candidato)
        {
            var email = candidato.Email;
            var candidatoAmodificar = await _unitOfWork.candidatoRepository.ObtenerCandidatoPorEmail(email);

            if (candidatoAmodificar!=null)
            {
                _mapper.Map(candidato, candidatoAmodificar);
                _unitOfWork.candidatoRepository.ModificarCandidato(candidatoAmodificar);
            }

            if (await _unitOfWork.Complete()) return Ok("");

            return BadRequest("Error al modificar el candidato");
        }

        [HttpDelete]
        public async Task<ActionResult> EliminarCandidato(string email)
        {

            var candidatoAEliminar = await _unitOfWork.candidatoRepository.ObtenerCandidatoPorEmail(email);

            if (candidatoAEliminar != null)

               _unitOfWork.candidatoRepository.EliminarCandidato(candidatoAEliminar);

            if (await _unitOfWork.Complete()) return Ok();

            return BadRequest("Error eliminar el candidato");

        }
    }
}
