using AutoMapper;
using GenericCourse.Services.Catalog.DTOs;
using GenericCourse.Services.Catalog.Models;

namespace GenericCourse.Services.Catalog.Mapping
{
    public class GenericMapping : Profile
    {
        public GenericMapping()
        {
            CreateMap<Models.Course, CourseDTO>().ReverseMap();
            CreateMap<Category, CategoryDTO>().ReverseMap();
            CreateMap<Feature, FeatureDTO>().ReverseMap();

            CreateMap<Models.Course, CourseCreateDTO>().ReverseMap();
            CreateMap<Models.Course, CourseUpdateDTO>().ReverseMap();
        }
    }
}
