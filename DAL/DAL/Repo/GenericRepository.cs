using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repo
{
    public class GenericRepository<TEntity>
        where TEntity : class, IDbRootModel
    {
        internal DbContext _db;
        internal DbSet<TEntity> _DbSet;



        //*************************        
        //CONSTRUCTORS
        //*************************        
        public GenericRepository(DbContext context)
        {
            this._db = context;
            this._DbSet = context.Set<TEntity>();
        }





        //*************************
        //Async methods
        //*************************
        public virtual async Task<bool> AnyAsync(Expression<Func<TEntity, bool>> predicate, bool isSoftDeleted = false)
        {
            //return await _DbSet.Where(predicate).Where(x => x.IsSoftDeleted == isSoftDeleted).SingleOrDefaultAsync();
            return await _DbSet.Where(x => x.IsSoftDeleted == isSoftDeleted).AnyAsync(predicate);
        }
        public virtual async Task<List<TEntity>> GetAllAsync(bool isSoftDeleted = false)
        {
            return await _DbSet.Where(x => x.IsSoftDeleted == isSoftDeleted).ToListAsync();
        }
        public virtual async Task<TEntity> GetAsync(Int64 id, bool isSoftDeleted = false)
        {
            //*******
            //Checks if the entity is Ml -> thus a subclass iof DbObject
            //if (typeof(T_DbRootModel).IsSubclassOf(typeof(DbObject)))
            //{
            //    //If culture is null set current thread language
            //    languageForEntity = SetThreadLangaugeIfLanguageIsNull(languageForEntity);

            //    T_DbRootModel t_DbRootModel = await _DbSet.FindAsync(id);
            //    if (t_DbRootModel == null)
            //        throw new Exception("ZR in Repository.GetAsync(): the id "+id+" of the entity " + typeof(T_DbRootModel).GetType().Name + " returns a null t_DbRootModel.");

            //    t_DbRootModel = _mlHandlerRead.SetEntityWithMlValues(t_DbRootModel as DbObject, languageForEntity, _db) as T_DbRootModel;
            //    return t_DbRootModel;
            //}

            return await _DbSet.Where(x => x.Id == id && x.IsSoftDeleted == isSoftDeleted).SingleOrDefaultAsync();
        }
        public virtual async Task<TEntity> FindSingleOrDefaultAsync(Expression<Func<TEntity, bool>> predicate, bool isSoftDeleted = false)
        {
            return await _DbSet.Where(predicate).Where(x => x.IsSoftDeleted == isSoftDeleted).SingleOrDefaultAsync();
        }
        public virtual async Task<TEntity> FindSingleAsync(Expression<Func<TEntity, bool>> predicate, bool isSoftDeleted = false)
        {
            return await _DbSet.Where(predicate).Where(x => x.IsSoftDeleted == isSoftDeleted).SingleAsync();
        }
        public virtual async Task<List<TEntity>> WhereToListAsync(Expression<Func<TEntity, bool>> predicate, bool isSoftDeleted = false)
        {
            return await _DbSet.Where(predicate).Where(x => x.IsSoftDeleted == isSoftDeleted).ToListAsync();
        }





        //*************************
        //Non-Async methods
        //*************************
        public virtual bool Any(Expression<Func<TEntity, bool>> predicate, bool isSoftDeleted = false)
        {
            //return await _DbSet.Where(predicate).Where(x => x.IsSoftDeleted == isSoftDeleted).SingleOrDefaultAsync();
            return _DbSet.Where(x => x.IsSoftDeleted == isSoftDeleted).Any(predicate);
        }
        public virtual List<TEntity> GetAll(bool isSoftDeleted = false)
        {
            return _DbSet.Where(x => x.IsSoftDeleted == isSoftDeleted).ToList();
        }
        public virtual TEntity Get(Int64 id, bool isSoftDeleted = false)
        {
            return _DbSet.Where(x => x.Id == id && x.IsSoftDeleted == isSoftDeleted).SingleOrDefault();
        }
        public virtual TEntity FindSingleOrDefault(Expression<Func<TEntity, bool>> predicate, bool isSoftDeleted = false)
        {
            return _DbSet.Where(predicate).Where(x => x.IsSoftDeleted == isSoftDeleted).SingleOrDefault();
        }
        public virtual TEntity FindSingle(Expression<Func<TEntity, bool>> predicate, bool isSoftDeleted = false)
        {
            return _DbSet.Where(predicate).Where(x => x.IsSoftDeleted == isSoftDeleted).Single();
        }
        public virtual List<TEntity> WhereToList(Expression<Func<TEntity, bool>> predicate, bool isSoftDeleted = false)
        {
            return _DbSet.Where(predicate).Where(x => x.IsSoftDeleted == isSoftDeleted).ToList();
        }





        public virtual void Add(TEntity entity)
        {
            if (entity == null)
                throw new Exception("ZR in MlBaseRepository.Add(): entity is null");

            //*******
            //Checks if the entity is Ml -> thus a subclass iof DbObject
            //if (entity.GetType().IsSubclassOf(typeof(DbObject)))
            //{
            //    //If culture is null set current thread language
            //    languageForEntity = SetThreadLangaugeIfLanguageIsNull(languageForEntity);

            //    /*ADD (Step: 01,02,03,04,05,06)*/
            //    _mlHandlerAdd.AddMlValuesInDbFromEntity(entity, languageForEntity);
            //}

            entity.DateTimeUtcCreated = DateTime.UtcNow;
            entity.DateTimeUtcLastUpdated = DateTime.UtcNow;

            _DbSet.Add(entity);
        }
        public virtual void Update(TEntity t_DbRootModel)
        {
            //*********************************
            //Checks if the entity is null
            if (t_DbRootModel == null)
                throw new Exception("ZR in Repository.Update(): the argument 'entity' of type " + typeof(TEntity).Name + " is null.");
            //Check if subclass of dbObject, if true the entity is a Ml entity,thus-> throw exception
            if (typeof(TEntity).IsSubclassOf(typeof(TEntity)))
                throw new Exception("ZR in Repository.Update(): The t_DbRootModel is a subclass of DbObject, thus it's a Ml entity, use the method UpdateLanguage() instead.");

            t_DbRootModel.DateTimeUtcLastUpdated = DateTime.UtcNow;
            _db.Entry<TEntity>(t_DbRootModel).State = EntityState.Modified;
        }
        public virtual void Delete(TEntity t_DbRootModel)
        {
            //This how in Ms Virtual accademy is doing the delete process
            //https://www.youtube.com/watch?v=DUGtcWNlrv8
            //@3:42:10
            //Title youtube video: Deploying Entity Framework with Asp.Net MVC

            if (t_DbRootModel == null)
                throw new Exception("ZR in Rpository.Delete(): t_DbRootModel is null.");


            t_DbRootModel.IsSoftDeleted = true;
            t_DbRootModel.DateTimeUtcLastUpdated = DateTime.UtcNow;
            _db.Entry<TEntity>(t_DbRootModel).State = EntityState.Modified;


            //_DbSet.Remove(t_DbRootModel);

        }
        public virtual void DeletePermanent(TEntity t_DbRootModel)
        {
            _db.Entry(t_DbRootModel).State = EntityState.Deleted;
        }







    }
}
