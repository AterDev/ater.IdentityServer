using Definition.Share.Models.ApplicationDtos;

namespace Application.Manager;
/// <summary>
/// Application
/// </summary>
public class ApplicationManager(
    DataAccessContext<Definition.Entity.OpenId.Application> dataContext,
    ILogger<ApplicationManager> logger,
    IUserContext userContext) : ManagerBase<Definition.Entity.OpenId.Application, ApplicationUpdateDto, ApplicationFilterDto, ApplicationItemDto>(dataContext, logger)
{
    private readonly IUserContext _userContext = userContext;

    /// <summary>
    /// 创建待添加实体
    /// </summary>
    /// <param name="dto"></param>
    /// <returns></returns>
    public async Task<Definition.Entity.OpenId.Application> CreateNewEntityAsync(ApplicationAddDto dto)
    {
        var entity = dto.MapTo<ApplicationAddDto, Definition.Entity.OpenId.Application>();
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
        return await Task.FromResult(entity);
    }

    public override async Task<Definition.Entity.OpenId.Application> UpdateAsync(Definition.Entity.OpenId.Application entity, ApplicationUpdateDto dto)
    {
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
        return await base.UpdateAsync(entity, dto);
    }

    public override async Task<PageList<ApplicationItemDto>> FilterAsync(ApplicationFilterDto filter)
    {
        Queryable = Queryable
            .WhereNotNull(filter.ApplicationType, q => q.ApplicationType == filter.ApplicationType)
            .WhereNotNull(filter.ClientType, q => q.ClientType == filter.ClientType)
            .WhereNotNull(filter.ConsentType, q => q.ConsentType == filter.ConsentType)
            .WhereNotNull(filter.DisplayName, q => q.DisplayName == filter.DisplayName);
        // TODO: custom filter conditions
        return await Query.FilterAsync<ApplicationItemDto>(Queryable, filter.PageIndex, filter.PageSize, filter.OrderBy);
    }

    /// <summary>
    /// 是否唯一
    /// </summary>
    /// <returns></returns>
    public async Task<bool> IsUniqueAsync(string unique)
    {
        // TODO:自定义唯一性验证参数和逻辑
        return await Command.Db.AnyAsync(q => q.Id == new Guid(unique));
    }

    /// <summary>
    /// 当前用户所拥有的对象
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public async Task<Definition.Entity.OpenId.Application?> GetOwnedAsync(Guid id)
    {
        var query = Command.Db.Where(q => q.Id == id);
        // 获取用户所属的对象
        // query = query.Where(q => q.User.Id == _userContext.UserId);
        return await query.FirstOrDefaultAsync();
    }

}
