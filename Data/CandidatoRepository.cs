using Microsoft.EntityFrameworkCore;
using RRHHApi.Entities;
using RRHHApi.Helpers;
using RRHHApi.Interfases;

namespace RRHHApi.Data
{
    public class CandidatoRepository : ICandidatoRepository
    {
        private readonly DataContext _context;
        public CandidatoRepository(DataContext context)
        {
            _context = context;
        }

        public void AgregarCandidato(Candidato candidato)
        {
            _context.Candidatos.Add(candidato);
        }

        public void EliminarCandidato(Candidato candidato)
        {
             _context.Candidatos.Remove(candidato);
        }

        public  IQueryable<Candidato> GetAll()
        {
            return  _context.Candidatos
            .Include(p => p.Empleos)
            .AsQueryable();
            
        }

        public void ModificarCandidato(Candidato candidato)
        {

            _context.Candidatos.Attach(candidato);
            _context.Entry(candidato).State = EntityState.Modified;
        }

        public async Task<Candidato> ObtenerCandidatoPorEmail(string email)
        {
            return await _context.Candidatos
            .Include(p => p.Empleos)
            .SingleOrDefaultAsync(x => x.Email == email);
        }
    }
}
