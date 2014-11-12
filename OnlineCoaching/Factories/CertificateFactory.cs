using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using OnlineCoaching.Data;
using OnlineCoaching.Models;

namespace OnlineCoaching.Factories
{
    public class CertificateFactory : BaseFactory
    {
        public IQueryable<Certificate> GetCertificateByCoachId(int coachID)
        {
            return this.db.Certificates
                .All()
                .Where(c => c.CoachID == coachID);
        }
    }
}