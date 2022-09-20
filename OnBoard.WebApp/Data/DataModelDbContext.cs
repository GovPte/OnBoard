using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

using OnBoard.WebApp.Data.Tables;

namespace OnBoard.WebApp.Data
{
    public class DataModelDbContext : DbContext
    {
        //To update the database (make sure blank "OnBoard" database created first)
        //  Open View > Package Manager Console

        //dotnet ef migrations add Migration0** --project OnBoard.WebApp --context DataModelDbContext (updates Project)
        //dotnet ef database update --project OnBoard.WebApp --context DataModelDbContext --startup-project OnBoard.WebApp (updates Database)

        //dotnet ef migrations remove --project OnBoard.WebApp --context DataModelDbContext --startup-project OnBoard.WebApp (removes latest migration)

        public IConfiguration Configuration { get; }
        public DataModelDbContext(DbContextOptions<DataModelDbContext> options, IConfiguration configuration)
            : base(options) 
        {
            Configuration = configuration;
        }

        public DataModelDbContext() { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //using appsettings.json instead...
            optionsBuilder.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"));
        }

        protected override void OnModelCreating(ModelBuilder mb)
        {
            //The entity type 'Microsoft.AspNet.Identity.EntityFramework.IdentityUserLogin<string>' requires a key to be defined
            //https://stackoverflow.com/questions/34000091/the-entity-type-microsoft-aspnet-identity-entityframework-identityuserloginstr

            //===========//
            // Seed data //
            //===========//

            //Add Municipalities and States
            mb.Entity<State>().HasData(new State { StateID = 1, StateName = "Michigan", StateNamePostal = "MI" });
            mb.Entity<Municipality>().HasData(new Municipality { MunicipalityID = 1, MunicipalityName = "Eastpointe", StateID = 1 });
            mb.Entity<Municipality>().HasData(new Municipality { MunicipalityID = 2, MunicipalityName = "Roseville", StateID = 1 });
            mb.Entity<Municipality>().HasData(new Municipality { MunicipalityID = 3, MunicipalityName = "Detroit", StateID = 1 });
            mb.Entity<Municipality>().HasData(new Municipality { MunicipalityID = 4, MunicipalityName = "Clinton Township", StateID = 1 });
            mb.Entity<Municipality>().HasData(new Municipality { MunicipalityID = 5, MunicipalityName = "St. Clair Shores", StateID = 1 });
            mb.Entity<Municipality>().HasData(new Municipality { MunicipalityID = 6, MunicipalityName = "Fraser", StateID = 1 });
            mb.Entity<Municipality>().HasData(new Municipality { MunicipalityID = 7, MunicipalityName = "Warren", StateID = 1 });
            mb.Entity<Municipality>().HasData(new Municipality { MunicipalityID = 8, MunicipalityName = "Center Line", StateID = 1 });

            //Add Organizations
            //  This abstraction is used in case there is a multi-jurisdictional organization
            mb.Entity<Organization>().HasData(new Organization
            { OrganizationID = 1, OrganizationName = "City of Eastpointe", OrganizationWebsite = "https://www.EastpointeMI.gov" });

            //Insert Commissions...
            mb.Entity<Commission>().HasData(new Commission { CommissionID = 1, CommissionName = "Arts and Cultural Diversity Commission", CommissionMembersTotal = 9, OrganizationID = 1 });
            mb.Entity<Commission>().HasData(new Commission { CommissionID = 2, CommissionName = "Beautification Commission", CommissionDescription = "aesthetic improvements, beautify the City", CommissionMembersTotal = 11, OrganizationID = 1 });
            mb.Entity<Commission>().HasData(new Commission { CommissionID = 3, CommissionName = "Board of Ethics", CommissionDescription = "guides conduct of City officials", OrganizationID = 1 });
            mb.Entity<Commission>().HasData(new Commission { CommissionID = 4, CommissionName = "Board of Review", CommissionDescription = "assessment appeals", CommissionMembersTotal = 5, OrganizationID = 1 }); //Two Alternates (also, City Council reduced this to 1 board of 3, instead of 2, in 2019)
            mb.Entity<Commission>().HasData(new Commission { CommissionID = 5, CommissionName = "Civil Service Commission", CommissionDescription = "system of personnel administration", CommissionMembersTotal = 3, OrganizationID = 1 });
            mb.Entity<Commission>().HasData(new Commission
            {
                CommissionID = 6,
                CommissionName = "Construction Board of Appeals",
                CommissionDescription = "hear appeals on refusal to grant an application for a permit or a modification to the provisions of this Code covering the manner of construction or" +
                "materials to be used in the erection, alteration or repair of a building or structure or otherwise makes a decision pursuant or related to the Code",
                OrganizationID = 1
            });
            mb.Entity<Commission>().HasData(new Commission { CommissionID = 7, CommissionName = "Downtown Development Authority", CommissionDescription = "manages right-of-way improvements in DDA corridor", CommissionMembersTotal = 9, OrganizationID = 1 });
            mb.Entity<Commission>().HasData(new Commission { CommissionID = 8, CommissionName = "Housing Commission", CommissionDescription = "oversees senior citizen housing", CommissionMembersTotal = 5, OrganizationID = 1 });
            mb.Entity<Commission>().HasData(new Commission { CommissionID = 9, CommissionName = "Library Commission", CommissionDescription = "library services", CommissionMembersTotal = 5, OrganizationID = 1 });
            mb.Entity<Commission>().HasData(new Commission { CommissionID = 10, CommissionName = "Local Officers Compensation Commission", CommissionDescription = "recommends/sets salaries for elected officials", CommissionMembersTotal = 7, OrganizationID = 1 });
            mb.Entity<Commission>().HasData(new Commission { CommissionID = 11, CommissionName = "Parks Commission", CommissionDescription = "makes recommendations to council relative to park programs, projects or facilities", CommissionMembersTotal = 7, OrganizationID = 1 });
            mb.Entity<Commission>().HasData(new Commission { CommissionID = 12, CommissionName = "Planning Commission", CommissionDescription = "City planning, land use and zoning", CommissionMembersTotal = 7, OrganizationID = 1 });
            mb.Entity<Commission>().HasData(new Commission { CommissionID = 13, CommissionName = "Recreational Authority of Roseville and Eastpointe", CommissionDescription = "recreation services", CommissionMembersTotal = 5, OrganizationID = 1 }); ;
            mb.Entity<Commission>().HasData(new Commission { CommissionID = 14, CommissionName = "Zoning Board of Appeals", CommissionDescription = "grants variances to City Codes", CommissionMembersTotal = 9, OrganizationID = 1 }); //Two Alternates

            mb.Entity<ApplicationQuestionType>().HasData(new ApplicationQuestionType { ApplicationQuestionTypeID = 1, ApplicationQuestionTypeName = "Yes and No" });
            mb.Entity<ApplicationQuestionType>().HasData(new ApplicationQuestionType { ApplicationQuestionTypeID = 2, ApplicationQuestionTypeName = "Text" });
            mb.Entity<ApplicationQuestionType>().HasData(new ApplicationQuestionType { ApplicationQuestionTypeID = 3, ApplicationQuestionTypeName = "Text (extended)" });
            mb.Entity<ApplicationQuestionType>().HasData(new ApplicationQuestionType { ApplicationQuestionTypeID = 4, ApplicationQuestionTypeName = "Drop-down List of Commissions" });

            //Insert application questions...
            mb.Entity<ApplicationQuestion>().HasData(new ApplicationQuestion
            {
                ApplicationQuestionID = 2,
                ApplicationQuestionText = "Are you a registered voter of the City?",
                ApplicationQuestionTypeID = 1
            });
            mb.Entity<ApplicationQuestion>().HasData(new ApplicationQuestion
            {
                ApplicationQuestionID = 3,
                ApplicationQuestionText = "Have you previously served on a Board or Commission?",
                ApplicationQuestionTypeID = 1
            });
            mb.Entity<ApplicationQuestion>().HasData(new ApplicationQuestion
            {
                ApplicationQuestionID = 4,
                ApplicationQuestionText = "What Boards or Commissions have you previously served on?",
                ApplicationQuestionTypeID = 4
            });
            mb.Entity<ApplicationQuestion>().HasData(new ApplicationQuestion
            {
                ApplicationQuestionID = 5,
                ApplicationQuestionText = "Have you ever been convicted of a crime?",
                ApplicationQuestionTypeID = 1
            });
            mb.Entity<ApplicationQuestion>().HasData(new ApplicationQuestion
            {
                ApplicationQuestionID = 6,
                ApplicationQuestionText = "If yes, please explain the nature of the offense:",
                ApplicationQuestionTypeID = 2
            });
            mb.Entity<ApplicationQuestion>().HasData(new ApplicationQuestion
            {
                ApplicationQuestionID = 7,
                ApplicationQuestionText = "Please list any community involvement, employment, education or other expertise that pertains to the Board or Commission that you are applying for:",
                ApplicationQuestionTypeID = 3
            });

            mb.Entity<Setting>().HasData(new Setting { SettingID = 1, SettingName = "ArchiveInMonths", SettingValue = "24" });
        }

        //Reference the other tables for the database...
        public virtual DbSet<Application> Applications { get; set; }
        public virtual DbSet<ApplicationQuestion> ApplicationQuestions { get; set; }
        public virtual DbSet<Commission> Commissions { get; set; }
        public virtual DbSet<CommissionApplication> CommissionApplications { get; set; }
        public virtual DbSet<CommissionMember> CommissionMembers { get; set; }
        public virtual DbSet<Organization> Organizations { get; set; }
        public virtual DbSet<QuestionAnswer> QuestionAnswers { get; set; }

        //Addresses
        public virtual DbSet<Address> Addresses { get; set; }
        public virtual DbSet<Municipality> Municipalities { get; set; }
        public virtual DbSet<State> States { get; set; }

        //Users and Settings
        public virtual DbSet<Setting> Settings { get; set; }
        public virtual DbSet<ApplicationExtended> ApplicationsExtended { get; set; }
    }
}
