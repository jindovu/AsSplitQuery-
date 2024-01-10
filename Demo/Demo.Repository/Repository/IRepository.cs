﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Demo.Repository.Repository
{
    public interface IRepository<T> where T : class
    {
        /// <summary>
        /// Function use to get Object flow Id
        /// </summary>
        /// <param name="id">Primary key of Table current</param>
        /// <returns></returns>
        T GetById(int id);

        /// <summary>
        /// Get one object asyn by id 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<T> GetAsyncById(int id);

        /// <summary>
        /// Function use in the case Query have condition
        /// </summary>
        /// <param name="filter">Condition of query</param>
        /// <returns></returns>
        IQueryable<T> Query(Expression<Func<T, bool>> filter);

        /// <summary>
        /// Function use to Update Object 
        /// </summary>
        /// <param name="entity">Object is targer Update</param>
        /// <returns></returns>
        T Update(T entity);

        /// <summary>
        /// Update multiple objects 
        /// </summary>
        /// <param name="listItem"></param>
        /// <returns></returns>
        List<T> UpdateMulti(List<T> listItem);

        /// <summary>
        /// Function use to Insert Object 
        /// </summary>
        /// <param name="entity">Object is targer Update</param>
        /// <returns></returns>
        T Insert(T entity);

        /// <summary>
        /// Inserts the multiple entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns></returns>
        List<T> InsertMulti(List<T> entity);

        /// <summary>
        /// Function use to Remove Object in Database
        /// </summary>
        /// <param name="id">Id is identity</param>
        /// <returns></returns>
        bool Delete(dynamic id);

        /// <summary>
        /// Deletes the mullti.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns></returns>
        bool DeleteMulti(List<T> entity);

        /// <summary>
        /// Query get one object and include another tables relationship
        /// </summary>
        /// <param name="expression"></param>
        /// <param name="includes"></param>
        /// <returns></returns>
        T Find(Expression<Func<T, bool>> expression, params Expression<Func<T, object>>[] includes);

        /// <summary>
        /// Query by condition and include multiple tables relationship
        /// </summary>
        /// <param name="expression"></param>
        /// <param name="includes"></param>
        /// <returns></returns>
        List<T> FindAll(Expression<Func<T, bool>> expression, params Expression<Func<T, object>>[] includes);
    }

}
