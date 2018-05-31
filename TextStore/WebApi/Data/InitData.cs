using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextStore.Model;
using TextStore.WebApi.Model;
using TextStore.WebApi.Infrastructure;

namespace TextStore.WebApi.Data
{
    public class InitData
    {
        private IRepository _repository;
        private Configuration _configuration;

        public InitData(IRepository repository)
        {
            _repository = repository;
        }

        public void Init()
        {
            _configuration = Configuration.GetConfiguration();

           if(_repository.GetUser(_configuration.SystemUser.Login) == null)
            {
                _repository.Init();

                _configuration.SystemUser.NewSecret();
                _repository.Save(_configuration.SystemUser);

                var s1 = new Story(@"Анекдоты",
                    @"Я думал, что к 30-ти годам я буду разъезжать на жёлтом ""Ламборджини"". А сейчас радуюсь жёлтым ценникам в ""Пятёрочке"".");
                _repository.Save(s1);

                var s2 = new Story(@"Анекдоты",
                    @"Чтобы покорить женщину, одного желания мало. Лучше пообещать исполнить все её желания.");
                _repository.Save(s2);
            }
                
        }
    }
}
