
using KHENSYS.HRMANAGER.APPLICATION.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.ProductFeatures.Commands
{
    public class DeletePermissionByIdCommand : IRequest<int>
    {
        public int Id { get; set; }
        public class DeleteProductByIdCommandHandler : IRequestHandler<DeletePermissionByIdCommand, int>
        {
            private readonly IApplicationDbContext _context;
            public DeleteProductByIdCommandHandler(IApplicationDbContext context)
            {
                _context = context;
            }
            public async Task<int> Handle(DeletePermissionByIdCommand command, CancellationToken cancellationToken)
            {
                var permission = await _context.Permissions.Where(a => a.Id == command.Id).FirstOrDefaultAsync();
                if (permission == null) return default;
                _context.Permissions.Remove(permission);
                await _context.SaveChangesAsync();
                return permission.Id;
            }
        }
    }
}