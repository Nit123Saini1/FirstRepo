using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiProject.Models;
using WebApiProject.Tables;

namespace WebApiProject.Helpers
{
    public class ApplicationHelper :Profile
    {
        public ApplicationHelper()
        {
            CreateMap<tblBook, BooksModel>().ReverseMap();
        }
    }
}
