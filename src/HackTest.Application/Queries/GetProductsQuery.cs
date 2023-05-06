using AutoMapper;
using HackTest.Application.DTOs;
using HackTest.Application.Mapping;
using HackTest.Domain.Entities;
using HackTest.Infrastructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackTest.Application.Queries;

public class GetProductsQuery : IRequest<List<ProductDto>> { }

public class GetProductsQueryHandler : IRequestHandler<GetProductsQuery, List<ProductDto>>
{
    private readonly HackTestDbContext _context;

    public GetProductsQueryHandler(HackTestDbContext context)
    {
        _context = context;
    }

    public async Task<List<ProductDto>> Handle(GetProductsQuery request, CancellationToken cancellationToken)
    {
        var products = _context.Products.Include(p => p.Category).ToList();

        var productsDto = ObjectMapper.Mapper.Map<List<ProductDto>>(products);

        if (!products.Any()) return new List<ProductDto>();

        return productsDto;
    }
}
