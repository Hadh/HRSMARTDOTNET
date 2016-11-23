namespace HRSmart.data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class added_photo_to_skill : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "mysqlpi.address",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        localisation = c.String(maxLength: 255, storeType: "nvarchar"),
                        x = c.Double(nullable: false),
                        y = c.Double(nullable: false),
                        buisness_id = c.Int(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("mysqlpi.buisness", t => t.buisness_id)
                .Index(t => t.buisness_id);
            
            CreateTable(
                "mysqlpi.buisness",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        name = c.String(maxLength: 255, storeType: "nvarchar"),
                        valid = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "mysqlpi.joboffer",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        active = c.Boolean(nullable: false),
                        description = c.String(maxLength: 255, storeType: "nvarchar"),
                        salary = c.Int(nullable: false),
                        creationDate = c.DateTime(nullable: false, precision: 0),
                        title = c.String(maxLength: 255, storeType: "nvarchar"),
                        buisness_id = c.Int(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("mysqlpi.buisness", t => t.buisness_id)
                .Index(t => t.buisness_id);
            
            CreateTable(
                "mysqlpi.jobskill",
                c => new
                    {
                        skill_id = c.Int(nullable: false),
                        jobOffer_id = c.Int(nullable: false),
                        hasQuiz = c.Boolean(nullable: false),
                        level = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.skill_id, t.jobOffer_id })
                .ForeignKey("mysqlpi.joboffer", t => t.jobOffer_id, cascadeDelete: true)
                .ForeignKey("mysqlpi.skill", t => t.skill_id, cascadeDelete: true)
                .Index(t => t.skill_id)
                .Index(t => t.jobOffer_id);
            
            CreateTable(
                "mysqlpi.skill",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        name = c.String(maxLength: 255, storeType: "nvarchar"),
                        photo = c.String(maxLength: 255, storeType: "nvarchar"),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "mysqlpi.certificat",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        name = c.String(maxLength: 255, storeType: "nvarchar"),
                        skill_id = c.Int(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("mysqlpi.skill", t => t.skill_id)
                .Index(t => t.skill_id);
            
            CreateTable(
                "mysqlpi.userskill",
                c => new
                    {
                        user_id = c.Int(nullable: false),
                        skill_id = c.Int(nullable: false),
                        level = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.user_id, t.skill_id })
                .ForeignKey("mysqlpi.skill", t => t.skill_id, cascadeDelete: true)
                .ForeignKey("mysqlpi.user", t => t.user_id, cascadeDelete: true)
                .Index(t => t.user_id)
                .Index(t => t.skill_id);
            
            CreateTable(
                "mysqlpi.user",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        adresse = c.String(maxLength: 255, storeType: "nvarchar"),
                        age = c.Int(nullable: false),
                        firstName = c.String(maxLength: 255, storeType: "nvarchar"),
                        lastName = c.String(maxLength: 255, storeType: "nvarchar"),
                        login = c.String(maxLength: 255, storeType: "nvarchar"),
                        numTel = c.String(maxLength: 255, storeType: "nvarchar"),
                        password = c.String(unicode: false),
                        facebook = c.String(maxLength: 255, storeType: "nvarchar"),
                        twitter = c.String(maxLength: 255, storeType: "nvarchar"),
                        skype = c.String(maxLength: 255, storeType: "nvarchar"),
                        sexe = c.String(maxLength: 255, storeType: "nvarchar"),
                        dateInscription = c.DateTime(nullable: false, precision: 0),
                        active = c.Boolean(nullable: false),
                        linkedin = c.String(maxLength: 255, storeType: "nvarchar"),
                        picture = c.String(maxLength: 255, storeType: "nvarchar"),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "mysqlpi.notification",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        notificationText = c.String(maxLength: 255, storeType: "nvarchar"),
                        user_id = c.Int(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("mysqlpi.user", t => t.user_id)
                .Index(t => t.user_id);
            
            CreateTable(
                "mysqlpi.postulation",
                c => new
                    {
                        idPostulation = c.Int(nullable: false, identity: true),
                        datePostulation = c.DateTime(precision: 0),
                        postulant_id = c.Int(),
                        reward_jobOffer_id = c.Int(),
                        reward_stage_id = c.Int(),
                    })
                .PrimaryKey(t => t.idPostulation)
                .ForeignKey("mysqlpi.rewards", t => new { t.reward_jobOffer_id, t.reward_stage_id })
                .ForeignKey("mysqlpi.user", t => t.postulant_id)
                .Index(t => t.postulant_id)
                .Index(t => new { t.reward_jobOffer_id, t.reward_stage_id });
            
            CreateTable(
                "mysqlpi.assessment",
                c => new
                    {
                        postulation_id = c.Int(nullable: false),
                        quiz_id = c.Int(nullable: false),
                        result = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.postulation_id, t.quiz_id })
                .ForeignKey("mysqlpi.postulation", t => t.postulation_id, cascadeDelete: true)
                .ForeignKey("mysqlpi.quiz", t => t.quiz_id, cascadeDelete: true)
                .Index(t => t.postulation_id)
                .Index(t => t.quiz_id);
            
            CreateTable(
                "mysqlpi.quiz",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        description = c.String(maxLength: 255, storeType: "nvarchar"),
                        duration = c.Int(nullable: false),
                        result = c.Single(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "mysqlpi.question",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        body = c.String(maxLength: 255, storeType: "nvarchar"),
                        skill_id = c.Int(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("mysqlpi.skill", t => t.skill_id)
                .Index(t => t.skill_id);
            
            CreateTable(
                "mysqlpi.choice",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        body = c.String(maxLength: 255, storeType: "nvarchar"),
                        correct = c.Boolean(nullable: false),
                        mark = c.Int(nullable: false),
                        question_id = c.Int(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("mysqlpi.question", t => t.question_id)
                .Index(t => t.question_id);
            
            CreateTable(
                "mysqlpi.rewards",
                c => new
                    {
                        stage_id = c.Int(nullable: false),
                        jobOffer_id = c.Int(nullable: false),
                        value = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.stage_id, t.jobOffer_id })
                .ForeignKey("mysqlpi.joboffer", t => t.jobOffer_id, cascadeDelete: true)
                .ForeignKey("mysqlpi.stage", t => t.stage_id, cascadeDelete: true)
                .Index(t => t.stage_id)
                .Index(t => t.jobOffer_id);
            
            CreateTable(
                "mysqlpi.stage",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        name = c.String(maxLength: 255, storeType: "nvarchar"),
                        buisness_id = c.Int(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("mysqlpi.buisness", t => t.buisness_id)
                .Index(t => t.buisness_id);
            
            CreateTable(
                "mysqlpi.userbuisness",
                c => new
                    {
                        buisness_id = c.Int(nullable: false),
                        user_id = c.Int(nullable: false),
                        hireDate = c.DateTime(precision: 0),
                        role = c.String(maxLength: 255, storeType: "nvarchar"),
                        salary = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.buisness_id, t.user_id })
                .ForeignKey("mysqlpi.buisness", t => t.buisness_id, cascadeDelete: true)
                .ForeignKey("mysqlpi.user", t => t.user_id, cascadeDelete: true)
                .Index(t => t.buisness_id)
                .Index(t => t.user_id);
            
            CreateTable(
                "mysqlpi.userskill_certificat",
                c => new
                    {
                        userSkills_user_id = c.Int(nullable: false),
                        userSkills_skill_id = c.Int(nullable: false),
                        certificats_id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.userSkills_user_id, t.userSkills_skill_id, t.certificats_id })
                .ForeignKey("mysqlpi.userskill", t => new { t.userSkills_user_id, t.userSkills_skill_id }, cascadeDelete: true)
                .ForeignKey("mysqlpi.certificat", t => t.certificats_id, cascadeDelete: true)
                .Index(t => new { t.userSkills_user_id, t.userSkills_skill_id })
                .Index(t => t.certificats_id);
            
            CreateTable(
                "mysqlpi.quiz_question",
                c => new
                    {
                        quizs_id = c.Int(nullable: false),
                        questions_id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.quizs_id, t.questions_id })
                .ForeignKey("mysqlpi.quiz", t => t.quizs_id, cascadeDelete: true)
                .ForeignKey("mysqlpi.question", t => t.questions_id, cascadeDelete: true)
                .Index(t => t.quizs_id)
                .Index(t => t.questions_id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("mysqlpi.address", "buisness_id", "mysqlpi.buisness");
            DropForeignKey("mysqlpi.jobskill", "skill_id", "mysqlpi.skill");
            DropForeignKey("mysqlpi.userskill", "user_id", "mysqlpi.user");
            DropForeignKey("mysqlpi.userbuisness", "user_id", "mysqlpi.user");
            DropForeignKey("mysqlpi.userbuisness", "buisness_id", "mysqlpi.buisness");
            DropForeignKey("mysqlpi.postulation", "postulant_id", "mysqlpi.user");
            DropForeignKey("mysqlpi.postulation", new[] { "reward_jobOffer_id", "reward_stage_id" }, "mysqlpi.rewards");
            DropForeignKey("mysqlpi.rewards", "stage_id", "mysqlpi.stage");
            DropForeignKey("mysqlpi.stage", "buisness_id", "mysqlpi.buisness");
            DropForeignKey("mysqlpi.rewards", "jobOffer_id", "mysqlpi.joboffer");
            DropForeignKey("mysqlpi.assessment", "quiz_id", "mysqlpi.quiz");
            DropForeignKey("mysqlpi.quiz_question", "questions_id", "mysqlpi.question");
            DropForeignKey("mysqlpi.quiz_question", "quizs_id", "mysqlpi.quiz");
            DropForeignKey("mysqlpi.question", "skill_id", "mysqlpi.skill");
            DropForeignKey("mysqlpi.choice", "question_id", "mysqlpi.question");
            DropForeignKey("mysqlpi.assessment", "postulation_id", "mysqlpi.postulation");
            DropForeignKey("mysqlpi.notification", "user_id", "mysqlpi.user");
            DropForeignKey("mysqlpi.userskill", "skill_id", "mysqlpi.skill");
            DropForeignKey("mysqlpi.userskill_certificat", "certificats_id", "mysqlpi.certificat");
            DropForeignKey("mysqlpi.userskill_certificat", new[] { "userSkills_user_id", "userSkills_skill_id" }, "mysqlpi.userskill");
            DropForeignKey("mysqlpi.certificat", "skill_id", "mysqlpi.skill");
            DropForeignKey("mysqlpi.jobskill", "jobOffer_id", "mysqlpi.joboffer");
            DropForeignKey("mysqlpi.joboffer", "buisness_id", "mysqlpi.buisness");
            DropIndex("mysqlpi.quiz_question", new[] { "questions_id" });
            DropIndex("mysqlpi.quiz_question", new[] { "quizs_id" });
            DropIndex("mysqlpi.userskill_certificat", new[] { "certificats_id" });
            DropIndex("mysqlpi.userskill_certificat", new[] { "userSkills_user_id", "userSkills_skill_id" });
            DropIndex("mysqlpi.userbuisness", new[] { "user_id" });
            DropIndex("mysqlpi.userbuisness", new[] { "buisness_id" });
            DropIndex("mysqlpi.stage", new[] { "buisness_id" });
            DropIndex("mysqlpi.rewards", new[] { "jobOffer_id" });
            DropIndex("mysqlpi.rewards", new[] { "stage_id" });
            DropIndex("mysqlpi.choice", new[] { "question_id" });
            DropIndex("mysqlpi.question", new[] { "skill_id" });
            DropIndex("mysqlpi.assessment", new[] { "quiz_id" });
            DropIndex("mysqlpi.assessment", new[] { "postulation_id" });
            DropIndex("mysqlpi.postulation", new[] { "reward_jobOffer_id", "reward_stage_id" });
            DropIndex("mysqlpi.postulation", new[] { "postulant_id" });
            DropIndex("mysqlpi.notification", new[] { "user_id" });
            DropIndex("mysqlpi.userskill", new[] { "skill_id" });
            DropIndex("mysqlpi.userskill", new[] { "user_id" });
            DropIndex("mysqlpi.certificat", new[] { "skill_id" });
            DropIndex("mysqlpi.jobskill", new[] { "jobOffer_id" });
            DropIndex("mysqlpi.jobskill", new[] { "skill_id" });
            DropIndex("mysqlpi.joboffer", new[] { "buisness_id" });
            DropIndex("mysqlpi.address", new[] { "buisness_id" });
            DropTable("mysqlpi.quiz_question");
            DropTable("mysqlpi.userskill_certificat");
            DropTable("mysqlpi.userbuisness");
            DropTable("mysqlpi.stage");
            DropTable("mysqlpi.rewards");
            DropTable("mysqlpi.choice");
            DropTable("mysqlpi.question");
            DropTable("mysqlpi.quiz");
            DropTable("mysqlpi.assessment");
            DropTable("mysqlpi.postulation");
            DropTable("mysqlpi.notification");
            DropTable("mysqlpi.user");
            DropTable("mysqlpi.userskill");
            DropTable("mysqlpi.certificat");
            DropTable("mysqlpi.skill");
            DropTable("mysqlpi.jobskill");
            DropTable("mysqlpi.joboffer");
            DropTable("mysqlpi.buisness");
            DropTable("mysqlpi.address");
        }
    }
}
