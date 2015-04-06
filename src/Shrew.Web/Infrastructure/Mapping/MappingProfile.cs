using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Humanizer;
using Shrew.Web.Infrastructure.SuggestionsBox;
using Shrew.Web.Models.Domain;
namespace Shrew.Web.Infrastructure.Mapping
{
    public class MappingProfile : Profile
    {
        protected override void Configure()
        {
            CreateMap<Task<IList<Box>>, Task<IList<IndexModel>>>();

            CreateMap<Box, IndexModel>()
                .ForMember(b => b.Suggestions, o => o.MapFrom(x => x.Suggestions == null ? 0 : x.Suggestions.Count()))
                .ForMember(dest => dest.CreationDate, cfg => cfg.MapFrom(origin => HumanizeDate(origin.CreationDate)))
                .ForMember(dest => dest.Id, cfg => cfg.MapFrom(origin => RavenIdResolver.Resolve(origin.Id)))
                .ForMember(dest => dest.NameSlug, cfg => cfg.MapFrom(origin => SlugConverter.TitleToSlug(origin.Name)));
            CreateMap<Box, DetailsModel>()
            .ForMember(dest => dest.Id, cfg => cfg.MapFrom(origin => RavenIdResolver.Resolve(origin.Id)))
            .ForMember(dest => dest.CreationDate, cfg => cfg.MapFrom(origin => origin.CreationDate.ToLocalTime()))
            .ForMember(dest => dest.NewSuggestion, cfg => cfg.Ignore());
        }

        /// <summary>
        /// Humanizes the date. This was created to debug.
        /// The Humanize does not work in spanish.
        /// </summary>
        /// <param name="date">The date.</param>
        /// <returns></returns>
        private string HumanizeDate(DateTime date)
        {
            return date.ToLocalTime().Humanize(false, null, CultureConfig.DefaultCulture);
        }
    }
}