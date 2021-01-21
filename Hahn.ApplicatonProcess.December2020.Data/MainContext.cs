using Hahn.ApplicatonProcess.December2020.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hahn.ApplicatonProcess.December2020.Data
{
    public class MainContext : DbContext
    {
        public DbSet<Applicant> Applicant { get; set; }

        public MainContext(DbContextOptions options) : base(options)
        {
            //LoadApplicant();
        }

        //public void LoadApplicant()
        //{
        //    Applicant applicant = new Applicant() { Name = "Applicant1" };
        //    Applicant.Add(applicant);
        //    applicant = new Applicant() { Name = "Applicant2" };
        //    Applicant.Add(applicant);
        //}

        //public List<Applicant> GetApplicant()
        //{
        //    return Applicant.Local.ToList<Applicant>();
        //}
    }
}
