using KHENSYS.HRMANAGER.APPLICATION.Interfaces;
using KHENSYS.HRMANAGER.DOMAIN.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace KHENSYS.HRMANAGER.APPLICATION.Features.Command
{
    public class CreatePermissionCommand : IRequest<int>
    {
        public string EmployeeName { get; set; }
        public string EmployeeLastName { get; set; }
        public int PermissionTypeId { get; set; }
        public DateTime RequestDate { get; set; }
        public class CreatePermissionCommandHandler : IRequestHandler<CreatePermissionCommand, int>
        {
            private readonly IApplicationDbContext _context;
            public CreatePermissionCommandHandler(IApplicationDbContext context)
            {
                _context = context;
            }
            public async Task<int> Handle(CreatePermissionCommand command, CancellationToken cancellationToken)
            {
                var permission = new Permission();
                permission.EmployeeName = command.EmployeeName;
                permission.EmployeeLastName = command.EmployeeLastName;
                permission.PermissionTypeId = command.PermissionTypeId;
                permission.RequestDate = command.RequestDate;
                _context.Permissions.Add(permission);
                await _context.SaveChangesAsync();
                return permission.Id;
            }
        }
    }
}
