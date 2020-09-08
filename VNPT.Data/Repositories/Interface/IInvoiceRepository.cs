using VNPT.Data.DataTransferObject;
using VNPT.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace VNPT.Data.Repositories
{
    public interface IInvoiceRepository : IRepository<Invoice>
    {
        public Invoice GetByContractIDAndYearAndMonth(int contractID, int year, int month);
    }
}
