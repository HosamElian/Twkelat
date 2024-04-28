using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Twkelat.Persistence.DTOs;
using Twkelat.Persistence.Models;

namespace Twkelat.Persistence.Mapping
{
    public class MappingConfig : Profile
    {
        public MappingConfig()
        {
            CreateMap<DelegationDTO, Block>().ReverseMap();
        }
    }
}
