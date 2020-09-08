using VNPT.Data.Helpers;
using VNPT.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;
using System.Data.SqlClient;
using System.Data;

namespace VNPT.Data.Repositories
{
    public class MembershipRepository : Repository<Membership>, IMembershipRepository
    {
        private readonly VNPTContext _context;

        public MembershipRepository(VNPTContext context) : base(context)
        {
            _context = context;
        }
        public Membership GetByTaxCode(string taxCode)
        {
            Membership item = _context.Set<Membership>().FirstOrDefault(item => item.TaxCode.Equals(taxCode));
            return item;
        }
        public List<Membership> GetByCityIDToList(int cityID)
        {
            List<Membership> list = new List<Membership>();
            if (cityID > 0)
            {
                list = _context.Set<Membership>().Where(item => item.CityID == cityID).OrderBy(item => item.FullName).ToList();
            }
            return list;
        }
        public List<Membership> GetByProductIDToList(int productID)
        {
            List<Membership> list = new List<Membership>();
            if (productID > 0)
            {
                SqlParameter[] parameters =
                {
                new SqlParameter("@ProductID",productID)
                };
                DataTable dt = SQLHelper.Fill(AppGlobal.ConectionString, "sp_MembershipSelectByProductID", parameters);
                list = SQLHelper.ToList<Membership>(dt);
            }
            return list;
        }
        public List<Membership> GetByProductIDNotToList(int productID)
        {
            List<Membership> list = new List<Membership>();
            if (productID > 0)
            {
                SqlParameter[] parameters =
                {
                new SqlParameter("@ProductID",productID)
                };
                DataTable dt = SQLHelper.Fill(AppGlobal.ConectionString, "sp_MembershipSelectByProductIDNot", parameters);
                list = SQLHelper.ToList<Membership>(dt);
            }
            return list;
        }
        public List<Membership> GetByProductIDAndCityIDToList(int productID, int cityID)
        {
            List<Membership> list = new List<Membership>();
            if (productID > 0)
            {
                SqlParameter[] parameters =
                {
                new SqlParameter("@ProductID",productID),
                new SqlParameter("@CityID",cityID)
                };
                DataTable dt = SQLHelper.Fill(AppGlobal.ConectionString, "sp_MembershipSelectByProductIDAndCityID", parameters);
                list = SQLHelper.ToList<Membership>(dt);
            }
            return list;
        }
        public List<Membership> GetByProductIDNotAndCityIDToList(int productID, int cityID)
        {
            List<Membership> list = new List<Membership>();
            if (productID > 0)
            {
                SqlParameter[] parameters =
                {
                new SqlParameter("@ProductID",productID),
                new SqlParameter("@CityID",cityID)
                };
                DataTable dt = SQLHelper.Fill(AppGlobal.ConectionString, "sp_MembershipSelectByProductIDNotAndCityID", parameters);
                list = SQLHelper.ToList<Membership>(dt);
            }
            return list;
        }
        public List<Membership> GetByProductIDAndCityIDAndActionToList(int productID, int cityID, int action)
        {
            List<Membership> list = new List<Membership>();
            switch (action)
            {
                case 0:
                    list = GetByProductIDToList(productID);
                    break;
                case 1:
                    list = GetByProductIDAndCityIDToList(productID, cityID);
                    break;
            }
            return list;
        }
        public List<Membership> GetByProductIDNotAndCityIDAndActionToList(int productID, int cityID, int action)
        {
            List<Membership> list = new List<Membership>();
            switch (action)
            {
                case 0:
                    list = GetByProductIDNotToList(productID);
                    break;
                case 1:
                    list = GetByProductIDNotAndCityIDToList(productID, cityID);
                    break;
            }
            return list;
        }
    }
}
