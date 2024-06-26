﻿using AuthServer.Core.Entity;
using SharedLibrary.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Configuration;
using System.Threading.Tasks;

namespace AuthServer.Core.Services
{
    public interface IServiceGeneric<TEntity,TDto> where TEntity : class where TDto : class 
    {

        Task<Response<TDto>> GetByIdAsync(int id);
        Task<Response<IEnumerable<TDto>>> GetAllAsync();

        
        Task<Response<IEnumerable<TDto>>> Where(Expression<Func<TEntity, bool>> predicate);

        // product.To
        Task<Response<TDto>> AddAsnyc(TDto entity);
        // products.remove(product) savechange gelene kadar silinmiyor . statetinde tutar.
         Task<Response<NoDataDto>> Remove (int id);

        Task<Response<NoDataDto>> Delete(int id);


        Task<Response<NoDataDto>> Update (TDto entity,int id);
        




        // context.Entry(Entity).State==EntityState.Modified
    }
}
