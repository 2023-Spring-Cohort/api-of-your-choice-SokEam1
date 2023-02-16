namespace EldenRingTutorial.Repositories.Interfaces
{
    public interface IRepository<TEntity>
        where TEntity : class
    {
        List<TEntity>GetAll(); //Read
        TEntity? GetById(int id); //Read
        TEntity Add(TEntity entity); //Create
        TEntity Update(TEntity entity); //Update
        void DeleteById(int id); //Delete
    }
}
