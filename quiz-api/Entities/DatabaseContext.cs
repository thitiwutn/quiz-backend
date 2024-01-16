using Microsoft.EntityFrameworkCore;
using quiz_api.Entities.Models;
using quiz_api.Entities.Models.Base;

namespace quiz_api.Entities;

public sealed class DatabaseContext : DbContext
{
    private readonly IConfiguration _configuration;

    public DbSet<Group> Groups { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<Question> Questions { get; set; }
    public DbSet<Choice> Choices { get; set; }
    public DbSet<Quiz> Quizzes { get; set; }
    public DbSet<Answer> Answers { get; set; }

    public DatabaseContext(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(_configuration.GetConnectionString("defaultConnection")!);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Answer>().HasKey(x => new {x.QuizId, x.QuestionId, x.ChoiceId});
        modelBuilder.Entity<Group>()
            .HasData(
                new Group()
                {
                    Id = 1, Name = "สัตว์น้ำ", CreateDate = new DateTime(2024, 01, 16),
                    UpdateDate = new DateTime(2024, 01, 16), Inactive = false
                },
                new Group()
                {
                    Id = 2, Name = "สัตว์บก", CreateDate = new DateTime(2024, 01, 16),
                    UpdateDate = new DateTime(2024, 01, 16), Inactive = false
                },
                new Group()
                {
                    Id = 3, Name = "สัตว์มีปีก", CreateDate = new DateTime(2024, 01, 16),
                    UpdateDate = new DateTime(2024, 01, 16), Inactive = false
                }
            );
        modelBuilder.Entity<Question>()
            .HasData(
                new Question()
                {
                    Id = 1, QuestionText = "สัตว์น้ำชนิดใดที่มีขนาดใหญ่ที่สุดในโลก", GroupId = 1, order = 1,
                    Inactive = false,
                    CreateDate = new DateTime(2024, 01, 16), UpdateDate = new DateTime(2024, 01, 16)
                },
                new Question()
                {
                    Id = 2, QuestionText = "สัตว์น้ำชนิดใดที่อาศัยอยู่ในน้ำจืด", GroupId = 1, order = 2,
                    Inactive = false,
                    CreateDate = new DateTime(2024, 01, 16), UpdateDate = new DateTime(2024, 01, 16)
                },
                new Question()
                {
                    Id = 3, QuestionText = "สัตว์น้ำชนิดใดที่กินเนื้อเป็นอาหาร", GroupId = 1, order = 3,
                    Inactive = false,
                    CreateDate = new DateTime(2024, 01, 16), UpdateDate = new DateTime(2024, 01, 16)
                },
                new Question()
                {
                    Id = 4, QuestionText = "สัตว์น้ำชนิดใดที่อาศัยอยู่ในทะเลลึก", GroupId = 1, order = 4,
                    Inactive = false,
                    CreateDate = new DateTime(2024, 01, 16), UpdateDate = new DateTime(2024, 01, 16)
                },
                new Question()
                {
                    Id = 5, QuestionText = "สัตว์น้ำชนิดใดที่กินปลาวาฬเป็นอาหาร", GroupId = 1, order = 5,
                    Inactive = false,
                    CreateDate = new DateTime(2024, 01, 16), UpdateDate = new DateTime(2024, 01, 16)
                },
                new Question()
                {
                    Id = 6, QuestionText = "สัตว์บกชนิดใดที่มีความสามารถในการบินได้", GroupId = 2, order = 1,
                    Inactive = false,
                    CreateDate = new DateTime(2024, 01, 16), UpdateDate = new DateTime(2024, 01, 16)
                },
                new Question()
                {
                    Id = 7, QuestionText = "สัตว์บกชนิดใดที่ใหญ่ที่สุดในโลก", GroupId = 2, order = 2,
                    Inactive = false,
                    CreateDate = new DateTime(2024, 01, 16), UpdateDate = new DateTime(2024, 01, 16)
                },
                new Question()
                {
                    Id = 8, QuestionText = "สัตว์บกชนิดใดที่กินพืชเป็นอาหาร", GroupId = 2, order = 3, Inactive = false,
                    CreateDate = new DateTime(2024, 01, 16), UpdateDate = new DateTime(2024, 01, 16)
                },
                new Question()
                {
                    Id = 9, QuestionText = "สัตว์บกชนิดใดที่ออกลูกเป็นตัว", GroupId = 2, order = 4,
                    Inactive = false,
                    CreateDate = new DateTime(2024, 01, 16), UpdateDate = new DateTime(2024, 01, 16)
                },
                new Question()
                {
                    Id = 10, QuestionText = "สัตว์บกชนิดใดที่อาศัยอยู่ในทะเลทราย", GroupId = 2, order = 5,
                    Inactive = false,
                    CreateDate = new DateTime(2024, 01, 16), UpdateDate = new DateTime(2024, 01, 16)
                },
                new Question()
                {
                    Id = 11, QuestionText = "สัตว์ปีกที่บินไม่ได้คืออะไร?", GroupId = 3, order = 1,
                    Inactive = false,
                    CreateDate = new DateTime(2024, 01, 16), UpdateDate = new DateTime(2024, 01, 16)
                },
                new Question()
                {
                    Id = 12, QuestionText = "สัตว์ปีกที่ออกลูกเป็นไข่คืออะไร?", GroupId = 3, order = 2,
                    Inactive = false,
                    CreateDate = new DateTime(2024, 01, 16), UpdateDate = new DateTime(2024, 01, 16)
                },
                new Question()
                {
                    Id = 13, QuestionText = "สัตว์ปีกที่อาศัยอยู่ในน้ำคืออะไร?", GroupId = 3, order = 3,
                    Inactive = false,
                    CreateDate = new DateTime(2024, 01, 16), UpdateDate = new DateTime(2024, 01, 16)
                },
                new Question()
                {
                    Id = 14, QuestionText = "สัตว์ปีกที่กินพืชเป็นอาหารคืออะไร?", GroupId = 3, order = 4,
                    Inactive = false,
                    CreateDate = new DateTime(2024, 01, 16), UpdateDate = new DateTime(2024, 01, 16)
                },
                new Question()
                {
                    Id = 15, QuestionText = "สัตว์ปีกที่มีความสำคัญต่อมนุษย์คืออะไร?", GroupId = 3, order = 5,
                    Inactive = false,
                    CreateDate = new DateTime(2024, 01, 16), UpdateDate = new DateTime(2024, 01, 16)
                }
            );

        modelBuilder.Entity<Choice>()
            .HasData(

                #region group1 สัตว์น้ำ

                new Choice()
                {
                    Id = 1, ChoiceText = "วาฬสีน้ำเงิน", QuestionId = 1, Inactive = false, point = 5,
                    CreateDate = new DateTime(2024, 01, 16), UpdateDate = new DateTime(2024, 01, 16)
                },
                new Choice()
                {
                    Id = 2, ChoiceText = "ปลาวาฬสเปิร์ม", QuestionId = 1, Inactive = false, point = 4,
                    CreateDate = new DateTime(2024, 01, 16), UpdateDate = new DateTime(2024, 01, 16)
                },
                new Choice()
                {
                    Id = 3, ChoiceText = "ปลาฉลามวาฬ", QuestionId = 1, Inactive = false, point = 3,
                    CreateDate = new DateTime(2024, 01, 16), UpdateDate = new DateTime(2024, 01, 16)
                },
                new Choice()
                {
                    Id = 4, ChoiceText = "ปลาฉลามขาว", QuestionId = 1, Inactive = false, point = 2,
                    CreateDate = new DateTime(2024, 01, 16), UpdateDate = new DateTime(2024, 01, 16)
                },
                new Choice()
                {
                    Id = 5, ChoiceText = "ปลาดาว", QuestionId = 2, Inactive = false, point = 5,
                    CreateDate = new DateTime(2024, 01, 16), UpdateDate = new DateTime(2024, 01, 16)
                },
                new Choice()
                {
                    Id = 6, ChoiceText = "ปลาทอง", QuestionId = 2, Inactive = false, point = 4,
                    CreateDate = new DateTime(2024, 01, 16), UpdateDate = new DateTime(2024, 01, 16)
                },
                new Choice()
                {
                    Id = 7, ChoiceText = "กุ้งก้ามกราม", QuestionId = 2, Inactive = false, point = 3,
                    CreateDate = new DateTime(2024, 01, 16), UpdateDate = new DateTime(2024, 01, 16)
                },
                new Choice()
                {
                    Id = 8, ChoiceText = "เต่า", QuestionId = 2, Inactive = false, point = 2,
                    CreateDate = new DateTime(2024, 01, 16), UpdateDate = new DateTime(2024, 01, 16)
                },
                new Choice()
                {
                    Id = 9, ChoiceText = "ปลาฉลาม", QuestionId = 3, Inactive = false, point = 5,
                    CreateDate = new DateTime(2024, 01, 16), UpdateDate = new DateTime(2024, 01, 16)
                },
                new Choice()
                {
                    Id = 10, ChoiceText = "ปลาโลมา", QuestionId = 3, Inactive = false, point = 4,
                    CreateDate = new DateTime(2024, 01, 16), UpdateDate = new DateTime(2024, 01, 16)
                },
                new Choice()
                {
                    Id = 11, ChoiceText = "ปลาหมึกยักษ์", QuestionId = 3, Inactive = false, point = 3,
                    CreateDate = new DateTime(2024, 01, 16), UpdateDate = new DateTime(2024, 01, 16)
                },
                new Choice()
                {
                    Id = 12, ChoiceText = "ปลากระเบน", QuestionId = 3, Inactive = false, point = 2,
                    CreateDate = new DateTime(2024, 01, 16), UpdateDate = new DateTime(2024, 01, 16)
                },
                new Choice()
                {
                    Id = 13, ChoiceText = "ปลาฉลาม", QuestionId = 4, Inactive = false, point = 4,
                    CreateDate = new DateTime(2024, 01, 16), UpdateDate = new DateTime(2024, 01, 16)
                },
                new Choice()
                {
                    Id = 14, ChoiceText = "ปลาโลมา", QuestionId = 4, Inactive = false, point = 2,
                    CreateDate = new DateTime(2024, 01, 16), UpdateDate = new DateTime(2024, 01, 16)
                },
                new Choice()
                {
                    Id = 15, ChoiceText = "ปลาหมึกยักษ์", QuestionId = 4, Inactive = false, point = 5,
                    CreateDate = new DateTime(2024, 01, 16), UpdateDate = new DateTime(2024, 01, 16)
                },
                new Choice()
                {
                    Id = 16, ChoiceText = "วาฬสเปิร์ม", QuestionId = 4, Inactive = false, point = 3,
                    CreateDate = new DateTime(2024, 01, 16), UpdateDate = new DateTime(2024, 01, 16)
                },
                new Choice()
                {
                    Id = 17, ChoiceText = "ปลาฉลามวาฬ", QuestionId = 5, Inactive = false, point = 5,
                    CreateDate = new DateTime(2024, 01, 16), UpdateDate = new DateTime(2024, 01, 16)
                },
                new Choice()
                {
                    Id = 18, ChoiceText = "ปลาโลมา", QuestionId = 5, Inactive = false, point = 4,
                    CreateDate = new DateTime(2024, 01, 16), UpdateDate = new DateTime(2024, 01, 16)
                },
                new Choice()
                {
                    Id = 19, ChoiceText = "ปลาหมึกยักษ์", QuestionId = 5, Inactive = false, point = 2,
                    CreateDate = new DateTime(2024, 01, 16), UpdateDate = new DateTime(2024, 01, 16)
                },
                new Choice()
                {
                    Id = 20, ChoiceText = "แมงมุมน้ำ", QuestionId = 5, Inactive = false, point = 0,
                    CreateDate = new DateTime(2024, 01, 16), UpdateDate = new DateTime(2024, 01, 16)
                },

                #endregion

                #region group2 สัตว์บก

                new Choice()
                {
                    Id = 21, ChoiceText = "นก", QuestionId = 6, Inactive = false, point = 5,
                    CreateDate = new DateTime(2024, 01, 16), UpdateDate = new DateTime(2024, 01, 16)
                },
                new Choice()
                {
                    Id = 22, ChoiceText = "ค้างคาว", QuestionId = 6, Inactive = false, point = 4,
                    CreateDate = new DateTime(2024, 01, 16), UpdateDate = new DateTime(2024, 01, 16)
                },
                new Choice()
                {
                    Id = 23, ChoiceText = "กบ", QuestionId = 6, Inactive = false, point = 2,
                    CreateDate = new DateTime(2024, 01, 16), UpdateDate = new DateTime(2024, 01, 16)
                },
                new Choice()
                {
                    Id = 24, ChoiceText = "สุนัข", QuestionId = 6, Inactive = false, point = 0,
                    CreateDate = new DateTime(2024, 01, 16), UpdateDate = new DateTime(2024, 01, 16)
                },
                new Choice()
                {
                    Id = 25, ChoiceText = "ช้างแอฟริกัน", QuestionId = 7, Inactive = false, point = 5,
                    CreateDate = new DateTime(2024, 01, 17), UpdateDate = new DateTime(2024, 01, 17)
                },
                new Choice()
                {
                    Id = 26, ChoiceText = "วัวกระทิง", QuestionId = 7, Inactive = false, point = 4,
                    CreateDate = new DateTime(2024, 01, 17), UpdateDate = new DateTime(2024, 01, 17)
                },
                new Choice()
                {
                    Id = 27, ChoiceText = "สิงโต", QuestionId = 7, Inactive = false, point = 3,
                    CreateDate = new DateTime(2024, 01, 17), UpdateDate = new DateTime(2024, 01, 17)
                },
                new Choice()
                {
                    Id = 28, ChoiceText = "ลิงอุรังอุตัง", QuestionId = 7, Inactive = false, point = 2,
                    CreateDate = new DateTime(2024, 01, 17), UpdateDate = new DateTime(2024, 01, 17)
                },
                new Choice()
                {
                    Id = 29, ChoiceText = "วัว", QuestionId = 8, Inactive = false, point = 5,
                    CreateDate = new DateTime(2024, 01, 17), UpdateDate = new DateTime(2024, 01, 17)
                },
                new Choice()
                {
                    Id = 30, ChoiceText = "ช้าง", QuestionId = 8, Inactive = false, point = 4,
                    CreateDate = new DateTime(2024, 01, 17), UpdateDate = new DateTime(2024, 01, 17)
                },
                new Choice()
                {
                    Id = 31, ChoiceText = "ม้า", QuestionId = 8, Inactive = false, point = 3,
                    CreateDate = new DateTime(2024, 01, 17), UpdateDate = new DateTime(2024, 01, 17)
                },
                new Choice()
                {
                    Id = 32, ChoiceText = "แมว", QuestionId = 8, Inactive = false, point = 2,
                    CreateDate = new DateTime(2024, 01, 17), UpdateDate = new DateTime(2024, 01, 17)
                },
                new Choice()
                {
                    Id = 33, ChoiceText = "ช้าง", QuestionId = 9, Inactive = false, point = 5,
                    CreateDate = new DateTime(2024, 01, 17), UpdateDate = new DateTime(2024, 01, 17)
                },
                new Choice()
                {
                    Id = 34, ChoiceText = "วัว", QuestionId = 9, Inactive = false, point = 4,
                    CreateDate = new DateTime(2024, 01, 17), UpdateDate = new DateTime(2024, 01, 17)
                },
                new Choice()
                {
                    Id = 35, ChoiceText = "ม้า", QuestionId = 9, Inactive = false, point = 3,
                    CreateDate = new DateTime(2024, 01, 17), UpdateDate = new DateTime(2024, 01, 17)
                },
                new Choice()
                {
                    Id = 36, ChoiceText = "แมว", QuestionId = 9, Inactive = false, point = 2,
                    CreateDate = new DateTime(2024, 01, 17), UpdateDate = new DateTime(2024, 01, 17)
                },
                new Choice()
                {
                    Id = 37, ChoiceText = "อูฐ", QuestionId = 10, Inactive = false, point = 5,
                    CreateDate = new DateTime(2024, 01, 17), UpdateDate = new DateTime(2024, 01, 17)
                },
                new Choice()
                {
                    Id = 38, ChoiceText = "ยีราฟ", QuestionId = 10, Inactive = false, point = 4,
                    CreateDate = new DateTime(2024, 01, 17), UpdateDate = new DateTime(2024, 01, 17)
                },
                new Choice()
                {
                    Id = 39, ChoiceText = "ม้าลาย", QuestionId = 10, Inactive = false, point = 3,
                    CreateDate = new DateTime(2024, 01, 17), UpdateDate = new DateTime(2024, 01, 17)
                },
                new Choice()
                {
                    Id = 40, ChoiceText = "สิงโต", QuestionId = 10, Inactive = false, point = 2,
                    CreateDate = new DateTime(2024, 01, 17), UpdateDate = new DateTime(2024, 01, 17)
                },

                #endregion

                #region group3 สัตว์ปีก

                new Choice()
                {
                    Id = 41, ChoiceText = "นกกระจอกเทศ", QuestionId = 11, Inactive = false, point = 5,
                    CreateDate = new DateTime(2024, 01, 17), UpdateDate = new DateTime(2024, 01, 17)
                },
                new Choice()
                {
                    Id = 42, ChoiceText = "นกแก้ว", QuestionId = 11, Inactive = false, point = 0,
                    CreateDate = new DateTime(2024, 01, 17), UpdateDate = new DateTime(2024, 01, 17)
                },
                new Choice()
                {
                    Id = 43, ChoiceText = "นกเป็ด", QuestionId = 11, Inactive = false, point = 2,
                    CreateDate = new DateTime(2024, 01, 17), UpdateDate = new DateTime(2024, 01, 17)
                },
                new Choice()
                {
                    Id = 44, ChoiceText = "นกยูง", QuestionId = 11, Inactive = false, point = 1,
                    CreateDate = new DateTime(2024, 01, 17), UpdateDate = new DateTime(2024, 01, 17)
                },
                new Choice()
                {
                    Id = 45, ChoiceText = "นก", QuestionId = 12, Inactive = false, point = 5,
                    CreateDate = new DateTime(2024, 01, 17), UpdateDate = new DateTime(2024, 01, 17)
                },
                new Choice()
                {
                    Id = 46, ChoiceText = "ค้างคาว", QuestionId = 12, Inactive = false, point = 0,
                    CreateDate = new DateTime(2024, 01, 17), UpdateDate = new DateTime(2024, 01, 17)
                },
                new Choice()
                {
                    Id = 47, ChoiceText = "เต่า", QuestionId = 12, Inactive = false, point = 2,
                    CreateDate = new DateTime(2024, 01, 17), UpdateDate = new DateTime(2024, 01, 17)
                },
                new Choice()
                {
                    Id = 48, ChoiceText = "ปลา", QuestionId = 12, Inactive = false, point = 1,
                    CreateDate = new DateTime(2024, 01, 17), UpdateDate = new DateTime(2024, 01, 17)
                },
                new Choice()
                {
                    Id = 49, ChoiceText = "นกเป็ดน้ำ", QuestionId = 13, Inactive = false, point = 5,
                    CreateDate = new DateTime(2024, 01, 17), UpdateDate = new DateTime(2024, 01, 17)
                },
                new Choice()
                {
                    Id = 50, ChoiceText = "นกกระจอกเทศ", QuestionId = 13, Inactive = false, point = 0,
                    CreateDate = new DateTime(2024, 01, 17), UpdateDate = new DateTime(2024, 01, 17)
                },
                new Choice()
                {
                    Id = 51, ChoiceText = "นกแก้ว", QuestionId = 13, Inactive = false, point = 2,
                    CreateDate = new DateTime(2024, 01, 17), UpdateDate = new DateTime(2024, 01, 17)
                },
                new Choice()
                {
                    Id = 52, ChoiceText = "นกยูง", QuestionId = 13, Inactive = false, point = 1,
                    CreateDate = new DateTime(2024, 01, 17), UpdateDate = new DateTime(2024, 01, 17)
                },
                new Choice()
                {
                    Id = 53, ChoiceText = "นกกระจอกเทศ", QuestionId = 14, Inactive = false, point = 5,
                    CreateDate = new DateTime(2024, 01, 17), UpdateDate = new DateTime(2024, 01, 17)
                },
                new Choice()
                {
                    Id = 54, ChoiceText = "นกแก้ว", QuestionId = 14, Inactive = false, point = 3,
                    CreateDate = new DateTime(2024, 01, 17), UpdateDate = new DateTime(2024, 01, 17)
                },
                new Choice()
                {
                    Id = 55, ChoiceText = "นกเป็ด", QuestionId = 14, Inactive = false, point = 2,
                    CreateDate = new DateTime(2024, 01, 17), UpdateDate = new DateTime(2024, 01, 17)
                },
                new Choice()
                {
                    Id = 56, ChoiceText = "นกยูง", QuestionId = 14, Inactive = false, point = 1,
                    CreateDate = new DateTime(2024, 01, 17), UpdateDate = new DateTime(2024, 01, 17)
                },
                new Choice()
                {
                    Id = 57, ChoiceText = "ไก่", QuestionId = 15, Inactive = false, point = 5,
                    CreateDate = new DateTime(2024, 01, 17), UpdateDate = new DateTime(2024, 01, 17)
                },
                new Choice()
                {
                    Id = 58, ChoiceText = "นกกระจอกเทศ", QuestionId = 15, Inactive = false, point = 4,
                    CreateDate = new DateTime(2024, 01, 17), UpdateDate = new DateTime(2024, 01, 17)
                },
                new Choice()
                {
                    Id = 59, ChoiceText = "นกแก้ว", QuestionId = 15, Inactive = false, point = 3,
                    CreateDate = new DateTime(2024, 01, 17), UpdateDate = new DateTime(2024, 01, 17)
                },
                new Choice()
                {
                    Id = 60, ChoiceText = "นกยูง", QuestionId = 15, Inactive = false, point = 2,
                    CreateDate = new DateTime(2024, 01, 17), UpdateDate = new DateTime(2024, 01, 17)
                }

                #endregion

            );
    }

    public override int SaveChanges()
    {
        var datetimeNow = DateTime.Now;
        var entries = ChangeTracker
            .Entries()
            .Where(e => e.Entity is Tracking && (
                e.State == EntityState.Added
                || e.State == EntityState.Modified));

        foreach (var entityEntry in entries)
        {
            switch (entityEntry.State)
            {
                case EntityState.Added:
                    ((Tracking) entityEntry.Entity).CreateDate = datetimeNow;
                    ((Tracking) entityEntry.Entity).UpdateDate = datetimeNow;
                    break;
                case EntityState.Modified:
                    ((Tracking) entityEntry.Entity).UpdateDate = datetimeNow;
                    break;
            }
        }

        return base.SaveChanges();
    }
}