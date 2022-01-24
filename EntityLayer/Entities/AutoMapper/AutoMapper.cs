using AutoMapper;
using BaseCore.Entities.Concrete;
using BaseCore.Entities.Concrete.Dtos.BaseDto;
using BaseCore.Entities.Concrete.Dtos.ListDto;
using EntityLayer.Entities.Concrete;
using EntityLayer.Entities.DTOs.BaseDtos;
using EntityLayer.Entities.DTOs.BaseListDto;

namespace EntityLayer.Entities.AutoMapper
{
    public class AutoMapper : Profile
    {
        public AutoMapper()
        {
            CreateMap<Account, AccountDto>().ReverseMap();
            CreateMap<Account, AccountsDto>()
                .ForMember(account => account.User,
                name => name.MapFrom(user => user.User.FirstName + user.User.LastName))
                .ForMember(account => account.Image,
                path => path.MapFrom(image => image.Image.Path));
            
            CreateMap<Category, CategoryDto>().ReverseMap();
            CreateMap<Category, CategoriesDto>()
                .ForMember(category => category.ParentCategory,
                name => name.MapFrom(category => category.ParentCategory.Name));

            CreateMap<Content, ContentDto>().ReverseMap();
            CreateMap<Content, ContentsDto>();

            CreateMap<User, UserDto>().ReverseMap();
            CreateMap<User, UsersDto>();

            CreateMap<OperationClaim, OperationClaimDto>().ReverseMap();
            CreateMap<OperationClaim, OperationClaimsDto>();

            CreateMap<UserOperationClaimPairing, UserOperationClaimPairingDto>().ReverseMap();
            CreateMap<UserOperationClaimPairing, UserOperationClaimPairingsDto>()
                .ForMember(claim => claim.OperationClaim,
                name => name.MapFrom(claim => claim.OperationClaim.Name))
                .ForMember(user => user.User,
                name => name.MapFrom(student => student.User.FirstName + student.User.LastName));


            CreateMap<Course, CourseDto>().ReverseMap();
            CreateMap<Course, CoursesDto>()
                .ForMember(course => course.Instructor,
                name => name.MapFrom(instructor => instructor.Instructor.Account.User.FirstName + instructor.Instructor.Account.User.LastName))
                .ForMember(account => account.Image,
                path => path.MapFrom(image => image.Image.Path));

            CreateMap<CourseStudentPairing, CourseStudentPairingDto>().ReverseMap();
            CreateMap<CourseStudentPairing, CourseStudentPairingsDto>()
                .ForMember(courseStudent => courseStudent.Course,
                title => title.MapFrom(course => course.Course.Title))
                .ForMember(student => student.Student,
                name => name.MapFrom(student => student.Student.Account.User.FirstName + student.Student.Account.User.LastName));

            CreateMap<Image, ImageDto>().ReverseMap();
            CreateMap<Image, ImagesDto>();

            CreateMap<Instructor, InstructorDto>().ReverseMap();
            CreateMap<Instructor, InstructorsDto>()
                .ForMember(instructor => instructor.Account,
                name => name.MapFrom(account => account.Account.User.FirstName + account.Account.User.LastName));

            CreateMap<Lecture, LectureDto>().ReverseMap();
            CreateMap<Lecture, LecturesDto>()
                .ForMember(lecture => lecture.Section,
                name => name.MapFrom(section => section.Section.Title))
                .ForMember(image => image.Image,
                path => path.MapFrom(image => image.Image.Path));

            CreateMap<Section, SectionDto>().ReverseMap();
            CreateMap<Section, SectionsDto>()
                .ForMember(content => content.Content,
                title => title.MapFrom(content => content.Content.Title));

            CreateMap<SocialMediaAccount, SocialMediaAccountDto>().ReverseMap();
            CreateMap<SocialMediaAccount, SocialMediaAccountsDto>()
                .ForMember(socialMedia => socialMedia.Instructor,
                name => name.MapFrom(instructor => instructor.Instructor.Account.User.FirstName + instructor.Instructor.Account.User.LastName));


            CreateMap<Student, StudentDto>().ReverseMap();
            CreateMap<Student, StudentsDto>()
                .ForMember(student => student.Account,
                account => account.MapFrom(name => name.Account.User.FirstName + name.Account.User.LastName));

        }
    }
}
