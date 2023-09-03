using AutoMapper;
using MagniFinance.Data.Context;
using MagniFinance.Domain.Core.Commands.Handlers;
using MediatR;
using Microsoft.Extensions.Logging;

namespace MagniFinance.Domain.Student.Commands.Handlers;

public class ModifyStudentCommandHandler : CommandHandler<ModifyStudentCommand>
{
    private readonly ILogger<ModifyStudentCommandHandler> _logger;
    
    public ModifyStudentCommandHandler(ILogger<ModifyStudentCommandHandler> logger, ApplicationDbContext context, IMapper mapper) : base(context, mapper)
     => _logger = logger;
    

    public override Task<Unit> Handle(ModifyStudentCommand request, CancellationToken cancellationToken)
    {
        _logger.LogInformation("Creating or Updating student info");
        throw new NotImplementedException();
    }
}