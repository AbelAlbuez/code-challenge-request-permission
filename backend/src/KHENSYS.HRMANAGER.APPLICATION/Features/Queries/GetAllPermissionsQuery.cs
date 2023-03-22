using KHENSYS.HRMANAGER.APPLICATION.Interfaces;
using MediatR;
using System.Threading.Tasks;
using System.Threading;
using KHENSYS.HRMANAGER.DOMAIN.Entities;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace KHENSYS.HRMANAGER.APPLICATION.Features.Queries
{
    public class GetAllPermissionsQuery : IRequest<IEnumerable<Permission>>
    {

        public class GetAllPermissionsQueryHandler : IRequestHandler<GetAllPermissionsQuery, IEnumerable<Permission>>
        {
            private readonly IApplicationDbContext _context;
            public GetAllPermissionsQueryHandler(IApplicationDbContext context)
            {
                _context = context;
            }
            public async Task<IEnumerable<Permission>> Handle(GetAllPermissionsQuery query, CancellationToken cancellationToken)
            {
                var PermissionList = await _context.Permissions.ToListAsync();
                if (PermissionList == null)
                {
                    return null;
                }
                return PermissionList.AsReadOnly();
            }
        }
    }
}
