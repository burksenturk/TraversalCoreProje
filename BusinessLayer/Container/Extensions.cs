using BusinessLayer.Abstract;
using BusinessLayer.Abstract.AbstractUow;
using BusinessLayer.Concrete;
using BusinessLayer.Concrete.ConcreteUow;
using BusinessLayer.ValidationRules;
using BusinessLayer.ValidationRules.AnnouncementValidationRules;
using DataAccessLayer.Abstract;
using DataAccessLayer.EntityFramework;
using DataAccessLayer.UnitOfWork;
using DTOLayer.DTOs.AnnouncementDTOs;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Container
{
	public static class Extensions
	{
		public static void ContainerDependencies(this IServiceCollection services) //this koymazsam startup.cs de metodu görmüyor
		{

			services.AddScoped<ICommentService, CommentManager>();
			services.AddScoped<ICommentDal, EfCommentDal>();

			services.AddScoped<IDestinationService, DestinationManager>();
			services.AddScoped<IDestinationDal, EfDestinationDal>();

			services.AddScoped<IAppUserService, AppUserManager>();
			services.AddScoped<IAppUserDal, EfAppUserDal>();

            services.AddScoped<IReservationService, ReservationManager>();
            services.AddScoped<IReservationDal, EfReservationDal>();

            services.AddScoped<IGuideService, GuideManager>();
            services.AddScoped<IGuideDal, EfGuideDal>();

			services.AddScoped<IContactUsService, ContactUsManager>();
			services.AddScoped<IContactUsDal, EfContactUsDal>();

            services.AddScoped<IAnnouncementService, AnnouncementManager>();
            services.AddScoped<IAnnouncementDal, EfAnnouncementDal>();

            services.AddScoped<IExcelService, ExcelManager>();
			services.AddScoped<IPdfService, PdfManager>();

			services.AddScoped<IAccountService, AccountManager>();
			services.AddScoped<IAccountDal, EfAccountDal>();

			services.AddScoped<IUowDal,UowDal>();

        }

		public static void CustomerValidator(this IServiceCollection services)
		{
            services.AddTransient<IValidator<AnnouncementAddDto>, AnnouncementValidator>();
            services.AddTransient<IValidator<AnnouncementUpdateDto>, AnnouncementUpdateValidator>();

        }
    }
}
