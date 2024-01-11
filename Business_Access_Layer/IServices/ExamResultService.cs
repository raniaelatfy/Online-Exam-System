using AutoMapper;
using Microsoft.TeamFoundation.Work.WebApi;
using RepositoryLayer.Data_Access_Layer.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RepositoryLayer.Data_Access_Layer.IRepository;
using Data_Access_Layer.Repository.Pagination;
using Microsoft.AspNetCore.Mvc;
using ApplicationLayer.Bussiness_Logic_Layer.DTO;
using Data_Access_Layer.Repository.Entities;

namespace ApplicationLayer.Bussiness_Logic_Layer.IServices
{
  
    public class ExamResultService
    {
        private readonly IExamResultRepository _examResultRepository;
        private readonly IMapper _mapper;
        public ExamResultService(IMapper mapper ,IExamResultRepository examResultRepository)
        {
            _mapper = mapper;
            _examResultRepository = examResultRepository ?? throw new ArgumentNullException(nameof(examResultRepository));

        }

        public async Task<List<ExamResultDto>> GetAllExamResult(PagingParameters pagingParameters,string studentid)
        {
            var Examresultlist = await _examResultRepository.GetAllExamResultAsync(pagingParameters,studentid);
            var result= _mapper.Map<List<ExamResult>, List<ExamResultDto>>(Examresultlist);
            return result;
        }
        public async Task<List<AdminExamresultDto>> GetAllExamHistory(PagingParameters pagingParameters)
        {
            var Examresultlist = await _examResultRepository.GetAllExamHistoryAsync(pagingParameters);
            return _mapper.Map<List<ExamResult>, List<AdminExamresultDto>>(Examresultlist);
        }
    }
}
