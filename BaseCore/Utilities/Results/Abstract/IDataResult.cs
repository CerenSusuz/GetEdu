using System;
using System.Collections.Generic;
using System.Text;

namespace BaseCore.Utilities.Results.Abstract
{
    public interface IDataResult<TEntity> : IResult
    {
        TEntity Data { get; }
    }
}
