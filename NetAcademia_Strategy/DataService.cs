using NetAcademia_Adapter;
using System;
using System.Collections.Generic;

namespace NetAcademia_Strategy
{
    public class DataService
    {
        private IAddressRepository repository;
        private IStrategy strategy;

        public DataService(IAddressRepository repository)
        {
            if (repository == null) throw new ArgumentNullException(nameof(repository));

            this.repository = repository;
        }

        public DataService(IAddressRepository repository, IStrategy strategy) : this(repository)
        {
            if (strategy == null) throw new ArgumentNullException(nameof(strategy));

            this.strategy = strategy;
        }

        public int GetSumEmailCount()
        {
            var list = repository.GetAddresses();

            var sum = 0;

            foreach (var address in list)
            {
                sum += address.EmailCount;
            }
            return sum;
        }

        public int GetAverageEmailCount()
        {
            var sum = GetSumEmailCount();
            var list = repository.GetAddresses();

            return sum / list.Count;
        }

        public int Report(ReportType rt)
        {
            switch (rt)
            {
                case ReportType.Sum:
                    return GetSumEmailCount();
                case ReportType.Average:
                    return GetAverageEmailCount();
                default:
                    throw new ArgumentOutOfRangeException($"{nameof(rt)}: {rt}");
            }
        }

        public int ReportWithStrategy()
        {
            var list = repository.GetAddresses();
            return strategy.Operation(list);
        }

        public int ReportWithDelegate(Func<IList<Address>, int> strategy)
        {
            if (strategy == null) throw new ArgumentNullException(nameof(strategy));

            return strategy(repository.GetAddresses());
        }
    }


    public enum ReportType
    {
        Sum,
        Average
    }
}