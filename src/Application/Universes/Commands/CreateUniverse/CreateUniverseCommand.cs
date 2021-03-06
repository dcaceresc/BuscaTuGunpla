using Application.Common.Interfaces;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Universes.Commands.CreateUniverse
{
    public class CreateUniverseCommand : IRequest<int>
    {
        public string Name { get; set; }

        public class CreateUniverseCommandHandler : IRequestHandler<CreateUniverseCommand, int>
        {
            private readonly IApplicationDbContext _context;

            public CreateUniverseCommandHandler(IApplicationDbContext context)
            {
                _context = context;
            }

            public async Task<int> Handle(CreateUniverseCommand request, CancellationToken cancellationToken)
            {
                var entity = new Universe
                {
                    Name = request.Name
                };

                _context.Universes.Add(entity);
                await _context.SaveChangesAsync(cancellationToken);

                return entity.Id;
            }
        }
    }

    
}
