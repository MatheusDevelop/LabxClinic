using AutoMapper;
using Domain.Entities;
using Domain.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Mappings
{
    public class ExamCoverageMapping:Profile
    {
        public ExamCoverageMapping()
        {
            CreateMap<ExamCoverageInsertViewModel, ExamCoverage>();
            CreateMap<ExamCoverage,ExamCoverageListViewModel>();


        }
    }
}
