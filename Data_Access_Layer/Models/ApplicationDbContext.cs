using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Access_Layer.Repository.Entities
{
    
    public class ApplicationDbContext:IdentityDbContext<ApplicationUser>
    {
        

        public ApplicationDbContext()
        {

        }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options)
        {
                
        }
       
        public DbSet<Student> Students { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<Question> Questions{ get; set; }
        public DbSet<ExamResult> ExamResults{ get; set; }
        public DbSet<Exam> Exams { get; set; }
        public DbSet<Choice> Choices { get; set; }
        public DbSet<ExamConfigration> ExamConfigrations{ get; set; }
        public DbSet<StudentSubject> StudentSubjects { get; set; }
        public DbSet<ExamQuestion> ExamQuestions { get; set; }
       
    }

    
}
