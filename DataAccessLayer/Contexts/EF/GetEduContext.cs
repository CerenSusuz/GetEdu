using System;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Core.Objects;
using System.Linq;
using BaseCore.Entities.Concrete;

namespace DataAccessLayer.Contexts.EF
{
    public partial class GetEduContext : DbContext
    {
        //TODO:ef6
        public GetEduContext() : base("name=GetEduDb")
        {

        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }

        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<UserOperationClaimPairing> UserOperationClaimPairings { get; set; }
        public virtual DbSet<OperationClaim> OperationClaims { get; set; }

    }
}
