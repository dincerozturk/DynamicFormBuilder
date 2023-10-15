namespace DynamicFormBuilder.Domain
{
    public interface ISuccess
    {
        bool Success { get; set; }
    }
    public interface IMessage
    {
        string Message { get; set; }
    }
    public interface IData<T>
    {
        T Data { get; set; }
    }
    public interface IRecordsTotal
    {
        int RecordsTotal { get; set; }
    }
    public interface IRecordsFiltered
    {
        int RecordsFiltered { get; set; }
    }



    public interface IPagedData<T> : IData<IEnumerable<T>>, IRecordsTotal, IRecordsFiltered
    {
    }

    #region Result
    public interface IDataResult : ISuccess, IMessage
    {
    }
    public interface IDataResult<T> : IDataResult, IData<T>
    {
    }
    public interface IPagedDataResult<T> : IDataResult<IEnumerable<T>>, IPagedData<T>
    {
    }

    public abstract class APagedData<T> : IPagedData<T>
    {
        public APagedData()
        {

        }
        public APagedData(int recordsTotal, int recordsFiltered, IEnumerable<T> data)
        {
            RecordsTotal = recordsTotal;
            RecordsFiltered = recordsFiltered;
            Data = data;
        }
        public IEnumerable<T> Data { get; set; }
        public int RecordsTotal { get; set; }
        public int RecordsFiltered { get; set; }
    }

    public class PagedData<T> : APagedData<T>
    {
        public PagedData() : base()
        {

        }
        public PagedData(int recordsTotalCount, int recordsFilteredCount, IEnumerable<T> data) : base(recordsTotalCount, recordsFilteredCount, data)
        {

        }
    }

    public abstract class ADataResult : IDataResult
    {
        public ADataResult()
        {

        }
        public ADataResult(bool success)
        {
            Success = success;
        }
        public ADataResult(bool success, string message)
        {
            Success = success;
            Message = message;
        }
        public bool Success { get; set; }
        public string Message { get; set; }
    }
    public abstract class ADataResult<T> : ADataResult, IDataResult<T>
    {
        public ADataResult()
        {

        }
        public ADataResult(bool success) : base(success)
        {
        }
        public ADataResult(bool success, string message) : base(success, message)
        {
        }
        public ADataResult(T data, bool success, string message) : base(success, message)
        {
            Data = data;
        }
        public T Data { get; set; }
    }

    public class DataResult : ADataResult
    {
        public DataResult()
        {

        }
        public DataResult(bool success) : base(success)
        {
        }
        public DataResult(bool success, string message) : base(success, message)
        {
        }
    }

    public class DataResult<T> : ADataResult<T>
    {
        public DataResult()
        {

        }
        public DataResult(bool success) : base(success)
        {
        }
        public DataResult(bool success, string message) : base(success, message)
        {
        }
        public DataResult(T data, bool success, string message) : base(success, message)
        {
            Data = data;
        }
    }

    public class PagedDataResult<T> : ADataResult<IEnumerable<T>>, IPagedDataResult<T>
    {
        public int RecordsTotal { get; set; }
        public int RecordsFiltered { get; set; }

        public PagedDataResult()
        {

        }
        public PagedDataResult(bool success) : base(success)
        {
        }
        public PagedDataResult(bool success, string message) : base(success, message)
        {
        }
        public PagedDataResult(IEnumerable<T> data, bool success, string message) : base(success, message)
        {
            Data = data;
        }
        public PagedDataResult(int recordsTotalCount, int recordsFilteredCount, IEnumerable<T> data, bool success, string message) : base(success, message)
        {
            RecordsTotal = recordsTotalCount;
            RecordsFiltered = recordsFilteredCount;
            Data = data;
        }
    }
    #endregion
}
