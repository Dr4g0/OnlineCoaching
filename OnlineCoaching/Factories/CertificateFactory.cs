using System;
using System.Linq;
using OnlineCoaching.Data;
using OnlineCoaching.Models;

namespace OnlineCoaching.Factories
{
    public class CertificateFactory
    {
        private IOnlineCoachingData db;

        public CertificateFactory(IOnlineCoachingData db)
        {
            this.db = db;
        }

        public IQueryable<Certificate> GetCertificateByCoachId(int coachID)
        {
            return this.db.Certificates
                .All()
                .Where(c => c.CoachID == coachID);
        }
    }
}