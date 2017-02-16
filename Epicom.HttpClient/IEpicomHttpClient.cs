using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using EasyAsyncEnumerable;

namespace Epicom.Http.Client
{
    public interface IEpicomHttpClient
    {
        Uri BaseUri { get; }

        Task<T> GetAsync<T>(IResponse<T> request);
        Task<T> PostAsync<T>(IResponse<T> request);
        Task<T> PatchAsync<T>(IResponse<T> request);
        Task<T> DeleteAsync<T>(IResponse<T> request);

        [Obsolete("Trocar os métodos que realizam PUT por PATCH")]
        Task<T> PutAsync<T>(IResponse<T> request);

        IAsyncEnumerable<T> GetPaged<T>(IResponse<IEnumerable<T>> request);
    }
}
