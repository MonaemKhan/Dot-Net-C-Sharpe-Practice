using AutoMapper;
using InvenTrackPro.Application.Models.Entities;
using InvenTrackPro.Infrastructure.Interfaces;
using InvenTrackPro.SharedKernel.Common.Collection;
using InvenTrackPro.SharedKernel.Entities;
using InvenTrackPro.SharedKernel.Extensions.Results;
using MediatR;

namespace InvenTrackPro.Application.Features.CompanyInfoOperation.Query;

public record GetCompanyInfoList(int PageIndex, int PageSize, string SearchText) : IRequest<QueryResult<Paging<VmCompanyInfo>>>;

public class GetCompanyInfoListHandler : IRequestHandler<GetCompanyInfoList, QueryResult<Paging<VmCompanyInfo>>>
{
    private readonly ICompanyInfoRepository _companyInfoRepository;
    private readonly IMapper _mapper;

    public GetCompanyInfoListHandler(ICompanyInfoRepository companyInfoRepository, IMapper mapper)
    {
        _companyInfoRepository = companyInfoRepository;
        _mapper = mapper;
    }

    public async Task<QueryResult<Paging<VmCompanyInfo>>> Handle(GetCompanyInfoList request, CancellationToken cancellationToken)
    {
        var data = await _companyInfoRepository.GetPageAsync(request.PageIndex, request.PageSize,
            p => (string.IsNullOrEmpty(request.SearchText) || p.CompanyName.Contains(request.SearchText)),
            o => o.OrderBy(ob => ob.CompanyName),
            se => se);

        var result = data.ToPagingModel<CompanyInfo, VmCompanyInfo>(_mapper);

        if (result is null)
        {
            return new QueryResult<Paging<VmCompanyInfo>>(null, QueryResultTypeEnum.NotFound);
        }
        return new QueryResult<Paging<VmCompanyInfo>>(result, QueryResultTypeEnum.Success);
    }
}
