﻿using _1._API.Request;
using _3._Data.Model;
using AutoMapper;
namespace _1._API.Mapper.ReviewMapper;

public class ReviewAPIToModel: Profile
{
    public ReviewAPIToModel()
    {
        CreateMap<ReviewRequest, Review>();
    }
}