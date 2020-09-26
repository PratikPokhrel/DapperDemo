using DapperDemo.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DapperDemo.Services
{
    public interface IStudentService
    {
        public Task<StudentVm> GetByIdAsync(Guid Id);
        public Task<List<StudentVm>> GetStudentListDapperAsync();
        public Task<List<StudentVm>> GetStudentListEFCoreAsync();

    }
}
