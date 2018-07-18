namespace ADoExam.Model
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class MCSSSS : DbContext
    {
        public MCSSSS()
            : base("name=MCSSSS")
        {
        }

        public virtual DbSet<newEquipment> newEquipment { get; set; }
        public virtual DbSet<TableEvaluationSysStatus> TableEvaluationSysStatus { get; set; }
        public virtual DbSet<TablesModel> TablesModel { get; set; }
        public virtual DbSet<TrackEvaluation> TrackEvaluation { get; set; }
        public virtual DbSet<TrackEvaluationPart> TrackEvaluationPart { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TablesModel>()
                .HasMany(e => e.newEquipment)
                .WithRequired(e => e.TablesModel)
                .WillCascadeOnDelete(false);
        }
    }
}
