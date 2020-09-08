using VNPT.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace VNPT.Data.Repositories
{
    public interface IMembershipRepository : IRepository<Membership>
    {
        public Membership GetByTaxCode(string taxCode);
        public List<Membership> GetByCityIDToList(int cityID);
        public List<Membership> GetByProductIDAndCityIDAndActionToList(int productID, int cityID, int action);
        public List<Membership> GetByProductIDNotAndCityIDAndActionToList(int productID, int cityID, int action);
    }
}
