using InvenTrackPro.Application.Models.Entities;
using InvenTrackPro.Infrastructure.Interfaces;
using InvenTrackPro.SharedKernel.Common.Collection;
using InvenTrackPro.SharedKernel.Extensions.Results;
using MediatR;

namespace InvenTrackPro.Application.Features.CompanyInfoOperation.Query;
public record GetCompanyInfoDropdown(string SearchText, int Size):IRequest<QueryResult<Dropdown<VmCompanyInfo>>>;
public class GetCompanyInfoDropdownHandler : IRequestHandler<GetCompanyInfoDropdown, QueryResult<Dropdown<VmCompanyInfo>>>
{
    private readonly ICompanyInfoRepository _companyInfoRepository;

    public GetCompanyInfoDropdownHandler(ICompanyInfoRepository companyInfoRepository)
    {
        _companyInfoRepository = companyInfoRepository;
    }

    public async Task<QueryResult<Dropdown<VmCompanyInfo>>> Handle(GetCompanyInfoDropdown request, CancellationToken cancellationToken)
    {
        var result = await _companyInfoRepository.GetDropdownAsync(
            p=>(string.IsNullOrEmpty(request.SearchText)|p.CompanyName.Contains(request.SearchText)),
            o=>o.OrderBy(ob=>ob.CompanyName),
            se=> new VmCompanyInfo { Id = se.Id, CompanyName=se.CompanyName}, 
            request.Size);

        return result switch
        {
            null => new QueryResult<Dropdown<VmCompanyInfo>>(null, QueryResultTypeEnum.NotFound),
            _ => new QueryResult<Dropdown<VmCompanyInfo>>(result, QueryResultTypeEnum.Success)
        };
    }
}
