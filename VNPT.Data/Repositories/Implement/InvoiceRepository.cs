using VNPT.Data.DataTransferObject;
using VNPT.Data.Helpers;
using VNPT.Data.Models;
using Microsoft.EntityFrameworkCore.Internal;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;


namespace VNPT.Data.Repositories
{
    public class InvoiceRepository : Repository<Invoice>, IInvoiceRepository
    {
        private readonly VNPTContext _context;

        public InvoiceRepository(VNPTContext context) : base(context)
        {
            _context = context;
        }
        public Invoice GetByContractIDAndYearAndMonth(int contractID, int year, int month)
        {
            Invoice item = _context.Set<Invoice>().FirstOrDefault(item => item.ContractID.Equals(contractID) && item.Year.Equals(year) && item.Month.Equals(month));
            return item;
        }
    }
}
