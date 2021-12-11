using GFTTechnicalTest.Domain.Entities;
using MediatR;

namespace GFTTechnicalTest.Domain.Commands
{
    public class RegisterNewOrderCommand : IRequest<Order>
    {
        public string Input { get; set; }

        public RegisterNewOrderCommand(string input)
        {
            Input = input;
        }
    }
}
