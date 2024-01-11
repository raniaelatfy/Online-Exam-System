using ApplicationLayer.Bussiness_Logic_Layer.DTO;
using AutoMapper;
using Data_Access_Layer.Repository.Entities;
using RepositoryLayer.Data_Access_Layer.IRepository;
using RepositoryLayer.Data_Access_Layer.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationLayer.Bussiness_Logic_Layer.IServices
{
    public class QuestionService
    {
        private readonly IQuestionRepository _questionRepository;
        private readonly IMapper _mapper;
        private readonly ApplicationDbContext _context;

        public QuestionService(IQuestionRepository questionRepository, IMapper mapper,ApplicationDbContext context)
        {
            _questionRepository = questionRepository;
            _mapper = mapper;
            _context = context;
        }

        public async Task AddQuestion(QuestionDto questionDto)
        {
            if (questionDto != null)
            {
                var question = _mapper.Map<QuestionDto, Question>(questionDto);
             
                await _questionRepository.AddQuestionAsync(question);
              

            }
        }
       
    }
}
