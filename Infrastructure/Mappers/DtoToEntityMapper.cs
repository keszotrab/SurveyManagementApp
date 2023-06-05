using Infrastructure.EF.Entities;
using System.Threading.Channels;
using WebAPI.Dto;

namespace WebAPI.Mappers
{
    public class DtoToEntityMapper
    {
        public static ClosedUserAnswersEntity FromDtoToClosedUserAnswer(ClosedUserAnswersDto dto)
        {
            return new ClosedUserAnswersEntity()
            {
                Id = dto.Id,
                UserId = dto.UserId,
                AnswerId = dto.AnswerId,
                Email = dto.Email
            };
        }

        public static OpenUserAnswersEntity FromDtoToOpenUserAnswer(OpenUserAnswersDto dto)
        {
            return new OpenUserAnswersEntity()
            {
                Id = dto.Id,
                UserId = dto.UserId,
                AnswerId = dto.AnswerId,
                Email = dto.Email
            };
        }
    }
}
