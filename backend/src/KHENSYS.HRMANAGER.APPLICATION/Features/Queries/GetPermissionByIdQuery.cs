using KHENSYS.HRMANAGER.APPLICATION.Interfaces;
using MediatR;
using System.Threading.Tasks;
using System.Threading;
using KHENSYS.HRMANAGER.DOMAIN.Entities;
using System.Linq;

namespace KHENSYS.HRMANAGER.APPLICATION.Features.Queries
{
    public class GetPermissionByIdQuery : IRequest<Permission>
    {
        public int Id { get; set; }
        public class GetPermissionByIdQueryHandler : IRequestHandler<GetPermissionByIdQuery, Permission>
        {
            private readonly IApplicationDbContext _context;
            public GetPermissionByIdQueryHandler(IApplicationDbContext context)
            {
                _context = context;
            }
            public async Task<Permission> Handle(GetPermissionByIdQuery query, CancellationToken cancellationToken)
            {
                var Permission = _context.Permissions.Where(a => a.Id == query.Id).FirstOrDefault();
                if (Permission == null) return null;
                return Permission;
            }
        }
    }
}
