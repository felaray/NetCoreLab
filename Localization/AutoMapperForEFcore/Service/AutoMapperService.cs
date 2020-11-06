using AutoMapper;
using AutoMapper.EquivalencyExpression;
using AutoMapperForEFcore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AutoMapperForEFcore.Service
{
    public interface IAutoMapperService
    {
        public object NewData<T>(T listA, T listB);
        public object UpdateData<T>(T listA, T listB);
        public object RemoveData<T>(T listA, T listB);
    }

    public class AutoMapperService : IAutoMapperService
    {
        public object NewData<T>(T listA, T listB)
        {
            throw new NotImplementedException();
        }

        public object RemoveData<T>(T listA, T listB)
        {
            throw new NotImplementedException();
        }

        public object UpdateData<T>(T listA, T listB)
        {
            throw new NotImplementedException();
        }
    }
}
