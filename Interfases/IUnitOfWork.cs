namespace RRHHApi.Interfases
{
    public interface IUnitOfWork
    {
        ICandidatoRepository candidatoRepository { get; }


        Task<bool> Complete();

        bool HasChanges();
    }
}
