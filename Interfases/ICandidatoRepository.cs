using RRHHApi.Entities;

namespace RRHHApi.Interfases
{
    public interface ICandidatoRepository
    {

        IQueryable<Candidato> GetAll();

        void AgregarCandidato(Candidato candidato);

        void ModificarCandidato(Candidato candidato);

        Task<Candidato> ObtenerCandidatoPorEmail(string email);

        void EliminarCandidato(Candidato candidato);
    }
}
