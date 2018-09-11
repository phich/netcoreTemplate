using System;
namespace CreateTemplate.Core.Results
{
    public class SearchResult<T>
    {
        #region Properties

        /// <summary>
        /// Record(s) returned from back-end api service.
        /// </summary>
        public T Data { get; set; }

        /// <summary>
        /// Total number of records statisfied conditions.
        /// </summary>
        public int Total { get; set; }
        public string Message { get; set; }

        #endregion
    }
}
