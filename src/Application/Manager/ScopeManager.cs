using Application.Manager;
using Definition.Share.Models.ScopeDtos;

namespace Application.Manager;
/// <summary>
/// Scope
/// </summary>
public class ScopeManager(
    DataAccessContext<Scope> dataContext, 
    ILogger<ScopeManager> logger,
    IUserContext userContext) : ManagerBase<Scope, ScopeUpdateDto, ScopeFilterDto, ScopeItemDto>(dataContext, logger)
{
    private readonly IUserContext _userContext = userContext;

    /// <summary>
    /// 创建待添加实体
    /// </summary>
    /// <param name="dto"></param>
    /// <returns></returns>
    public async Task<Scope> CreateNewEntityAsync(ScopeAddDto dto)
    {
        var entity = dto.MapTo<ScopeAddDto, Scope>();
        // other required props
        return await Task.FromResult(entity);
    }

    public override async Task<Scope> UpdateAsync(Scope entity, ScopeUpdateDto dto)
    {
        return await base.UpdateAsync(entity, dto);
    }

    public override async Task<PageList<ScopeItemDto>> FilterAsync(ScopeFilterDto filter)
    {
        // TODO: custom filter conditions
        return await Query.FilterAsync<ScopeItemDto>(Queryable, filter.PageIndex, filter.PageSize, filter.OrderBy);
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
    public async Task<Scope?> GetOwnedAsync(Guid id)
    {
        var query = Command.Db.Where(q => q.Id == id);
        // 获取用户所属的对象
        // query = query.Where(q => q.User.Id == _userContext.UserId);
        return await query.FirstOrDefaultAsync();
    }

}
