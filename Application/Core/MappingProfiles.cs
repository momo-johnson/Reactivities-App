using System;
using AutoMapper;
using Domain.DTOs;
using Domain.Entities;

namespace Application.Core
{
	public class MappingProfiles: Profile
	{
		public MappingProfiles()
		{
			CreateMap<ActivityAddRequest, Activity>().ReverseMap();
			CreateMap<ActivityResponse, Activity>().ReverseMap();
			CreateMap<ActivityUpdateRequest, Activity>().ReverseMap();

		}
	}
}

