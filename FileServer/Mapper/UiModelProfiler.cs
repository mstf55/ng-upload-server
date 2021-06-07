using AutoMapper;
using FileServer.App.Model;
using FileServer.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FileServer.Mapper
{
    public class UiModelProfiler:Profile
    {
        public UiModelProfiler()
        {
            CreateMap<FileModel, FileViewModel>().ReverseMap();
        }
    }
}
