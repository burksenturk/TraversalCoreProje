using MediatR;
using System.Threading.Tasks;
using System.Threading;
using TraversalCoreProje.CQRS.Commands.GuideCommands;
using DataAccessLayer.Concrete;
using EntityLayer.Concrete;

namespace TraversalCoreProje.CQRS.Handlers.GuideHandlers
{
    public class CreateGuideCommanHandler : IRequestHandler<CreateGuideCommand>
    {
        private readonly Context _context;
        public CreateGuideCommanHandler(Context context)
        {
            _context = context;
        }
        public async Task<Unit> Handle(CreateGuideCommand request, CancellationToken cancellationToken)  //Task<Unit> void gönüş türü gibi bir şey
        {
            _context.Guides.Add(new Guide
            {
                Name = request.Name,
                Description = request.Description,
                Status = true
            });
            await _context.SaveChangesAsync();
            return Unit.Value;
        }
    }
}
