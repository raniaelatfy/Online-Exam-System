using ApplicationLayer.Bussiness_Logic_Layer.DTO;
using AutoMapper;
using Data_Access_Layer.Repository.Entities;
using Microsoft.AspNetCore.Connections;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RabbitMQ.Client;
using RepositoryLayer.Data_Access_Layer.IRepository;
using RepositoryLayer.Data_Access_Layer.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationLayer.Bussiness_Logic_Layer.IServices
{
    public class ExamService
    {
        private readonly IExamRepository _examRepository;
        private readonly IMapper _mapper;


        public ExamService(IExamRepository examRepository, IMapper mapper)
        {
            _examRepository = examRepository;
            _mapper = mapper;

        }

        public async Task SubmitExam(List<SubmitExamDto> examDto)
        {
            if (examDto != null)
            {

                var factory = new ConnectionFactory
                {
                    Uri = new Uri("amqp://guest:guest@localhost:5672")
                };

                var connection = factory.CreateConnection();
                var channel = connection.CreateModel();

                var body = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(examDto));
                channel.BasicPublish("", "exam-queue", null, body);
            }

        }

        public async Task<List<RequestExamDto>> RequestExam(int subjectId)
        {

            var questions = await _examRepository.RequestExamAsync(subjectId);

            return _mapper.Map<List<Question>, List<RequestExamDto>>(questions);
        }

    } 
}
