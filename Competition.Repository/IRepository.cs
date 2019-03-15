using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Competition.Repository
{
    interface IRepository<TEntity, TPrimaryKey> where TEntity : class
    { 
         /// <summary>
         /// 主键数据
         /// </summary>
         /// <param name="id"></param>
         /// <returns></returns>
        TEntity Get(TPrimaryKey id);

        /// <summary>
        /// 主键数据
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<TEntity> GetAsync(TPrimaryKey id);

        /// <summary>
        /// 指定条件的首条数据
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        TEntity FirstOrDefault(Expression<Func<TEntity, bool>> predicate);

        /// <summary>
        /// 指定条件的首条数据
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        Task<TEntity> FirstOrDefaultAsync(Expression<Func<TEntity, bool>> predicate);

        /// <summary>
        /// 主键数据
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        TEntity FirstOrDefault(TPrimaryKey id);

        /// <summary>
        /// 主键数据
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<TEntity> FirstOrDefaultAsync(TPrimaryKey id);

        /// <summary>
        /// 获取全部数据
        /// </summary>
        /// <returns></returns>
        IEnumerable<TEntity> GetAll();

        /// <summary>
        /// 获取全部数据
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<TEntity>> GetAllAsync();

        /// <summary>
        /// 指定条件的数据
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        IEnumerable<TEntity> GetAll(Expression<Func<TEntity, bool>> predicate);

        /// <summary>
        /// 指定条件的数据
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        Task<IEnumerable<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> predicate);

        //TODO 分页待定
        /// <summary>
        /// 分页数据
        /// </summary>
        /// <param name="predicate">查询条件</param>
        /// <param name="pageNumber">页码</param>
        /// <param name="itemsPerPage">每页数量</param>
        /// <param name="sortingProperty">排序字段</param>
        /// <param name="ascending">true：ascending</param>
        /// <returns></returns>
        IEnumerable<TEntity> GetAllPaged(Expression<Func<TEntity, bool>> predicate, int pageNumber, int itemsPerPage, string sortingProperty, bool ascending = true);

        /// <summary>
        /// 分页数据
        /// </summary>
        /// <param name="predicate">插叙条件</param>
        /// <param name="pageNumber">页码</param>
        /// <param name="itemsPerPage">每页数量</param>
        /// <param name="ascending">true：ascending</param>
        /// <param name="sortingExpression">排序字段</param>
        /// <returns></returns>
        IEnumerable<TEntity> GetAllPaged(Expression<Func<TEntity, bool>> predicate, int pageNumber, int itemsPerPage, bool ascending = true, params Expression<Func<TEntity, object>>[] sortingExpression);


        /// <summary>
        /// 分页数据
        /// </summary>
        /// <param name="predicate">查询条件</param>
        /// <param name="pageNumber">页码</param>
        /// <param name="itemsPerPage">每页数量</param>
        /// <param name="sortingProperty">排序字段</param>
        /// <param name="ascending">true：ascending</param>
        /// <returns></returns>
        Task<IEnumerable<TEntity>> GetAllPagedAsync(Expression<Func<TEntity, bool>> predicate, int pageNumber, int itemsPerPage, string sortingProperty, bool ascending = true);

        /// <summary>
        /// 分页数据
        /// </summary>
        /// <param name="predicate">插叙条件</param>
        /// <param name="pageNumber">页码</param>
        /// <param name="itemsPerPage">每页数量</param>
        /// <param name="ascending">true：ascending</param>
        /// <param name="sortingExpression">排序字段</param>
        /// <returns></returns>
        Task<IEnumerable<TEntity>> GetAllPagedAsync(Expression<Func<TEntity, bool>> predicate, int pageNumber, int itemsPerPage, bool ascending = true, params Expression<Func<TEntity, object>>[] sortingExpression);

        /// <summary>
        /// 返回总条数
        /// </summary>
        /// <returns></returns>
        int Count();

        /// <summary>
        /// 返回总条数
        /// </summary>
        /// <returns></returns>
        Task<int> CountAsync();

        /// <summary>
        /// 返回指定查询条件的条数
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        int Count(Expression<Func<TEntity, bool>> predicate);

        /// <summary>
        /// 返回指定查询条件的条数
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        Task<int> CountAsync(Expression<Func<TEntity, bool>> predicate);

        /// <summary>
        /// 执行SQL语句
        /// </summary>
        /// <param name="query"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        IEnumerable<TEntity> Query(string query, object parameters = null);

        /// <summary>
        /// 执行SQL语句
        /// </summary>
        /// <param name="query"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        Task<IEnumerable<TEntity>> QueryAsync(string query, object parameters = null);

        /// <summary>
        /// 执行SQL语句
        /// </summary>
        /// <typeparam name="TAny"></typeparam>
        /// <param name="query"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        IEnumerable<TAny> Query<TAny>(string query, object parameters = null) where TAny : class;

        /// <summary>
        /// 执行SQL查询语句
        /// </summary>
        /// <typeparam name="TAny"></typeparam>
        /// <param name="query"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        Task<IEnumerable<TAny>> QueryAsync<TAny>(string query, object parameters = null) where TAny : class;

        /// <summary>
        /// 执行SQL语句
        /// </summary>
        /// <param name="query"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        int Execute(string query, object parameters = null);

        /// <summary>
        /// 执行SQL语句
        /// </summary>
        /// <param name="query"></param>
        /// <param name="parameters"></param>
        /// <returns>影响的条数</returns>
        Task<int> ExecuteAsync(string query, object parameters = null);

        /// <summary>
        /// 插入数据
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        TEntity Insert(TEntity entity);

        /// <summary>
        /// 插入数据
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        Task<TEntity> InsertAsync(TEntity entity);

        /// <summary>
        /// 插入数据并返回主键
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        TPrimaryKey InsertAndGetId(TEntity entity);

        /// <summary>
        /// 插入数据并返回主键
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        Task<TPrimaryKey> InsertAndGetIdAsync(TEntity entity);

        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="entity"></param>
        TEntity Update(TEntity entity);

        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        Task<TEntity> UpdateAsync(TEntity entity);

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="entity"></param>
        void Delete(TEntity entity);

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        Task DeleteAsync(TEntity entity);

        /// <summary>
        /// 指定条件删除
        /// </summary>
        /// <param name="predicate"></param>
        void Delete(Expression<Func<TEntity, bool>> predicate);

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        Task DeleteAsync(Expression<Func<TEntity, bool>> predicate);

        /// <summary>
        /// 插入或更新(存在则更新，否则插入),并返回结果数据
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        TEntity InsertOrUpdate(TEntity entity);

        /// <summary>
        /// 插入或更新(存在则更新，否则插入),并返回结果数据
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        Task<TEntity> InsertOrUpdateAsync(TEntity entity);

        /// <summary>
        /// 插入或更新(存在则更新，否则插入)，并返回主键
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        TPrimaryKey InsertOrUpdateAndGetId(TEntity entity);

        /// <summary>
        /// 插入或更新(存在则更新，否则插入)，并返回主键
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        Task<TPrimaryKey> InsertOrUpdateAndGetIdAsync(TEntity entity);
    }
}
