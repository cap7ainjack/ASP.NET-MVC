using AutoMapper;
using KidsAcademy.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KidsAcademy.Services
{
   public abstract class Service
    {
        public Service()
        {
            this.Context = new KidsAcademyContext();
        }

        protected KidsAcademyContext Context { get; }
    }
}
