using Definition.Share.Models.ApplicationDtos;

using OpenIdApplication = Definition.Entity.OpenId.Application;

namespace Application.Manager;
/// <summary>
/// Application
/// </summary>
public class ApplicationManager(
    DataAccessContext<OpenIdApplication> dataContext,
    ILogger<ApplicationManager> logger,
    IUserContext userContext) : ManagerBase<OpenIdApplication>(dataContext, logger)
{
    private readonly IUserContext _userContext = userContext;

    /// <summary>
    /// 创建待添加实体
    /// </summary>
    /// <param name="dto"></param>
    /// <returns></returns>
    public async Task<Guid?> AddAsync(ApplicationAddDto dto)
    {
        var entity = dto.MapTo<ApplicationAddDto, OpenIdApplication>();
        /*
        if (dto.AuthorizationIds != null && dto.AuthorizationIds.Count > 0)
        {
            var authorizations = await CommandContext.Authorizations()
                .Where(t => dto.AuthorizationIds.Contains(t.Id))
                .ToListAsync();
            if (authorizations != null)
            {
                entity.Authorizations = authorizations;
            }
        }
        */
        /*
        if (dto.TokenIds != null && dto.TokenIds.Count > 0)
        {
            var tokens = await CommandContext.Tokens()
                .Where(t => dto.TokenIds.Contains(t.Id))
                .ToListAsync();
            if (tokens != null)
            {
                entity.Tokens = tokens;
            }
        }
        */
        // other required props
        return await AddAsync(entity) ? entity.Id : null;
    }

    public async Task<bool> UpdateAsync(OpenIdApplication entity, ApplicationUpdateDto dto)
    {
        entity.Merge(dto);
        /*
        if (dto.AuthorizationIds != null && dto.AuthorizationIds.Count > 0)
        {
            var authorizations = await CommandContext.Authorizations()
                .Where(t => dto.AuthorizationIds.Contains(t.Id))
                .ToListAsync();
            if (authorizations != null)
            {
                entity.Authorizations = authorizations;
            }
        }
        */
        /*
        if (dto.TokenIds != null && dto.TokenIds.Count > 0)
        {
            var tokens = await CommandContext.Tokens()
                .Where(t => dto.TokenIds.Contains(t.Id))
                .ToListAsync();
            if (tokens != null)
            {
                entity.Tokens = tokens;
            }
        }
        */
        return await UpdateAsync(entity);
    }

    public async Task<PageList<ApplicationItemDto>> ToPageAsync(ApplicationFilterDto filter)
    {
        Queryable = Queryable
            .WhereNotNull(filter.ApplicationType, q => q.ApplicationType == filter.ApplicationType)
            .WhereNotNull(filter.ClientType, q => q.ClientType == filter.ClientType)
            .WhereNotNull(filter.ConsentType, q => q.ConsentType == filter.ConsentType)
            .WhereNotNull(filter.DisplayName, q => q.DisplayName == filter.DisplayName);

        return await ToPageAsync<ApplicationFilterDto, ApplicationItemDto>(filter);
    }

    /// <summary>
    /// 是否唯一
    /// </summary>
    /// <returns></returns>
    public async Task<bool> IsUniqueAsync(string unique)
    {
        // TODO:自定义唯一性验证参数和逻辑
        return await Command.AnyAsync(q => q.Id == new Guid(unique));
    }

    /// <summary>
    /// 当前用户所拥有的对象
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public async Task<OpenIdApplication?> GetOwnedAsync(Guid id)
    {
        var query = Command.Where(q => q.Id == id);
        // 获取用户所属的对象
        // query = query.Where(q => q.User.Id == _userContext.UserId);
        return await query.FirstOrDefaultAsync();
    }

}
