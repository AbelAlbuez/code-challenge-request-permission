using KHENSYS.HRMANAGER.APPLICATION.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace KHENSYS.HRMANAGER.APPLICATION.Features.Command
{
    public class UpdatePermissionCommand : IRequest<int>
    {
        public int Id { get; set; }
        public string EmployeeName { get; set; }
        public string EmployeeLastName { get; set; }
        public int PermissionTypeId { get; set; }
        public DateTime RequestDate { get; set; }
        public class UpdatePermissionCommandHandler : IRequestHandler<UpdatePermissionCommand, int>
        {
            private readonly IApplicationDbContext _context;
            public UpdatePermissionCommandHandler(IApplicationDbContext context)
            {
                _context = context;
            }

            public async Task<int> Handle(UpdatePermissionCommand command, CancellationToken cancellationToken)
            {
                var permission = _context.Permissions.Where(a => a.Id == command.Id).FirstOrDefault();

                if (permission == null)
                {
                    return default;
                }
                else
                {
                    permission.EmployeeName = command.EmployeeName;
                    permission.EmployeeLastName = command.EmployeeLastName;
                    permission.PermissionTypeId = command.PermissionTypeId;
                    permission.RequestDate = command.RequestDate;
                    await _context.SaveChangesAsync();
                    return permission.Id;
                }
            }
        }
     }
}
