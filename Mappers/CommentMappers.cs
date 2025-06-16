using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using webapi.Dtos.Comment;
using webapi.models;

namespace webapi.Mappers
{
    public static class CommentMappers
    {
        public static CommentDtos ToCommentDto(this Comment CommentModel)
        {
            return new CommentDtos
            {
                Id = CommentModel.Id,
                Title = CommentModel.Title,
                CreatedOn = CommentModel.CreatedOn,
                Content = CommentModel.Content,
                StockId = CommentModel.StockId,
            };
        }
        public static Comment ToCommentFromCreate(this CreateCommentrequest CommentDto, int StockId)
        {
            return new Comment
            {
                Title = CommentDto.Title,
                Content = CommentDto.Content,
                StockId = StockId
            };
        }
        public static Comment ToCommentFromUpdate(this UpdateCommentRequestDto CommentDto)
        {
            return new Comment
            {
                Title = CommentDto.Title,
                Content = CommentDto.Content,
            };
        }

    }
}