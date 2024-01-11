using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApplicationLayer.Bussiness_Logic_Layer.DTO;
using AutoMapper;
using Business_Access_Layer;
using Data_Access_Layer.Repository.Entities;
using Microsoft.Extensions.DependencyInjection;
using RepositoryLayer.Data_Access_Layer.IRepository;
using RepositoryLayer.Data_Access_Layer.Repository;
using Data_Access_Layer.Repository;
using System.Net.Mail;
using System.Net;

static class Program
{
      static void Main(string[] args)
    {
        var config = new MapperConfiguration(cfg =>
        {
            cfg.AddProfile<MappingProfile>();
        });

        // Create the mapper instance
        IMapper _mapper = config.CreateMapper();
        var factory = new ConnectionFactory
        {
            Uri = new Uri("amqp://guest:guest@localhost:5672")
        };

        var connection = factory.CreateConnection();
        var channel = connection.CreateModel();

        var services = new ServiceCollection();
        services.AddTransient<IExamRepository, ExamRepository>();
        services.AddTransient<IQuestionRepository, QuestionRepository>();
        services.AddTransient<IStudentRepository, StudentRepository>();
        var serviceProvider = services.BuildServiceProvider();
        var examRepository = serviceProvider.GetService<IExamRepository>();
        var questionRepository= serviceProvider.GetService<IQuestionRepository>();
        var studentRepository = serviceProvider.GetService<IStudentRepository>();
        var consumer = new EventingBasicConsumer(channel);
        consumer.Received += async (model, ea) =>
        {
            var body = ea.Body;
            var message = Encoding.UTF8.GetString(body.ToArray());

            var submitExamDto = JsonConvert.DeserializeObject<SubmitExamDto>(message);
         var exam=_mapper.Map<SubmitExamDto, Exam>(submitExamDto);
            examRepository.AddExamAsync(exam);
            var student = studentRepository.GetById(submitExamDto.StudentId);
            int result = 0;
            foreach (var item in submitExamDto.ExamQuestions)
            {
                var question =await  questionRepository.GetRightChoiceAsync(item.QuestionId);
                if(question.IsCorrect==true)
                {
                    result++;
                }

            }
            string senderEmail = "your_email@example.com";
            string senderPassword = "your_password";
            string recipientEmail = student.StudentEmail;
            MailMessage mailmessage = new MailMessage(senderEmail, recipientEmail)
        {
                Subject = "Exam Result",
            Body = string.Format("Hello {0}, Your Exam Result is {1}/10", student.StudentFName, result)
        };

            // Create a new SmtpClient
            SmtpClient smtpClient = new SmtpClient("smtp.gmail.com", 587)
            {
                Credentials = new NetworkCredential(senderEmail, senderPassword)
            };
            smtpClient.Send(mailmessage);
            // Process the message

            Console.WriteLine("Received message: " + message);
        };

        channel.BasicConsume("exam-queue", autoAck: true, consumer);
        Console.ReadKey();
    }
}