using Dapper;
using DapperDemo.ViewModels;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace DapperDemo.Services
{
    public class StudentService : IStudentService
    {
        private readonly IConfiguration _config;
        protected readonly ApplicationContext _context;

        public StudentService(IConfiguration config, ApplicationContext context)
        {
            _config = config;
            _context = context;
        }
      

        public async Task<List<StudentVm>> GetStudentListDapperAsync()
        {
            string strSQL = @"SELECT S.Id,S.FirstName,S.LastName,S.Email,
                                       C.Id,C.Name,
                                       SC.Id,SC.StudentId,SC.CourseId,
                                       CO.Id,CO.Name 
                                       FROM Student S
                                     LEFT JOIN Class C ON S.ClassId=C.Id
                                     LEFT JOIN StudentCourse SC ON S.Id=SC.StudentId
                                     LEFT JOIN Course CO ON SC.CourseId=CO.Id";


            List<StudentVm> students  = null;
            using (IDbConnection db = new SqlConnection(_config.GetConnectionString("DatabaseConnection")))
            {
                if (db.State == ConnectionState.Closed)
                    db.Open();

                try
                {

                    IEnumerable<StudentVm> returnlist = await db.QueryAsync<StudentVm, ClassVm, StudentCourserVm, CourserVm, StudentVm>(strSQL, (students, classs, studentCourse, course) => {
                        if (classs != null) students.Classs = classs;
                        if (studentCourse != null)
                        {
                            studentCourse.Course = course;
                            students.StudentCourse.Add(studentCourse);
                        }
                        return students;
                    },splitOn:"Id,Id,Id,Id");

                    students = returnlist.GroupBy(e => e.Id).Select(e =>
                    {
                        StudentVm student = e.First();
                        student.StudentCourse = e.SelectMany(f => f.StudentCourse).ToList();
                        return student;
                    }).ToList();

                    return students;

                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    if (db.State == ConnectionState.Open)
                        db.Close();
                }
            }
        }


        public async Task<StudentVm> GetByIdAsync(Guid Id)
        {
            string strSQL = @"SELECT S.Id,S.FirstName,S.LastName,S.Email,
                                       C.Id,C.Name,
                                       SC.Id,SC.StudentId,SC.CourseId,
                                       CO.Id,CO.Name 
                                       FROM Student S
                                     LEFT JOIN Class C ON S.ClassId=C.Id
                                     LEFT JOIN StudentCourse SC ON S.Id=SC.StudentId
                                     LEFT JOIN Course CO ON SC.CourseId=CO.Id
                                     Where S.Id=@id";


            StudentVm student = null;
            using (IDbConnection db = new SqlConnection(_config.GetConnectionString("DatabaseConnection")))
            {
                if (db.State == ConnectionState.Closed)
                    db.Open();
                try
                {

                    IEnumerable<StudentVm> returnlist = await db.QueryAsync<StudentVm, ClassVm, StudentCourserVm, CourserVm, StudentVm>(strSQL, (students, classs, studentCourse, course) => {
                        if (classs != null) students.Classs = classs;
                        if (studentCourse != null)
                        {
                            studentCourse.Course = course;
                            students.StudentCourse.Add(studentCourse);
                        }
                        return students;
                    },new { id=Id}, splitOn: "Id,Id,Id,Id");

                    student = returnlist.GroupBy(e => e.Id).Select(e =>
                    {
                        StudentVm student = e.First();
                        student.StudentCourse = e.SelectMany(f => f.StudentCourse).ToList();
                        return student;
                    }).FirstOrDefault();
                    return student;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    if (db.State == ConnectionState.Open)
                        db.Close();
                }
            }
        }

        public async Task<List<StudentVm>> GetStudentListEFCoreAsync()
        {
            List<StudentVm> students = await _context.Student.Include(e => e.Classs)
                                                           .Include(e => e.StudentCourse).ThenInclude(e => e.Course)
                                                            .Select(e => new StudentVm
                                                            {
                                                                    Id=e.Id,
                                                                    FirstName=e.FirstName,
                                                                    LastName=e.LastName,
                                                                    Email=e.Email,
                                                                    
                                                                    Classs=e.Classs==null?null:new ClassVm
                                                                    {
                                                                        Id=e.Classs.Id,
                                                                        Name=e.Classs.Name
                                                                    }
                                                                    ,
                                                                    StudentCourse=e.StudentCourse.Select(e=>new StudentCourserVm
                                                                    {
                                                                        Course=e.Course==null?null:new CourserVm
                                                                        {
                                                                            Id=e.Course.Id,
                                                                            Name=e.Course.Name
                                                                        }
                                                                    }).ToList()
                                                            }).ToListAsync();

            return students;
        }
    }
}
