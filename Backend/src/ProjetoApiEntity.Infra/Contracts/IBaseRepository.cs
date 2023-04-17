namespace ProjetoApiEntity.Infra.Contracts
{
    public interface IBaseRepository<T> 
        where T : class
    {
        void Create(T obj);
        void Update(T obj);
        void Delete(T obj);

        List<T> GetAll();
        T GetById(Guid id);
    }
}