using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeAI.Application.Services.Abstractions
{
    public interface ILeaveService
    {
        Task<int> GetLeaveBalanceAsync(int employeeId);
    }
}
